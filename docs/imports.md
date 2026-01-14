# Importing APIs

Import JS runtime APIs from `@tsonic/js/index.js`:

```ts
import { console, JSON, Math, Timers } from "@tsonic/js/index.js";
```

This is a **Tsonic-specific** bindings package; it is not the Node/Browser global environment.

If you also want Node-style libraries like `fs` and `path`, use `@tsonic/nodejs` separately:

```ts
import { fs, path } from "@tsonic/nodejs/index.js";
```

