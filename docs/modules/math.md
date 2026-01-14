# `Math`

Import:

```ts
import { Math } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, Math } from "@tsonic/js/index.js";

export function main(): void {
  console.log(Math.floor(1.9));
  console.log(Math.max(1, 10, 3));
}
```

## API Reference

<!-- API:START -->
### `Math`

```ts
export declare const Math: {
  readonly E: double;
  readonly PI: double;
  readonly LN2: double;
  readonly LN10: double;
  readonly LOG2E: double;
  readonly LOG10E: double;
  readonly SQRT1_2: double;
  readonly SQRT2: double;
  abs(x: double): double;
  acos(x: double): double;
  acosh(x: double): double;
  asin(x: double): double;
  asinh(x: double): double;
  atan(x: double): double;
  atan2(y: double, x: double): double;
  atanh(x: double): double;
  cbrt(x: double): double;
  ceil(x: double): long;
  clz32(x: int): int;
  cos(x: double): double;
  cosh(x: double): double;
  exp(x: double): double;
  expm1(x: double): double;
  f16round(x: double): double;
  floor(x: double): long;
  fround(x: double): double;
  hypot(...values: double[]): double;
  imul(a: int, b: int): int;
  log(x: double): double;
  log10(x: double): double;
  log1p(x: double): double;
  log2(x: double): double;
  max(...values: double[]): double;
  min(...values: double[]): double;
  pow(x: double, y: double): double;
  random(): double;
  round(x: double): long;
  sign(x: double): int;
  sin(x: double): double;
  sinh(x: double): double;
  sqrt(x: double): double;
  tan(x: double): double;
  tanh(x: double): double;
  trunc(x: double): long;
};
```
<!-- API:END -->
