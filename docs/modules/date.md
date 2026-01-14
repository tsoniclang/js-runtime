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

## API Reference

<!-- API:START -->
### `Date`

```ts
export interface Date {
    getDate(): int;
    getDay(): int;
    getFullYear(): int;
    getHours(): int;
    getMilliseconds(): int;
    getMinutes(): int;
    getMonth(): int;
    getSeconds(): int;
    getTime(): long;
    getTimezoneOffset(): int;
    getUTCDate(): int;
    getUTCDay(): int;
    getUTCFullYear(): int;
    getUTCHours(): int;
    getUTCMilliseconds(): int;
    getUTCMinutes(): int;
    getUTCMonth(): int;
    getUTCSeconds(): int;
    setDate(day: int): double;
    setFullYear(year: int, month?: Nullable<System_Internal.Int32>, day?: Nullable<System_Internal.Int32>): double;
    setHours(hour: int, min?: Nullable<System_Internal.Int32>, sec?: Nullable<System_Internal.Int32>, ms?: Nullable<System_Internal.Int32>): double;
    setMilliseconds(ms: int): double;
    setMinutes(min: int, sec?: Nullable<System_Internal.Int32>, ms?: Nullable<System_Internal.Int32>): double;
    setMonth(month: int, day?: Nullable<System_Internal.Int32>): double;
    setSeconds(sec: int, ms?: Nullable<System_Internal.Int32>): double;
    setTime(milliseconds: double): double;
    setUTCDate(day: int): double;
    setUTCFullYear(year: int, month?: Nullable<System_Internal.Int32>, day?: Nullable<System_Internal.Int32>): double;
    setUTCHours(hour: int, min?: Nullable<System_Internal.Int32>, sec?: Nullable<System_Internal.Int32>, ms?: Nullable<System_Internal.Int32>): double;
    setUTCMilliseconds(ms: int): double;
    setUTCMinutes(min: int, sec?: Nullable<System_Internal.Int32>, ms?: Nullable<System_Internal.Int32>): double;
    setUTCMonth(month: int, day?: Nullable<System_Internal.Int32>): double;
    setUTCSeconds(sec: int, ms?: Nullable<System_Internal.Int32>): double;
    toDateString(): string;
    toISOString(): string;
    toJSON(): string;
    toLocaleDateString(): string;
    toLocaleString(): string;
    toLocaleTimeString(): string;
    toString(): string;
    toTimeString(): string;
    toUTCString(): string;
    valueOf(): long;
}

export const Date: {
    new(): Date;
    new(milliseconds: double): Date;
    new(dateString: string): Date;
    new(year: int, month: int, day: int, hours: int, minutes: int, seconds: int, milliseconds: int): Date;
    now(): long;
    parse(dateString: string): double;
    UTC(year: int, month: int, day?: int, hours?: int, minutes?: int, seconds?: int, milliseconds?: int): double;
};
```
<!-- API:END -->
