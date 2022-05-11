## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/SortNumbers.cs)

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
|      Method |        nums |             Mean |          Error |         StdDev |           Median |      Ratio |  RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------ |------------ |-----------------:|---------------:|---------------:|-----------------:|-----------:|---------:|--------:|-------:|----------:|
|  BubbleSort |    Int32[5] |         10.54 ns |       0.127 ns |       0.118 ns |         10.49 ns |       0.34 |     0.00 |       - |      - |         - |
|   ArraySort |    Int32[5] |         30.56 ns |       0.455 ns |       0.426 ns |         30.56 ns |       1.00 |     0.00 |       - |      - |         - |
|   QuickSort |    Int32[5] |         31.87 ns |       0.685 ns |       1.107 ns |         31.34 ns |       1.05 |     0.05 |       - |      - |         - |
|   MergeSort |    Int32[5] |         77.81 ns |       1.584 ns |       2.774 ns |         79.70 ns |       2.52 |     0.09 |  0.0274 |      - |     144 B |
|    ListSort |    Int32[5] |        117.57 ns |       2.383 ns |       3.181 ns |        116.76 ns |       3.85 |     0.12 |  0.0168 |      - |      88 B |
|   ArraySort |   Int32[50] |        204.35 ns |       2.036 ns |       1.904 ns |        204.18 ns |       6.69 |     0.12 |       - |      - |         - |
| LinqOrderBy |    Int32[5] |        288.01 ns |       5.674 ns |       7.767 ns |        289.65 ns |       9.44 |     0.35 |  0.0553 |      - |     292 B |
|    ListSort |   Int32[50] |        415.84 ns |       6.731 ns |       6.296 ns |        412.27 ns |      13.61 |     0.24 |  0.0854 |      - |     449 B |
|   MergeSort |   Int32[50] |      1,330.91 ns |      26.450 ns |      37.934 ns |      1,310.10 ns |      43.47 |     1.36 |  0.4425 |      - |   2,323 B |
|   QuickSort |   Int32[50] |      1,661.87 ns |      10.325 ns |       9.658 ns |      1,662.12 ns |      54.39 |     0.83 |       - |      - |         - |
|  BubbleSort |   Int32[50] |      1,681.69 ns |      15.263 ns |      14.277 ns |      1,683.96 ns |      55.04 |     0.92 |       - |      - |         - |
| LinqOrderBy |   Int32[50] |      2,273.76 ns |      44.881 ns |      64.367 ns |      2,306.85 ns |      74.26 |     2.56 |  0.2823 |      - |   1,498 B |
|   ArraySort |  Int32[500] |      2,392.83 ns |      16.136 ns |      15.094 ns |      2,392.84 ns |      78.31 |     1.03 |       - |      - |         - |
|    ListSort |  Int32[500] |      4,717.55 ns |      42.837 ns |      40.070 ns |      4,726.05 ns |     154.40 |     2.79 |  0.7706 | 0.0076 |   4,055 B |
|   MergeSort |  Int32[500] |     18,333.64 ns |     358.523 ns |     578.948 ns |     18,637.12 ns |     602.53 |    22.62 |  5.7068 |      - |  29,973 B |
| LinqOrderBy |  Int32[500] |     28,383.52 ns |     256.273 ns |     200.081 ns |     28,338.62 ns |     925.82 |    12.80 |  2.3499 | 0.0305 |  12,336 B |
|   ArraySort | Int32[5000] |     33,014.08 ns |     292.309 ns |     273.426 ns |     32,920.84 ns |   1,080.53 |    18.43 |       - |      - |         - |
|    ListSort | Int32[5000] |     57,527.91 ns |     323.111 ns |     302.238 ns |     57,541.11 ns |   1,882.82 |    27.73 |  7.6294 | 0.7935 |  40,111 B |
|   QuickSort |  Int32[500] |    113,407.07 ns |   1,613.527 ns |   1,509.294 ns |    112,975.92 ns |   3,711.61 |    66.66 |       - |      - |         - |
|  BubbleSort |  Int32[500] |    118,276.34 ns |   1,191.404 ns |   1,114.440 ns |    118,209.97 ns |   3,871.17 |    71.71 |       - |      - |         - |
|   MergeSort | Int32[5000] |    228,284.49 ns |   3,915.302 ns |   3,662.375 ns |    230,418.60 ns |   7,471.07 |   135.36 | 70.0684 |      - | 367,754 B |
| LinqOrderBy | Int32[5000] |    360,962.44 ns |   1,270.697 ns |   1,188.611 ns |    360,969.29 ns |  11,813.87 |   166.05 | 27.3438 | 2.9297 | 145,932 B |
|   QuickSort | Int32[5000] | 10,680,998.44 ns | 132,436.802 ns | 123,881.467 ns | 10,645,279.69 ns | 349,587.54 | 6,898.35 |       - |      - |         - |
|  BubbleSort | Int32[5000] | 11,512,367.34 ns |  99,030.166 ns |  92,632.879 ns | 11,509,030.47 ns | 376,787.07 | 6,038.40 |       - |      - |         - |
