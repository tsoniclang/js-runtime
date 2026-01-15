# `ArrayBuffer` + Typed Arrays

Import:

```ts
import { Uint8Array } from "@tsonic/js/index.js";
import { byte } from "@tsonic/core/types.js";
```

Example:

```ts
import { console, Uint8Array } from "@tsonic/js/index.js";
import { byte } from "@tsonic/core/types.js";

export function main(): void {
  const view = new Uint8Array(4);
  view.fill(255 as byte);
  console.log(view.at(0));
}
```

## API Reference

<!-- API:START -->
### `ArrayBuffer`

```ts
export interface ArrayBuffer {
    readonly byteLength: int;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): ArrayBuffer;
}

export const ArrayBuffer: {
    new(byteLength: int): ArrayBuffer;
};
```

### `Int8Array`

```ts
export interface Int8Array {
    readonly byteLength: int;
    item: sbyte;
    readonly length: int;
    at(index: int): Nullable<System_Internal.SByte>;
    fill(value: sbyte, start?: int, end?: Nullable<System_Internal.Int32>): Int8Array;
    getEnumerator(): IEnumerator<System_Internal.SByte>;
    includes(value: sbyte, fromIndex?: int): boolean;
    indexOf(value: sbyte, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Int8Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.SByte>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Int8Array;
    sort(compareFn?: Comparison<System_Internal.SByte>): Int8Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Int8Array;
}

export const Int8Array: {
    new(length: int): Int8Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.SByte>): Int8Array;
    new(values: sbyte[]): Int8Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Uint8Array`

```ts
export interface Uint8Array {
    readonly byteLength: int;
    item: byte;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Byte>;
    fill(value: byte, start?: int, end?: Nullable<System_Internal.Int32>): Uint8Array;
    getEnumerator(): IEnumerator<System_Internal.Byte>;
    includes(value: byte, fromIndex?: int): boolean;
    indexOf(value: byte, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Uint8Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Byte>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Uint8Array;
    sort(compareFn?: Comparison<System_Internal.Byte>): Uint8Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Uint8Array;
}

export const Uint8Array: {
    new(length: int): Uint8Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Byte>): Uint8Array;
    new(values: byte[]): Uint8Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Uint8ClampedArray`

```ts
export interface Uint8ClampedArray {
    readonly byteLength: int;
    item: byte;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Byte>;
    fill(value: byte, start?: int, end?: Nullable<System_Internal.Int32>): Uint8ClampedArray;
    getEnumerator(): IEnumerator<System_Internal.Byte>;
    includes(value: byte, fromIndex?: int): boolean;
    indexOf(value: byte, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Uint8ClampedArray;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Byte>, offset?: int): void;
    setClamped(index: int, value: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Uint8ClampedArray;
    sort(compareFn?: Comparison<System_Internal.Byte>): Uint8ClampedArray;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Uint8ClampedArray;
}

export const Uint8ClampedArray: {
    new(length: int): Uint8ClampedArray;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Byte>): Uint8ClampedArray;
    new(values: byte[]): Uint8ClampedArray;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Int16Array`

```ts
export interface Int16Array {
    readonly byteLength: int;
    item: short;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Int16>;
    fill(value: short, start?: int, end?: Nullable<System_Internal.Int32>): Int16Array;
    getEnumerator(): IEnumerator<System_Internal.Int16>;
    includes(value: short, fromIndex?: int): boolean;
    indexOf(value: short, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Int16Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Int16>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Int16Array;
    sort(compareFn?: Comparison<System_Internal.Int16>): Int16Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Int16Array;
}

export const Int16Array: {
    new(length: int): Int16Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Int16>): Int16Array;
    new(values: short[]): Int16Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Uint16Array`

```ts
export interface Uint16Array {
    readonly byteLength: int;
    item: ushort;
    readonly length: int;
    at(index: int): Nullable<System_Internal.UInt16>;
    fill(value: ushort, start?: int, end?: Nullable<System_Internal.Int32>): Uint16Array;
    getEnumerator(): IEnumerator<System_Internal.UInt16>;
    includes(value: ushort, fromIndex?: int): boolean;
    indexOf(value: ushort, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Uint16Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.UInt16>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Uint16Array;
    sort(compareFn?: Comparison<System_Internal.UInt16>): Uint16Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Uint16Array;
}

export const Uint16Array: {
    new(length: int): Uint16Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.UInt16>): Uint16Array;
    new(values: ushort[]): Uint16Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Int32Array`

```ts
export interface Int32Array {
    readonly byteLength: int;
    item: int;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Int32>;
    fill(value: int, start?: int, end?: Nullable<System_Internal.Int32>): Int32Array;
    getEnumerator(): IEnumerator<System_Internal.Int32>;
    includes(value: int, fromIndex?: int): boolean;
    indexOf(value: int, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Int32Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Int32>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Int32Array;
    sort(compareFn?: Comparison<System_Internal.Int32>): Int32Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Int32Array;
}

export const Int32Array: {
    new(length: int): Int32Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Int32>): Int32Array;
    new(values: int[]): Int32Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Uint32Array`

```ts
export interface Uint32Array {
    readonly byteLength: int;
    item: uint;
    readonly length: int;
    at(index: int): Nullable<System_Internal.UInt32>;
    fill(value: uint, start?: int, end?: Nullable<System_Internal.Int32>): Uint32Array;
    getEnumerator(): IEnumerator<System_Internal.UInt32>;
    includes(value: uint, fromIndex?: int): boolean;
    indexOf(value: uint, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Uint32Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.UInt32>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Uint32Array;
    sort(compareFn?: Comparison<System_Internal.UInt32>): Uint32Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Uint32Array;
}

export const Uint32Array: {
    new(length: int): Uint32Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.UInt32>): Uint32Array;
    new(values: uint[]): Uint32Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Float32Array`

```ts
export interface Float32Array {
    readonly byteLength: int;
    item: float;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Single>;
    fill(value: float, start?: int, end?: Nullable<System_Internal.Int32>): Float32Array;
    getEnumerator(): IEnumerator<System_Internal.Single>;
    includes(value: float, fromIndex?: int): boolean;
    indexOf(value: float, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Float32Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Single>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Float32Array;
    sort(compareFn?: Comparison<System_Internal.Single>): Float32Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Float32Array;
}

export const Float32Array: {
    new(length: int): Float32Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Single>): Float32Array;
    new(values: float[]): Float32Array;
    readonly BYTES_PER_ELEMENT: int;
};
```

### `Float64Array`

```ts
export interface Float64Array {
    readonly byteLength: int;
    item: double;
    readonly length: int;
    at(index: int): Nullable<System_Internal.Double>;
    fill(value: double, start?: int, end?: Nullable<System_Internal.Int32>): Float64Array;
    getEnumerator(): IEnumerator<System_Internal.Double>;
    includes(value: double, fromIndex?: int): boolean;
    indexOf(value: double, fromIndex?: int): int;
    join(separator?: string): string;
    reverse(): Float64Array;
    set(array: IEnumerable__System_Collections_Generic<System_Internal.Double>, offset?: int): void;
    slice(begin?: int, end?: Nullable<System_Internal.Int32>): Float64Array;
    sort(compareFn?: Comparison<System_Internal.Double>): Float64Array;
    subarray(begin?: int, end?: Nullable<System_Internal.Int32>): Float64Array;
}

export const Float64Array: {
    new(length: int): Float64Array;
    new(values: IEnumerable__System_Collections_Generic<System_Internal.Double>): Float64Array;
    new(values: double[]): Float64Array;
    readonly BYTES_PER_ELEMENT: int;
};
```
<!-- API:END -->
