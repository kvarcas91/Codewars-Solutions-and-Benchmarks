## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata6/TwoSum.cs)

Write a function that takes an array of numbers (integers for the tests) and a target number. It should find two different items in the array that, when added together, give the target value. 
The indices of these items should then be returned in a tuple / list (depending on your language) like so: *(index1, index2)*.

For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.

The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will be numbers; target will always be the sum of two different items from that array).

Based on: http://oj.leetcode.com/problems/two-sum/

For example:

```c#
twoSum [1, 2, 3] 4 === (0, 2)
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                     Method |    numbers | target |           Mean |           Error |          StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|--------------------------- |----------- |------- |---------------:|----------------:|----------------:|-------:|--------:|-------:|-------:|----------:|
|             NestedForLoops |   Int32[3] |      5 |       6.360 ns |       0.0337 ns |       0.0299 ns |   1.00 |    0.00 | 0.0038 |      - |      20 B |
|      ForLoopWithDictionary |   Int32[3] |      5 |      72.217 ns |       0.6920 ns |       0.6473 ns |  11.35 |    0.12 | 0.0290 |      - |     152 B |
| WhileLoopWithContainsCheck |   Int32[3] |      5 |      81.810 ns |       0.3367 ns |       0.3149 ns |  12.86 |    0.07 | 0.0038 |      - |      20 B |
|                 LinqSelect |   Int32[3] |      5 |      93.585 ns |       0.6458 ns |       0.6041 ns |  14.72 |    0.12 | 0.0290 |      - |     152 B |
|                     Random |   Int32[3] |      5 |   1,088.351 ns |      15.8791 ns |      14.0764 ns | 171.14 |    2.53 | 0.0896 |      - |     477 B |
|                            |            |        |                |                 |                 |        |         |        |        |           |
|             NestedForLoops |   Int32[4] |     11 |       8.675 ns |       0.1204 ns |       0.1126 ns |   1.00 |    0.00 | 0.0038 |      - |      20 B |
|      ForLoopWithDictionary |   Int32[4] |     11 |      89.138 ns |       0.7166 ns |       0.6703 ns |  10.28 |    0.14 | 0.0290 |      - |     152 B |
|                 LinqSelect |   Int32[4] |     11 |     119.418 ns |       1.0253 ns |       0.9591 ns |  13.77 |    0.20 | 0.0327 |      - |     172 B |
| WhileLoopWithContainsCheck |   Int32[4] |     11 |     126.321 ns |       1.7800 ns |       1.6650 ns |  14.56 |    0.20 | 0.0038 |      - |      20 B |
|                     Random |   Int32[4] |     11 |   1,178.938 ns |      23.3392 ns |      26.8774 ns | 135.26 |    3.78 | 0.0896 |      - |     477 B |
|                            |            |        |                |                 |                 |        |         |        |        |           |
|      ForLoopWithDictionary | Int32[500] |    997 |  12,124.491 ns |     135.1226 ns |     126.3938 ns |   0.19 |    0.00 | 6.5308 | 0.4272 |  34,307 B |
|             NestedForLoops | Int32[500] |    997 |  62,889.719 ns |     922.6550 ns |     863.0520 ns |   1.00 |    0.00 |      - |      - |      21 B |
|                 LinqSelect | Int32[500] |    997 |  72,891.506 ns |     468.0335 ns |     437.7988 ns |   1.16 |    0.02 | 1.8311 |      - |  10,107 B |
| WhileLoopWithContainsCheck | Int32[500] |    997 | 130,829.782 ns |   1,372.9782 ns |   1,284.2846 ns |   2.08 |    0.04 |      - |      - |      22 B |
|                     Random | Int32[500] |    997 | 622,739.754 ns | 124,924.0478 ns | 368,341.3734 ns |  11.71 |    5.50 |      - |      - |     480 B |
