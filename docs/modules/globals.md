# `Globals` (global functions)

Some JS global functions are available as exports from `@tsonic/js/index.js`.

Example:

```ts
import { console, parseInt, parseFloat, encodeURIComponent } from "@tsonic/js/index.js";

export function main(): void {
  console.log(parseInt("42"));
  console.log(parseFloat("3.14"));
  console.log(encodeURIComponent("a b"));
}
```

## API Reference

<!-- API:START -->
### `Globals`

```ts
export declare const Globals: {
  readonly undefined: unknown | undefined;
  readonly infinity: double;
  readonly naN: double;
  boolean_(value: unknown): boolean;
  decodeURI(uri: string): string;
  decodeURIComponent(component: string): string;
  encodeURI(uri: string): string;
  encodeURIComponent(component: string): string;
  isFinite(value: double): boolean;
  isNaN(value: double): boolean;
  number_(value: unknown): double;
  parseFloat(str: string): double;
  parseInt(str: string, radix?: Nullable<System_Internal.Int32>): Nullable<System_Internal.Int64>;
  string_(value: unknown): string;
};
```

### Global functions

```ts
export declare function boolean_(value: unknown): boolean;
export declare function decodeURI(uri: string): string;
export declare function decodeURIComponent(component: string): string;
export declare function encodeURI(uri: string): string;
export declare function encodeURIComponent(component: string): string;
export declare function isFinite(value: double): boolean;
export declare function isNaN(value: double): boolean;
export declare function number_(value: unknown): double;
export declare function parseFloat(str: string): double;
export declare function parseInt(str: string, radix?: Nullable<System_Internal.Int32>): Nullable<System_Internal.Int64>;
export declare function string_(value: unknown): string;
```
<!-- API:END -->
