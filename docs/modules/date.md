# `Date`

Import:

```ts
import { Date } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, Date } from "@tsonic/js/index.js";

export function main(): void {
  const now = new Date();
  console.log(now.toISOString());
}
```

