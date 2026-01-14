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

