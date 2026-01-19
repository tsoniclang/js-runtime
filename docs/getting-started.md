# Getting Started

## Enable JS Runtime APIs in a Tsonic Project

### New project

```bash
tsonic init --js
```

### Existing project

```bash
tsonic add js
```

That will:

- Install the `@tsonic/js` bindings package in your workspace (`package.json`) for `tsc` typechecking
- Copy `libs/Tsonic.JSRuntime.dll` into your workspace
- Add `libs/Tsonic.JSRuntime.dll` to `tsonic.workspace.json` under `dotnet.libraries`

## Minimal Example

```ts
import { console, JSON } from "@tsonic/js/index.js";

export function main(): void {
  const obj = JSON.parse<{ ok: boolean }>('{"ok": true}');
  console.log(obj.ok);
}
```
