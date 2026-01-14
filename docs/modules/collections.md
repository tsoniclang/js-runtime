# Collections (`Map`, `Set`, `WeakMap`, `WeakSet`)

Import:

```ts
import { Map, Set } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, Map, Set } from "@tsonic/js/index.js";

export function main(): void {
  const m = new Map<string, number>();
  m.set_("a", 1);
  console.log(m.get_("a"));

  const s = new Set<number>();
  s.add(1);
  console.log(s.has(1));
}
```

Note: some methods are suffixed with `_` (example: `set_`, `get_`, `delete_`) to avoid clashes with reserved words and runtime naming rules.

