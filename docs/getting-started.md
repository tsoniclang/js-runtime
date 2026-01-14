# Getting Started

## Enable JS Runtime APIs in a Tsonic Project

### New project

```bash
tsonic project init --js
```

### Existing project

```bash
tsonic add js
```

That will:

- Add the `@tsonic/js` bindings package to your `package.json` (for `tsc` typechecking)
- Copy the `Tsonic.JSRuntime.dll` runtime library into your project (so the generated C# can reference it)
- Update your `tsonic.json` as needed

## Minimal Example

```ts
import { console, JSON } from "@tsonic/js/index.js";

export function main(): void {
  const obj = JSON.parse<{ ok: boolean }>('{"ok": true}');
  console.log(obj.ok);
}
```

