# `JSArray`

`JSArray<T>` implements JavaScript array semantics (including many familiar methods).

Import:

```ts
import { JSArray } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, JSArray } from "@tsonic/js/index.js";

export function main(): void {
  const xs = new JSArray<number>([1, 2, 3]);
  xs.push(4);
  console.log(xs.join(","));
}
```

