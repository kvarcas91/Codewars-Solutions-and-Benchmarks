## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/GravityFlip.cs)

If you've completed this kata already and want a bigger challenge, here's the 3D version

Bob is bored during his physics lessons so he's built himself a toy box to help pass the time. The box is special because it has the ability to change gravity.

There are some columns of toy cubes in the box arranged in a line. The i-th column contains a_i cubes. At first, the gravity in the box is pulling the cubes downwards. When Bob switches the gravity, 
it begins to pull all the cubes to a certain side of the box, d, which can be either 'L' or 'R' (left or right). Below is an example of what a box of cubes might look like before and after switching gravity.

```c#
+---+                                       +---+
|   |                                       |   |
+---+                                       +---+
+---++---+     +---+              +---++---++---+
|   ||   |     |   |   -->        |   ||   ||   |
+---++---+     +---+              +---++---++---+
+---++---++---++---+         +---++---++---++---+
|   ||   ||   ||   |         |   ||   ||   ||   |
+---++---++---++---+         +---++---++---++---+
```

Given the initial configuration of the cubes in the box, find out how many cubes are in each of the n columns after Bob switches the gravity.

Examples (input -> output:

```c#
* 'R', [3, 2, 1, 2]      ->  [1, 2, 2, 3]
* 'L', [1, 4, 5, 3, 5 ]  ->  [5, 5, 4, 3, 1]
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                  Method | dir |          arr |            Mean |         Error |        StdDev |          Median |      Ratio |  RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|------------------------ |---- |------------- |----------------:|--------------:|--------------:|----------------:|-----------:|---------:|---------:|---------:|---------:|------------:|
| ArraySortWithOneIfCheck |   L |     Int32[4] |        61.09 ns |      0.275 ns |      0.244 ns |        61.11 ns |       1.00 |     0.00 |        - |        - |        - |           - |
| ArraySortWithDoubleSort |   L |     Int32[4] |        62.40 ns |      0.435 ns |      0.363 ns |        62.36 ns |       1.02 |     0.01 |        - |        - |        - |           - |
|       LinqOrderByTenary |   L |     Int32[4] |       190.97 ns |      0.452 ns |      0.353 ns |       190.87 ns |       3.13 |     0.01 |   0.0389 |        - |        - |       204 B |
| LinqOrderByTenaryInside |   L |     Int32[4] |       196.67 ns |      1.849 ns |      1.730 ns |       196.28 ns |       3.22 |     0.03 |   0.0472 |        - |        - |       248 B |
| ArraySortWithDoubleSort |   L |   Int32[500] |     4,749.55 ns |     47.775 ns |     39.894 ns |     4,766.41 ns |      77.75 |     0.74 |        - |        - |        - |           - |
| ArraySortWithOneIfCheck |   L |   Int32[500] |     4,779.15 ns |     53.064 ns |     49.636 ns |     4,786.66 ns |      78.18 |     0.82 |        - |        - |        - |           - |
| LinqOrderByTenaryInside |   L |   Int32[500] |    26,284.59 ns |    520.958 ns |    639.783 ns |    26,164.07 ns |     429.69 |     9.41 |   2.3499 |   0.0305 |        - |    12,380 B |
|       LinqOrderByTenary |   L |   Int32[500] |    29,375.16 ns |    575.131 ns |    684.652 ns |    29,682.21 ns |     480.70 |    10.55 |   2.3499 |   0.0305 |        - |    12,336 B |
| ArraySortWithDoubleSort |   L |  Int32[5000] |    58,039.56 ns |    616.804 ns |    546.781 ns |    57,954.37 ns |     950.05 |    10.31 |        - |        - |        - |           - |
| ArraySortWithOneIfCheck |   L |  Int32[5000] |    58,315.55 ns |    767.641 ns |    718.052 ns |    57,975.26 ns |     954.95 |    12.05 |        - |        - |        - |           - |
| LinqOrderByTenaryInside |   L |  Int32[5000] |   334,238.09 ns |  6,590.624 ns |  7,051.893 ns |   338,157.40 ns |   5,463.88 |   116.36 |  27.3438 |   4.3945 |        - |   146,156 B |
|       LinqOrderByTenary |   L |  Int32[5000] |   379,330.22 ns |  7,062.618 ns |  7,252.788 ns |   380,827.29 ns |   6,194.87 |   123.59 |  27.3438 |   4.3945 |        - |   145,932 B |
| ArraySortWithOneIfCheck |   L | Int32[50000] |   694,545.94 ns | 13,890.161 ns | 12,992.865 ns |   690,323.05 ns |  11,364.31 |   234.01 |        - |        - |        - |           - |
| ArraySortWithDoubleSort |   L | Int32[50000] |   702,158.47 ns | 14,039.553 ns | 21,439.880 ns |   695,523.24 ns |  11,776.89 |   302.73 |        - |        - |        - |           - |
| LinqOrderByTenaryInside |   L | Int32[50000] | 4,194,527.70 ns | 48,312.906 ns | 40,343.464 ns | 4,195,225.78 ns |  68,664.08 |   589.41 | 343.7500 | 335.9375 | 335.9375 | 1,329,024 B |
|       LinqOrderByTenary |   L | Int32[50000] | 4,711,193.25 ns | 58,337.004 ns | 51,714.235 ns | 4,698,338.28 ns |  77,117.01 |   900.34 | 351.5625 | 335.9375 | 335.9375 | 1,328,640 B |
|                         |     |              |                 |               |               |                 |            |          |          |          |          |             |
| ArraySortWithOneIfCheck |   R |     Int32[5] |        31.96 ns |      0.459 ns |      0.407 ns |        31.92 ns |       1.00 |     0.00 |        - |        - |        - |           - |
| ArraySortWithDoubleSort |   R |     Int32[5] |        32.41 ns |      0.609 ns |      0.569 ns |        32.60 ns |       1.02 |     0.02 |        - |        - |        - |           - |
|       LinqOrderByTenary |   R |     Int32[5] |       272.88 ns |      5.502 ns |      6.959 ns |       274.06 ns |       8.52 |     0.18 |   0.0553 |        - |        - |       292 B |
| LinqOrderByTenaryInside |   R |     Int32[5] |       275.25 ns |      5.395 ns |      7.016 ns |       278.74 ns |       8.65 |     0.24 |   0.0639 |        - |        - |       336 B |
| ArraySortWithDoubleSort |   R |   Int32[500] |     2,404.41 ns |     18.626 ns |     16.511 ns |     2,407.13 ns |      75.24 |     1.19 |        - |        - |        - |           - |
| ArraySortWithOneIfCheck |   R |   Int32[500] |     2,406.09 ns |     19.701 ns |     17.465 ns |     2,406.77 ns |      75.29 |     1.13 |        - |        - |        - |           - |
| LinqOrderByTenaryInside |   R |   Int32[500] |    26,458.53 ns |    517.781 ns |    673.262 ns |    26,620.62 ns |     832.97 |    21.54 |   2.3499 |   0.0305 |        - |    12,380 B |
|       LinqOrderByTenary |   R |   Int32[500] |    28,651.90 ns |    546.575 ns |    607.517 ns |    29,007.28 ns |     897.47 |    26.47 |   2.3499 |   0.0305 |        - |    12,336 B |
| ArraySortWithDoubleSort |   R |  Int32[5000] |    32,833.89 ns |    345.828 ns |    323.488 ns |    32,701.19 ns |   1,027.66 |    14.37 |        - |        - |        - |           - |
| ArraySortWithOneIfCheck |   R |  Int32[5000] |    33,098.09 ns |    358.879 ns |    335.695 ns |    33,076.82 ns |   1,034.74 |    15.07 |        - |        - |        - |           - |
| LinqOrderByTenaryInside |   R |  Int32[5000] |   337,681.03 ns |  6,611.951 ns |  9,482.663 ns |   342,971.66 ns |  10,499.78 |   299.95 |  27.3438 |   4.3945 |        - |   146,156 B |
| ArraySortWithDoubleSort |   R | Int32[50000] |   353,438.64 ns |  4,713.334 ns |  4,408.855 ns |   352,702.98 ns |  11,059.79 |   184.47 |        - |        - |        - |           - |
| ArraySortWithOneIfCheck |   R | Int32[50000] |   353,946.29 ns |  4,867.237 ns |  4,314.679 ns |   352,816.26 ns |  11,074.26 |   119.18 |        - |        - |        - |           - |
|       LinqOrderByTenary |   R |  Int32[5000] |   364,780.85 ns |  7,238.709 ns |  9,154.650 ns |   361,973.19 ns |  11,427.81 |   352.12 |  27.3438 |   4.3945 |        - |   145,932 B |
| LinqOrderByTenaryInside |   R | Int32[50000] | 4,219,431.67 ns | 34,738.817 ns | 29,008.486 ns | 4,217,415.63 ns | 131,875.75 | 1,942.05 | 351.5625 | 335.9375 | 335.9375 | 1,329,216 B |
|       LinqOrderByTenary |   R | Int32[50000] | 4,637,470.38 ns | 30,892.049 ns | 24,118.480 ns | 4,641,888.28 ns | 145,061.35 | 1,750.22 | 351.5625 | 328.1250 | 328.1250 | 1,328,704 B |
