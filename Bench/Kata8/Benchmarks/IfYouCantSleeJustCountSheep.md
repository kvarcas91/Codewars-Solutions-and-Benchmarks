## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/IfYouCantSleepJustCountSheep.cs)

Given a non-negative integer, *3* for example, return a string with a murmur: *"1 sheep...2 sheep...3 sheep..."*. Input will always be valid, i.e. no negative integers.

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                            Method |    n |            Mean |         Error |        StdDev | Ratio | RatioSD |      Gen 0 |      Gen 1 |      Gen 2 |     Allocated |
|---------------------------------- |----- |----------------:|--------------:|--------------:|------:|--------:|-----------:|-----------:|-----------:|--------------:|
|          ForLoopWithStringBuilder |    5 |        460.8 ns |       4.58 ns |       3.82 ns |  0.57 |    0.01 |     0.0844 |          - |          - |         445 B |
|                LinqRangeAggregate |    5 |        529.6 ns |       1.05 ns |       0.98 ns |  0.66 |    0.01 |     0.0954 |          - |          - |         501 B |
| ForLoopWithStringBuilderFixedSize |    5 |        550.7 ns |      10.59 ns |      12.19 ns |  0.68 |    0.02 |     0.1068 |          - |          - |         561 B |
|   ForLoopWithStringArrayAndConcat |    5 |        806.5 ns |       9.49 ns |       7.93 ns |  1.00 |    0.00 |     0.0954 |          - |          - |         501 B |
|           ForLoopWithStringAppend |    5 |        862.4 ns |       6.25 ns |       5.54 ns |  1.07 |    0.01 |     0.1259 |          - |          - |         665 B |
|                        LinqConcat |    5 |        967.8 ns |      10.98 ns |       9.73 ns |  1.20 |    0.02 |     0.1125 |          - |          - |         593 B |
|                                   |      |                 |               |               |       |         |            |            |            |               |
| ForLoopWithStringBuilderFixedSize |   50 |      4,005.2 ns |      74.64 ns |      69.82 ns |  0.49 |    0.01 |     0.7324 |          - |          - |       3,866 B |
|          ForLoopWithStringBuilder |   50 |      4,117.7 ns |      30.60 ns |      28.63 ns |  0.50 |    0.00 |     0.8316 |     0.0076 |          - |       4,395 B |
|   ForLoopWithStringArrayAndConcat |   50 |      8,169.0 ns |      70.43 ns |      58.82 ns |  1.00 |    0.00 |     0.9308 |          - |          - |       4,891 B |
|                LinqRangeAggregate |   50 |      9,294.2 ns |      85.54 ns |      80.02 ns |  1.14 |    0.01 |     5.5237 |     0.0305 |          - |      29,028 B |
|                        LinqConcat |   50 |      9,624.5 ns |      66.74 ns |      62.43 ns |  1.18 |    0.01 |     1.1444 |     0.0153 |          - |       6,065 B |
|           ForLoopWithStringAppend |   50 |     13,119.8 ns |     134.02 ns |     118.80 ns |  1.61 |    0.02 |     5.9662 |     0.0305 |          - |      31,356 B |
|                                   |      |                 |               |               |       |         |            |            |            |               |
| ForLoopWithStringBuilderFixedSize |  500 |     41,598.3 ns |     587.60 ns |     549.64 ns |  0.49 |    0.01 |     7.2021 |     0.5493 |          - |      38,015 B |
|          ForLoopWithStringBuilder |  500 |     42,371.2 ns |     170.69 ns |     159.67 ns |  0.50 |    0.01 |     7.3242 |     0.6104 |          - |      38,609 B |
|   ForLoopWithStringArrayAndConcat |  500 |     85,118.5 ns |     984.69 ns |     921.08 ns |  1.00 |    0.00 |     9.7656 |     0.7324 |          - |      51,467 B |
|                        LinqConcat |  500 |     92,100.4 ns |     960.99 ns |     898.91 ns |  1.08 |    0.02 |    12.9395 |     1.8311 |          - |      68,429 B |
|                LinqRangeAggregate |  500 |    207,687.3 ns |   2,939.79 ns |   2,749.88 ns |  2.44 |    0.04 |   558.3496 |     3.1738 |          - |   2,930,930 B |
|           ForLoopWithStringAppend |  500 |    245,870.8 ns |   2,004.96 ns |   1,875.44 ns |  2.89 |    0.04 |   563.2324 |     0.7324 |          - |   2,956,704 B |
|                                   |      |                 |               |               |       |         |            |            |            |               |
|          ForLoopWithStringBuilder | 5000 |    454,311.1 ns |   5,469.86 ns |   4,567.58 ns |  0.49 |    0.01 |    79.5898 |    39.5508 |    39.5508 |     373,196 B |
| ForLoopWithStringBuilderFixedSize | 5000 |    458,886.5 ns |   2,443.89 ns |   2,286.01 ns |  0.49 |    0.01 |    79.5898 |    39.5508 |    39.5508 |     376,617 B |
|   ForLoopWithStringArrayAndConcat | 5000 |    932,077.1 ns |  18,486.42 ns |  17,292.21 ns |  1.00 |    0.00 |    79.1016 |    39.0625 |    39.0625 |     543,998 B |
|                        LinqConcat | 5000 |    977,963.8 ns |  12,446.10 ns |  11,642.09 ns |  1.05 |    0.02 |   119.1406 |    77.1484 |    39.0625 |     637,536 B |
|                LinqRangeAggregate | 5000 | 21,584,998.8 ns | 302,858.85 ns | 283,294.36 ns | 23.17 |    0.69 | 80781.2500 | 56781.2500 | 54781.2500 | 315,790,572 B |
|           ForLoopWithStringAppend | 5000 | 22,024,301.9 ns | 338,175.36 ns | 316,329.45 ns | 23.63 |    0.41 | 80781.2500 | 57750.0000 | 54781.2500 | 315,897,068 B |
