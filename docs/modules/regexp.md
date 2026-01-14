# `RegExp`

Import:

```ts
import { RegExp } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, RegExp } from "@tsonic/js/index.js";

export function main(): void {
  const re = new RegExp("a+", "g");
  console.log(re.test("caaab"));
}
```

