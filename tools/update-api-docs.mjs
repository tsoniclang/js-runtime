#!/usr/bin/env node
import fs from "node:fs";
import path from "node:path";

const repoRoot = path.resolve(path.dirname(new URL(import.meta.url).pathname), "..");

const args = new Map();
for (let i = 2; i < process.argv.length; i += 1) {
  const current = process.argv[i];
  if (!current.startsWith("--")) continue;
  const key = current.slice(2);
  const value = process.argv[i + 1];
  if (value && !value.startsWith("--")) {
    args.set(key, value);
    i += 1;
  } else {
    args.set(key, "true");
  }
}

const exists = (candidatePath) => {
  try {
    return fs.existsSync(candidatePath);
  } catch {
    return false;
  }
};

const resolveFirstExisting = (candidates) => {
  for (const candidatePath of candidates) {
    if (exists(candidatePath)) return candidatePath;
  }
  return undefined;
};

const jsPackageRoot = args.get("js-package-root")
  ? path.resolve(repoRoot, args.get("js-package-root"))
  : resolveFirstExisting([
      path.resolve(repoRoot, "../js"),
      path.resolve(repoRoot, "node_modules/@tsonic/js"),
    ]);

if (!jsPackageRoot) {
  console.error("Unable to locate @tsonic/js package root. Pass --js-package-root <path>.");
  process.exit(1);
}

const facadePath = path.resolve(jsPackageRoot, "index.d.ts");
const internalPath = path.resolve(jsPackageRoot, "index/internal/index.d.ts");

for (const requiredPath of [facadePath, internalPath]) {
  if (!exists(requiredPath)) {
    console.error(`Missing required file: ${requiredPath}`);
    process.exit(1);
  }
}

const readText = (filePath) => fs.readFileSync(filePath, "utf8");

const facadeSource = readText(facadePath);
const internalSource = readText(internalPath);

const parseFacadeExports = (source) => {
  const exportsMap = new Map();
  const exportRe =
    /^export\s+\{\s*([A-Za-z0-9_$]+)\s+as\s+([A-Za-z0-9_$]+)\s*\}\s+from\s+['"][^'"]+['"];\s*$/gm;
  let match;
  while ((match = exportRe.exec(source))) {
    exportsMap.set(match[2], match[1]);
  }
  return exportsMap;
};

const exportsMap = parseFacadeExports(facadeSource);
const internalToPublic = new Map(
  Array.from(exportsMap.entries()).map(([publicName, internalName]) => [internalName, publicName]),
);

const parseFlattenedFunctions = (source) => {
  const functions = [];
  const fnRe =
    /^export\s+declare\s+function\s+([A-Za-z0-9_$]+)\s*\(([^)]*)\):\s*([^;]+);\s*$/gm;
  let match;
  while ((match = fnRe.exec(source))) {
    functions.push(match[0].trim());
  }
  return functions;
};

const flattenedFunctions = parseFlattenedFunctions(facadeSource);

const getDeclarationRange = (source, startIndex) => {
  const length = source.length;

  const isWhitespace = (char) => char === " " || char === "\t" || char === "\n" || char === "\r";

  const startBrace = source.indexOf("{", startIndex);
  if (startBrace === -1) return undefined;

  let index = startBrace;
  let depth = 0;
  let inSingleQuote = false;
  let inDoubleQuote = false;
  let inLineComment = false;
  let inBlockComment = false;

  while (index < length) {
    const char = source[index];
    const next = index + 1 < length ? source[index + 1] : "";

    if (inLineComment) {
      if (char === "\n") inLineComment = false;
      index += 1;
      continue;
    }

    if (inBlockComment) {
      if (char === "*" && next === "/") {
        inBlockComment = false;
        index += 2;
        continue;
      }
      index += 1;
      continue;
    }

    if (!inSingleQuote && !inDoubleQuote) {
      if (char === "/" && next === "/") {
        inLineComment = true;
        index += 2;
        continue;
      }
      if (char === "/" && next === "*") {
        inBlockComment = true;
        index += 2;
        continue;
      }
    }

    if (!inDoubleQuote && char === "'" && source[index - 1] !== "\\") {
      inSingleQuote = !inSingleQuote;
      index += 1;
      continue;
    }

    if (!inSingleQuote && char === "\"" && source[index - 1] !== "\\") {
      inDoubleQuote = !inDoubleQuote;
      index += 1;
      continue;
    }

    if (inSingleQuote || inDoubleQuote) {
      index += 1;
      continue;
    }

    if (char === "{") depth += 1;
    if (char === "}") {
      depth -= 1;
      if (depth === 0) {
        let endIndex = index + 1;
        while (endIndex < length && isWhitespace(source[endIndex])) endIndex += 1;
        if (source[endIndex] === ";") endIndex += 1;
        return { start: startIndex, end: endIndex };
      }
    }
    index += 1;
  }

  return undefined;
};

