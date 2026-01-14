# `console`

Import:

```ts
import { console } from "@tsonic/js/index.js";
```

Example:

```ts
import { console } from "@tsonic/js/index.js";

export function main(): void {
  console.log("hello");
  console.warn("warn");
  console.error("error");
}
```

## API Reference

<!-- API:START -->
### `console`

```ts
export declare const console: {
  assert(condition: boolean, message?: string): void;
  clear(): void;
  count(label?: string): void;
  countReset(label?: string): void;
  debug(...data: unknown[]): void;
  dir(obj: unknown): void;
  dirxml(obj: unknown): void;
  error(...data: unknown[]): void;
  group(...data: unknown[]): void;
  groupCollapsed(...data: unknown[]): void;
  groupEnd(): void;
  info(...data: unknown[]): void;
  log(...data: unknown[]): void;
  table(data: unknown): void;
  time(label?: string): void;
  timeEnd(label?: string): void;
  timeLog(label?: string, ...data: unknown[]): void;
  trace(...data: unknown[]): void;
  warn(...data: unknown[]): void;
};
```
<!-- API:END -->
