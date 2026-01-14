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

## API Reference

<!-- API:START -->
### `Map`

```ts
export interface Map<K, V> {
    readonly size: int;
    clear(): void;
    delete_(key: K): boolean;
    entries(): IEnumerable__System_Collections_Generic<ValueTuple<K, V>>;
    forEach(callback: Action<V, K, Map<K, V>>): void;
    forEach(callback: Action<V, K>): void;
    forEach(callback: Action<V>): void;
    get_(key: K): V | undefined;
    getEnumerator(): IEnumerator<KeyValuePair<K, V>>;
    has(key: K): boolean;
    keys(): IEnumerable__System_Collections_Generic<K>;
    set_(key: K, value: V): Map<K, V>;
    values(): IEnumerable__System_Collections_Generic<V>;
}

export const Map: {
    new<K, V>(): Map<K, V>;
    new<K, V>(entries: IEnumerable__System_Collections_Generic<ValueTuple<K, V>>): Map<K, V>;
};
```

### `Set`

```ts
export interface Set<T> {
    readonly size: int;
    add(value: T): Set<T>;
    clear(): void;
    delete_(value: T): boolean;
    difference(other: Set<T>): Set<T>;
    entries(): IEnumerable__System_Collections_Generic<ValueTuple<T, T>>;
    forEach(callback: Action<T, T, Set<T>>): void;
    forEach(callback: Action<T, T>): void;
    forEach(callback: Action<T>): void;
    getEnumerator(): IEnumerator<T>;
    has(value: T): boolean;
    intersection(other: Set<T>): Set<T>;
    isDisjointFrom(other: Set<T>): boolean;
    isSubsetOf(other: Set<T>): boolean;
    isSupersetOf(other: Set<T>): boolean;
    keys(): IEnumerable__System_Collections_Generic<T>;
    symmetricDifference(other: Set<T>): Set<T>;
    union(other: Set<T>): Set<T>;
    values(): IEnumerable__System_Collections_Generic<T>;
}

export const Set: {
    new<T>(): Set<T>;
    new<T>(values: IEnumerable__System_Collections_Generic<T>): Set<T>;
};
```

### `WeakMap`

```ts
export interface WeakMap<K, V> {
    delete_(key: K): boolean;
    get_(key: K): V | undefined;
    has(key: K): boolean;
    set_(key: K, value: V): WeakMap<K, V>;
}

export const WeakMap: {
    new<K, V>(): WeakMap<K, V>;
};
```

### `WeakSet`

```ts
export interface WeakSet<T> {
    add(value: T): WeakSet<T>;
    delete_(value: T): boolean;
    has(value: T): boolean;
}

export const WeakSet: {
    new<T>(): WeakSet<T>;
};
```
<!-- API:END -->