const extractExportBlock = (source, startMarker) => {
  const startIndex = source.indexOf(startMarker);
  if (startIndex === -1) return undefined;
  const range = getDeclarationRange(source, startIndex);
  if (!range) return undefined;
  return source.slice(range.start, range.end).trimEnd();
};

const extractExportLine = (source, linePrefix) => {
  const startIndex = source.indexOf(linePrefix);
  if (startIndex === -1) return undefined;
  const lineEnd = source.indexOf("\n", startIndex);
  return source
    .slice(startIndex, lineEnd === -1 ? source.length : lineEnd)
    .trimEnd();
};

const escapeRegExp = (text) => text.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");

const replaceIdentifier = (source, from, to) => {
  if (from === to) return source;
  const fromInstance = `${from}$instance`;
  let result = source.replace(
    new RegExp(`\\b${escapeRegExp(fromInstance)}\\b`, "g"),
    to,
  );
  result = result.replace(new RegExp(`\\b${escapeRegExp(from)}\\b`, "g"), to);
  return result;
};

const applyExportRenames = (source) => {
  const candidates = Array.from(internalToPublic.entries())
    .filter(([internalName, publicName]) => internalName !== publicName)
    .filter(([internalName]) => /^[A-Za-z0-9_]+$/.test(internalName))
    .sort((a, b) => b[0].length - a[0].length);

  let result = source;
  for (const [internalName, publicName] of candidates) {
    result = replaceIdentifier(result, internalName, publicName);
  }
  return result;
};

const renderStaticContainer = (block, publicName, internalName) => {
  const lines = block.split("\n");
  const openBraceIndex = lines.findIndex((line) => line.includes("{"));
  const closeBraceIndex = lines.findLastIndex((line) => line.includes("}"));
  const bodyLines =
    openBraceIndex === -1 || closeBraceIndex === -1
      ? []
      : lines.slice(openBraceIndex + 1, closeBraceIndex);

  const renderedBody = bodyLines
    .map((line) =>
      line
        .replace(/^\s*static\s+readonly\s+/, "readonly ")
        .replace(/^\s*static\s+/, "")
        .trimEnd(),
    )
    .filter((line) => line.trim().length > 0)
    .map((line) => `  ${line.trimStart()}`)
    .join("\n");

  const headerComment = internalName.endsWith("$instance") ? "" : `// from ${internalName}\n`;
  return applyExportRenames(
    `${headerComment}export declare const ${publicName}: {\n${renderedBody}\n};`,
  );
};

const renderTypeLike = (publicName, internalName) => {
  const instanceName = `${internalName}$instance`;
  const interfaceMarker = `export interface ${instanceName}`;
  const abstractClassMarker = `export abstract class ${instanceName}`;
  const classMarker = `export class ${instanceName}`;

  const instanceBlock =
    extractExportBlock(internalSource, interfaceMarker) ??
    extractExportBlock(internalSource, abstractClassMarker) ??
    extractExportBlock(internalSource, classMarker);

  if (!instanceBlock) {
    const typeAliasLine = extractExportLine(internalSource, `export type ${internalName} =`);
    if (typeAliasLine) {
      return applyExportRenames(replaceIdentifier(typeAliasLine, internalName, publicName));
    }
    return undefined;
  }

  const constBlock = extractExportBlock(internalSource, `export const ${internalName}:`);

  const cleanedInstance = applyExportRenames(
    replaceIdentifier(instanceBlock.replace(instanceName, publicName), internalName, publicName),
  );

  const cleanedConst = constBlock
    ? applyExportRenames(replaceIdentifier(constBlock, internalName, publicName))
    : undefined;

  return [cleanedInstance, cleanedConst].filter(Boolean).join("\n\n");
};

