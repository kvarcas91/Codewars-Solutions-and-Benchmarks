## Challenge

Finish the solution so that it sorts the passed in array of numbers. If the function passes in an empty array or null/nil value then it should return an empty array.

For example:

```c#
SortNumbers(new int[] { 1, 2, 10, 50, 5 }); // should return new int[] { 1, 2, 5, 10, 50 }
SortNumbers(null); // should return new int[] { }

```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|      Method |       nums |           Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|------------ |----------- |---------------:|------------:|------------:|---------:|--------:|-------:|-------:|----------:|
|  BubbleSort |   Int32[5] |       8.327 ns |   0.0902 ns |   0.0844 ns |     0.27 |    0.00 |      - |      - |         - |
|   ArraySort |   Int32[5] |      30.845 ns |   0.1798 ns |   0.1594 ns |     1.00 |    0.00 |      - |      - |         - |
|   QuickSort |   Int32[5] |      31.782 ns |   0.2784 ns |   0.2468 ns |     1.03 |    0.01 |      - |      - |         - |
|    ListSort |   Int32[5] |     117.802 ns |   1.6139 ns |   1.5097 ns |     3.82 |    0.06 | 0.0168 |      - |      88 B |
|   ArraySort |  Int32[50] |     203.646 ns |   3.4068 ns |   3.1867 ns |     6.60 |    0.11 |      - |      - |         - |
| LinqOrderBy |   Int32[5] |     288.234 ns |   4.3028 ns |   4.0248 ns |     9.34 |    0.14 | 0.0553 |      - |     292 B |
|    ListSort |  Int32[50] |     434.906 ns |   8.6487 ns |  17.0718 ns |    13.93 |    0.60 | 0.0854 |      - |     449 B |
|  BubbleSort |  Int32[50] |   1,119.897 ns |   6.0555 ns |   5.6643 ns |    36.30 |    0.32 |      - |      - |         - |
|   QuickSort |  Int32[50] |   1,710.794 ns |  17.1655 ns |  16.0566 ns |    55.52 |    0.54 |      - |      - |         - |
| LinqOrderBy |  Int32[50] |   2,229.433 ns |  34.1806 ns |  30.3002 ns |    72.28 |    1.11 | 0.2823 |      - |   1,498 B |
|   ArraySort | Int32[500] |   2,378.013 ns |  25.6018 ns |  23.9480 ns |    77.07 |    0.86 |      - |      - |         - |
|    ListSort | Int32[500] |   4,735.347 ns |  75.9967 ns |  71.0873 ns |   153.29 |    2.35 | 0.7706 | 0.0076 |   4,055 B |
| LinqOrderBy | Int32[500] |  28,845.711 ns | 576.1599 ns | 640.4002 ns |   943.48 |   14.61 | 2.3499 | 0.0305 |  12,336 B |
|  BubbleSort | Int32[500] |  64,047.333 ns | 199.3135 ns | 176.6862 ns | 2,076.47 |   11.80 |      - |      - |         - |
|   QuickSort | Int32[500] | 110,998.403 ns | 617.9279 ns | 547.7770 ns | 3,598.69 |   28.93 |      - |      - |         - |
