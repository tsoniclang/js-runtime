# `Timers`

Import:

```ts
import { Timers } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, Timers } from "@tsonic/js/index.js";
import { Thread } from "@tsonic/dotnet/System.Threading.js";

export function main(): void {
  Timers.setTimeout(() => console.log("tick"), 50);
  Thread.sleep(100);
}
```