const renderExport = (publicName) => {
  const internalName = exportsMap.get(publicName);
  if (!internalName) return undefined;

  if (internalName.endsWith("$instance")) {
    const block = extractExportBlock(internalSource, `export abstract class ${internalName}`);
    if (!block) return undefined;
    return renderStaticContainer(block, publicName, internalName);
  }

  const instanceBlock =
    extractExportBlock(internalSource, `export abstract class ${internalName}$instance`) ??
    extractExportBlock(internalSource, `export interface ${internalName}$instance`) ??
    extractExportBlock(internalSource, `export class ${internalName}$instance`);

  if (!instanceBlock) return undefined;

  if (instanceBlock.startsWith("export abstract class")) {
    return renderStaticContainer(instanceBlock, publicName, internalName);
  }

  return renderTypeLike(publicName, internalName);
};

const docsModulesDir = path.resolve(repoRoot, "docs/modules");

const pageSymbols = new Map([
  ["console", ["console"]],
  ["json", ["JSON"]],
  ["math", ["Math"]],
  ["timers", ["Timers"]],
  ["globals", ["Globals"]],
  ["collections", ["Map", "Set", "WeakMap", "WeakSet"]],
  [
    "typed-arrays",
    [
      "ArrayBuffer",
      "Int8Array",
      "Uint8Array",
      "Uint8ClampedArray",
      "Int16Array",
      "Uint16Array",
      "Int32Array",
      "Uint32Array",
      "Float32Array",
      "Float64Array",
    ],
  ],
  ["date", ["Date"]],
  ["number", ["Number"]],
  ["string", ["String"]],
  ["regexp", ["RegExp", "RegExpMatchResult"]],
  ["jsarray", ["JSArray"]],
]);

const renderPageApi = (pageName) => {
  const symbols = pageSymbols.get(pageName) ?? [];
  const sections = [];
  for (const symbol of symbols) {
    const rendered = renderExport(symbol);
    if (!rendered) continue;
    sections.push(`### \`${symbol}\`\n\n\`\`\`ts\n${rendered}\n\`\`\``);
  }

  if (pageName === "globals" && flattenedFunctions.length) {
    sections.push(
      `### Global functions\n\n\`\`\`ts\n${flattenedFunctions.join("\n")}\n\`\`\``,
    );
  }

  return sections.join("\n\n");
};

const injectApiIntoDoc = (docPath, apiMarkdown) => {
  const source = readText(docPath);
  const startToken = "<!-- API:START -->";
  const endToken = "<!-- API:END -->";

  const apiBlock = `${startToken}\n${apiMarkdown}\n${endToken}`;

  if (source.includes(startToken) && source.includes(endToken)) {
    const before = source.split(startToken)[0].trimEnd();
    const after = source.split(endToken)[1].trimStart();
    const updated = `${before}\n\n${apiBlock}\n\n${after}`.trimEnd() + "\n";
    fs.writeFileSync(docPath, updated, "utf8");
    return;
  }

  fs.writeFileSync(
    docPath,
    source.trimEnd() + `\n\n## API Reference\n\n${apiBlock}\n`,
    "utf8",
  );
};

for (const pageName of pageSymbols.keys()) {
  const docPath = path.resolve(docsModulesDir, `${pageName}.md`);
  if (!exists(docPath)) continue;
  const apiMarkdown = renderPageApi(pageName);
  injectApiIntoDoc(docPath, apiMarkdown);
}

const collectAliasedGenericNames = (exportMap) => {
  const aliased = [];
  for (const [publicName, internalName] of exportMap.entries()) {
    if (publicName === internalName) continue;
    if (!/_\d+$/.test(internalName)) continue;
    aliased.push({ publicName, internalName });
  }
  return aliased;
};

const assertDocsHideAliasedGenerics = (docPaths, aliasedGenericNames) => {
  if (aliasedGenericNames.length === 0) return;

  const escaped = aliasedGenericNames
    .map(({ internalName }) => escapeRegExp(internalName))
    .join("|");
  const needle = new RegExp(`\\b(?:${escaped})\\b`, "g");

  const failures = [];
  for (const docPath of docPaths) {
    const contents = readText(docPath);
    const matches = contents.match(needle);
    if (matches?.length) {
      failures.push({ docPath, matches: Array.from(new Set(matches)).sort() });
    }
  }

  if (failures.length) {
    console.error("Docs leaked internal generic-arity names (expected facade names instead):");
    for (const failure of failures) {
      console.error(`  - ${path.relative(repoRoot, failure.docPath)}: ${failure.matches.join(", ")}`);
    }
    process.exit(1);
  }
};

assertDocsHideAliasedGenerics(
  Array.from(pageSymbols.keys()).map((pageName) => path.resolve(docsModulesDir, `${pageName}.md`)),
  collectAliasedGenericNames(exportsMap),
);

console.log(`Updated API reference sections for ${pageSymbols.size} pages.`);
