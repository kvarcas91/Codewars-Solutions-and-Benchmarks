## Challenge

Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

It should remove all values from list *a*, which are present in list *b* keeping their order.

```c#
Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
```

If a value is present in *b*, all of its occurrences must be removed from the other:
```c#
Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                        Method |          a |          b |         Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------------------------ |----------- |----------- |-------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|
|                 DoubleForLoop |  Int32[20] |   Int32[5] |     210.2 ns |     4.22 ns |     7.38 ns |   0.43 |    0.02 | 0.0465 |      - |     244 B |
|          ForEachWithRemoveAll |  Int32[20] |   Int32[5] |     486.5 ns |     7.74 ns |     6.86 ns |   1.00 |    0.00 | 0.0772 |      - |     409 B |
| LinqWhereAndContainsInHashset |  Int32[20] |   Int32[5] |     561.9 ns |    11.21 ns |    18.42 ns |   1.15 |    0.04 | 0.0935 |      - |     493 B |
|       ArrayFindAllAndContains |  Int32[20] |   Int32[5] |     921.1 ns |    20.11 ns |    56.39 ns |   1.82 |    0.06 | 0.0534 |      - |     288 B |
|          LinqWhereAndContains |  Int32[20] |   Int32[5] |     927.3 ns |    17.88 ns |    22.61 ns |   1.90 |    0.05 | 0.0563 |      - |     296 B |
| LinqWhereAndContainsInHashset |  Int32[50] |  Int32[20] |   1,275.1 ns |    23.99 ns |    51.65 ns |   2.57 |    0.11 | 0.1793 |      - |     949 B |
|                 DoubleForLoop |  Int32[50] |  Int32[20] |   1,370.5 ns |    26.91 ns |    33.05 ns |   2.83 |    0.06 | 0.0839 |      - |     445 B |
| LinqWhereAndContainsInHashset | Int32[100] |  Int32[50] |   2,201.2 ns |    23.00 ns |    21.51 ns |   4.53 |    0.04 | 0.3548 |      - |   1,875 B |
|       ArrayFindAllAndContains |  Int32[50] |  Int32[20] |   2,340.5 ns |    46.76 ns |   113.83 ns |   4.67 |    0.27 | 0.0916 |      - |     489 B |
|          LinqWhereAndContains |  Int32[50] |  Int32[20] |   2,454.0 ns |    47.88 ns |    79.99 ns |   5.04 |    0.20 | 0.0916 |      - |     497 B |
|          ForEachWithRemoveAll |  Int32[50] |  Int32[20] |   3,163.9 ns |    62.97 ns |   145.94 ns |   6.49 |    0.38 | 0.2365 |      - |   1,250 B |
|                 DoubleForLoop | Int32[100] |  Int32[50] |   4,775.0 ns |    23.30 ns |    21.79 ns |   9.81 |    0.12 | 0.1450 |      - |     793 B |
|       ArrayFindAllAndContains | Int32[100] |  Int32[50] |   5,482.4 ns |    38.64 ns |    34.25 ns |  11.27 |    0.17 | 0.1526 |      - |     837 B |
|          LinqWhereAndContains | Int32[100] |  Int32[50] |   5,619.9 ns |    19.06 ns |    17.83 ns |  11.56 |    0.17 | 0.1602 |      - |     845 B |
| LinqWhereAndContainsInHashset | Int32[500] | Int32[200] |  10,185.7 ns |   201.38 ns |   231.91 ns |  20.92 |    0.51 | 1.7853 | 0.0305 |   9,387 B |
|          ForEachWithRemoveAll | Int32[100] |  Int32[50] |  11,304.4 ns |    19.48 ns |    18.22 ns |  23.24 |    0.33 | 0.5341 |      - |   2,852 B |
|       ArrayFindAllAndContains | Int32[500] | Int32[200] |  61,419.5 ns | 1,177.39 ns | 1,209.09 ns | 126.35 |    3.06 | 0.9766 |      - |   5,465 B |
|          LinqWhereAndContains | Int32[500] | Int32[200] |  62,311.0 ns |   885.92 ns |   828.69 ns | 128.07 |    2.53 | 0.9766 |      - |   5,473 B |
|                 DoubleForLoop | Int32[500] | Int32[200] |  78,655.5 ns |   957.50 ns |   848.80 ns | 161.71 |    2.88 | 0.9766 |      - |   5,420 B |
|          ForEachWithRemoveAll | Int32[500] | Int32[200] | 220,286.0 ns | 4,329.48 ns | 8,131.82 ns | 453.47 |   21.40 | 2.1973 |      - |  12,067 B |
