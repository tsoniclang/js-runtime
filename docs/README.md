# JavaScript Runtime Compatibility (`@tsonic/js`)

Tsonic targets the .NET BCL by default. If you want **JavaScript-style runtime APIs** (like `JSON`, `Math`, timers, `Date`, `RegExp`, JS arrays, etc.), use `@tsonic/js`.

This is **not** Node.js. It’s a JS-semantics runtime implemented in .NET so TypeScript code can opt into familiar JavaScript behavior where needed.

## Table of Contents

### Getting Started

1. [Getting Started](getting-started.md) - enable `@tsonic/js` in a Tsonic project
2. [Importing APIs](imports.md) - importing from `@tsonic/js/index.js`

### APIs

3. [console](modules/console.md)
4. [JSON](modules/json.md)
5. [Math](modules/math.md)
6. [Timers](modules/timers.md)
7. [Globals](modules/globals.md) (global functions like `parseInt`)
8. [JSArray](modules/jsarray.md)
9. [Map/Set/WeakMap/WeakSet](modules/collections.md)
10. [ArrayBuffer + Typed Arrays](modules/typed-arrays.md)
11. [Date](modules/date.md)
12. [RegExp](modules/regexp.md)
13. [Number](modules/number.md)
14. [String](modules/string.md)

## Overview

In Tsonic projects you import JS runtime APIs from `@tsonic/js/index.js`:

```ts
import { console, JSON } from "@tsonic/js/index.js";

export function main(): void {
  const value = JSON.parse<{ x: number }>('{"x": 1}');
  console.log(JSON.stringify(value));
}
```

## Relationship to `@tsonic/nodejs`

- `@tsonic/js` provides JavaScript runtime APIs (JSON, Math, Date, timers, JS collections).
- `@tsonic/nodejs` provides Node-style APIs (fs/path/http/crypto/process, etc.) implemented on .NET.

You can enable either or both in a project.
