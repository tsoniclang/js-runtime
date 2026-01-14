# `ArrayBuffer` + Typed Arrays

Import:

```ts
import { Uint8Array } from "@tsonic/js/index.js";
import { byte } from "@tsonic/core/types.js";
```

Example:

```ts
import { console, Uint8Array } from "@tsonic/js/index.js";
import { byte } from "@tsonic/core/types.js";

export function main(): void {
  const view = new Uint8Array(4);
  view.fill(255 as byte);
  console.log(view.at(0));
}
```
