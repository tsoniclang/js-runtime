# Importing APIs

In `--surface js`, you can use JS builtins directly:

```ts
export function main(): void {
  console.log(JSON.stringify({ ok: true }));
}
```

Direct imports are still supported when you want explicit symbols:

```ts
import { console, JSON, Math, Timers } from "@tsonic/js/index.js";
```

This is a **Tsonic-specific** bindings package; it is not the Node/Browser global environment.

If you also want Node-style libraries like `fs` and `path`, use `@tsonic/nodejs` separately:

```ts
import { readFileSync } from "node:fs";
import { join } from "node:path";
```
