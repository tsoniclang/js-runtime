# Getting Started

## Enable JS Runtime APIs in a Tsonic Project

### New project

```bash
npx --yes tsonic@latest init --surface js
npx --yes tsonic@latest add npm @tsonic/js
```

### Existing project

```bash
npx --yes tsonic@latest add npm @tsonic/js
```

If you have `tsonic` installed globally, you can drop the `npx --yes tsonic@latest` prefix.

That will:

- Install the `@tsonic/js` bindings package in your workspace (`package.json`) for `tsc` typechecking
- Apply the package’s `.NET` dependency manifest (`tsonic.bindings.json`) to `tsonic.workspace.json`
  - Adds the required `dotnet.frameworkReferences` / `dotnet.packageReferences`
  - Installs any additional `types` packages referenced by the manifest

Then run `npx --yes tsonic@latest restore` (or `npx --yes tsonic@latest build`) to materialize .NET dependencies.

## Minimal Example

```ts
export function main(): void {
  const obj = JSON.parse<{ ok: boolean }>('{"ok": true}');
  console.log(obj.ok);
}
```

Direct imports from `@tsonic/js/index.js` remain supported when you want explicit symbols.
