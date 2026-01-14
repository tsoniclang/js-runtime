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

## API Reference

<!-- API:START -->
### `Timers`

```ts
export declare const Timers: {
  clearInterval(id: int): void;
  clearTimeout(id: int): void;
  setInterval<T>(callback: Action<T>, intervalMs: int, arg: T): int;
  setInterval(callback: Action, intervalMs: int): int;
  setTimeout<T>(callback: Action<T>, delayMs: int, arg: T): int;
  setTimeout(callback: Action, delayMs?: int): int;
};
```
<!-- API:END -->
