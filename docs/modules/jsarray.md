# `JSArray`

`JSArray<T>` implements JavaScript array semantics (including many familiar methods).

Import:

```ts
import { JSArray } from "@tsonic/js/index.js";
```

Example:

```ts
import { console, JSArray } from "@tsonic/js/index.js";

export function main(): void {
  const xs = new JSArray<number>([1, 2, 3]);
  xs.push(4);
  console.log(xs.join(","));
}
```

## API Reference

<!-- API:START -->
### `JSArray`

```ts
export interface JSArray<T> {
    item: T;
    readonly length: int;
    at(index: int): T;
    concat(...items: unknown[]): JSArray<T>;
    copyWithin(target: int, start?: int, end?: Nullable<System_Internal.Int32>): JSArray<T>;
    entries(): IEnumerable__System_Collections_Generic<ValueTuple<System_Internal.Int32, T>>;
    every(callback: Func<T, System_Internal.Boolean>): boolean;
    every(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): boolean;
    fill(value: T, start?: int, end?: Nullable<System_Internal.Int32>): JSArray<T>;
    filter(callback: Func<T, System_Internal.Boolean>): JSArray<T>;
    filter(callback: Func<T, System_Internal.Int32, System_Internal.Boolean>): JSArray<T>;
    filter(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): JSArray<T>;
    find(callback: Func<T, System_Internal.Boolean>): T;
    find(callback: Func<T, System_Internal.Int32, System_Internal.Boolean>): T;
    find(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): T;
    findIndex(callback: Func<T, System_Internal.Boolean>): int;
    findIndex(callback: Func<T, System_Internal.Int32, System_Internal.Boolean>): int;
    findIndex(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): int;
    findLast(callback: Func<T, System_Internal.Boolean>): T;
    findLast(callback: Func<T, System_Internal.Int32, System_Internal.Boolean>): T;
    findLast(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): T;
    findLastIndex(callback: Func<T, System_Internal.Boolean>): int;
    findLastIndex(callback: Func<T, System_Internal.Int32, System_Internal.Boolean>): int;
    findLastIndex(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): int;
    flat(depth?: int): JSArray<unknown>;
    flatMap<TResult>(callback: Func<T, System_Internal.Int32, JSArray<T>, unknown>): JSArray<TResult>;
    forEach(callback: Action<T>): void;
    forEach(callback: Action<T, System_Internal.Int32>): void;
    forEach(callback: Action<T, System_Internal.Int32, JSArray<T>>): void;
    getEnumerator(): IEnumerator<T>;
    includes(searchElement: T): boolean;
    indexOf(searchElement: T, fromIndex?: int): int;
    join(separator?: string): string;
    keys(): IEnumerable__System_Collections_Generic<System_Internal.Int32>;
    lastIndexOf(searchElement: T, fromIndex?: Nullable<System_Internal.Int32>): int;
    map<TResult>(callback: Func<T, TResult>): JSArray<TResult>;
    map<TResult>(callback: Func<T, System_Internal.Int32, TResult>): JSArray<TResult>;
    map<TResult>(callback: Func<T, System_Internal.Int32, JSArray<T>, TResult>): JSArray<TResult>;
    pop(): T;
    push(item: T): int;
    push(...items: T[]): int;
    reduce<TResult>(callback: Func<TResult, T, TResult>, initialValue: TResult): TResult;
    reduce<TResult>(callback: Func<TResult, T, System_Internal.Int32, TResult>, initialValue: TResult): TResult;
    reduce<TResult>(callback: Func<TResult, T, System_Internal.Int32, JSArray<T>, TResult>, initialValue: TResult): TResult;
    reduce(callback: Func<T, T, T>): T;
    reduceRight<TResult>(callback: Func<TResult, T, TResult>, initialValue: TResult): TResult;
    reduceRight<TResult>(callback: Func<TResult, T, System_Internal.Int32, TResult>, initialValue: TResult): TResult;
    reduceRight<TResult>(callback: Func<TResult, T, System_Internal.Int32, JSArray<T>, TResult>, initialValue: TResult): TResult;
    reverse(): JSArray<T>;
    setLength(newLength: int): void;
    shift(): T;
    slice(start?: int, end?: Nullable<System_Internal.Int32>): JSArray<T>;
    some(callback: Func<T, System_Internal.Boolean>): boolean;
    some(callback: Func<T, System_Internal.Int32, JSArray<T>, System_Internal.Boolean>): boolean;
    sort(compareFunc?: Func<T, T, System_Internal.Double>): JSArray<T>;
    splice(start: int, deleteCount?: Nullable<System_Internal.Int32>, ...items: T[]): JSArray<T>;
    toArray(): T[];
    toList(): List<T>;
    toLocaleString(): string;
    toReversed(): JSArray<T>;
    toSorted(compareFunc?: Func<T, T, System_Internal.Double>): JSArray<T>;
    toSpliced(start: int, deleteCount?: Nullable<System_Internal.Int32>, ...items: T[]): JSArray<T>;
    toString(): string;
    unshift(item: T): int;
    unshift(...items: T[]): int;
    values(): IEnumerable__System_Collections_Generic<T>;
    with(index: int, value: T): JSArray<T>;
}

export const JSArray: {
    new<T>(): JSArray<T>;
    new<T>(capacity: int): JSArray<T>;
    new<T>(source: T[]): JSArray<T>;
    new<T>(source: List<T>): JSArray<T>;
    new<T>(source: IEnumerable__System_Collections_Generic<T>): JSArray<T>;
    from<T, TSource, TResult>(iterable: IEnumerable__System_Collections_Generic<TSource>, mapFunc: Func<TSource, System_Internal.Int32, TResult>): JSArray<TResult>;
    from<T>(iterable: IEnumerable__System_Collections_Generic<T>): JSArray<T>;
    isArray<T>(value: unknown): boolean;
    of<T>(...items: T[]): JSArray<T>;
};
```
<!-- API:END -->
