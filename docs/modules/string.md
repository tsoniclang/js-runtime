# `String`

Import:

```ts
import { String } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, String } from "@tsonic/js/index.js";

export function main(): void {
  console.log(String.fromCharCode(65));
  console.log(String.toUpperCase("hello"));
}
```

## API Reference

<!-- API:START -->
### `String`

```ts
export declare const String: {
  at(str: string, index: int): string;
  charAt(str: string, index: int): string;
  charCodeAt(str: string, index: int): int;
  codePointAt(str: string, index: int): int;
  concat(str: string, ...strings: string[]): string;
  endsWith(str: string, searchString: string): boolean;
  fromCharCode(...codes: int[]): string;
  fromCodePoint(...codePoints: int[]): string;
  includes(str: string, searchString: string): boolean;
  indexOf(str: string, searchString: string, position?: int): int;
  isWellFormed(str: string): boolean;
  lastIndexOf(str: string, searchString: string, position?: Nullable<System_Internal.Int32>): int;
  length(str: string): int;
  localeCompare(str: string, compareString: string): int;
  match(str: string, pattern: string): List<System_Internal.String> | undefined;
  matchAll(str: string, pattern: string): List<List<System_Internal.String>>;
  normalize(str: string, form?: string): string;
  padEnd(str: string, targetLength: int, padString?: string): string;
  padStart(str: string, targetLength: int, padString?: string): string;
  raw(template: List<System_Internal.String>, ...substitutions: unknown[]): string;
  repeat(str: string, count: int): string;
  replace(str: string, search: string, replacement: string): string;
  replaceAll(str: string, search: string, replacement: string): string;
  search(str: string, pattern: string): int;
  slice(str: string, start: int, end?: Nullable<System_Internal.Int32>): string;
  split(str: string, separator: string, limit?: Nullable<System_Internal.Int32>): List<System_Internal.String>;
  startsWith(str: string, searchString: string): boolean;
  substr(str: string, start: int, length?: Nullable<System_Internal.Int32>): string;
  substring(str: string, start: int, end?: Nullable<System_Internal.Int32>): string;
  toLocaleLowerCase(str: string): string;
  toLocaleUpperCase(str: string): string;
  toLowerCase(str: string): string;
  toString(str: string): string;
  toUpperCase(str: string): string;
  toWellFormed(str: string): string;
  trim(str: string): string;
  trimEnd(str: string): string;
  trimLeft(str: string): string;
  trimRight(str: string): string;
  trimStart(str: string): string;
  valueOf(str: string): string;
};
```
<!-- API:END -->
