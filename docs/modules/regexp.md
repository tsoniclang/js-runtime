# `RegExp`

Import:

```ts
import { RegExp } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, RegExp } from "@tsonic/js/index.js";

export function main(): void {
  const re = new RegExp("a+", "g");
  console.log(re.test("caaab"));
}
```

## API Reference

<!-- API:START -->
### `RegExp`

```ts
export interface RegExp {
    readonly dotAll: boolean;
    readonly flags: string;
    readonly global: boolean;
    readonly ignoreCase: boolean;
    lastIndex: int;
    readonly multiline: boolean;
    readonly source: string;
    readonly sticky: boolean;
    readonly unicode: boolean;
    exec(str: string): RegExpMatchResult | undefined;
    test(str: string): boolean;
    toString(): string;
}

export const RegExp: {
    new(pattern: string): RegExp;
    new(pattern: string, flags: string): RegExp;
};
```

### `RegExpMatchResult`

```ts
export interface RegExpMatchResult {
    readonly groups: (string | undefined)[];
    readonly index: int;
    readonly input: string;
    readonly item: string;
    readonly length: int;
    readonly value: string;
}

export const RegExpMatchResult: {
    new(value: string, index: int, input: string, groups: string[]): RegExpMatchResult;
};
```
<!-- API:END -->
