# `JSON`

Import:

```ts
import { JSON } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, JSON } from "@tsonic/js/index.js";

export function main(): void {
  const value = JSON.parse<{ x: number }>('{"x": 1}');
  console.log(value.x);
  console.log(JSON.stringify(value));
}
```

