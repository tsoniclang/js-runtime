# `Number`

Import:

```ts
import { Number } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, Number } from "@tsonic/js/index.js";

export function main(): void {
  console.log(Number.isNaN(Number.naN));
  console.log(Number.parseInt("10"));
}
```

## API Reference

<!-- API:START -->
### `Number`

```ts
export declare const Number: {
  readonly MAX_VALUE: double;
  readonly MIN_VALUE: double;
  readonly MAX_SAFE_INTEGER: double;
  readonly MIN_SAFE_INTEGER: double;
  readonly POSITIVE_INFINITY: double;
  readonly NEGATIVE_INFINITY: double;
  readonly naN: double;
  readonly EPSILON: double;
  isFinite(value: double): boolean;
  isInteger(value: double): boolean;
  isNaN(value: double): boolean;
  isSafeInteger(value: double): boolean;
  parseFloat(str: string): double;
  parseInt(str: string, radix?: Nullable<System_Internal.Int32>): Nullable<System_Internal.Int64>;
};
```
<!-- API:END -->
