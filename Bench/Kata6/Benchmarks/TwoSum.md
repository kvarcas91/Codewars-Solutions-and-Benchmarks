## Challenge

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
|                     Method |    numbers | target |           Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|--------------------------- |----------- |------- |---------------:|------------:|------------:|------:|--------:|-------:|-------:|----------:|
|             NestedForLoops |   Int32[3] |      5 |       6.360 ns |   0.0211 ns |   0.0176 ns |  1.00 |    0.00 | 0.0038 |      - |      20 B |
|      ForLoopWithDictionary |   Int32[3] |      5 |      72.743 ns |   0.4029 ns |   0.3769 ns | 11.44 |    0.05 | 0.0290 |      - |     152 B |
| WhileLoopWithContainsCheck |   Int32[3] |      5 |      83.055 ns |   1.3604 ns |   1.2725 ns | 13.05 |    0.22 | 0.0038 |      - |      20 B |
|                 LinqSelect |   Int32[3] |      5 |      93.075 ns |   0.3587 ns |   0.3355 ns | 14.63 |    0.05 | 0.0290 |      - |     152 B |
|                            |            |        |                |             |             |       |         |        |        |           |
|             NestedForLoops |   Int32[4] |     11 |       8.779 ns |   0.1641 ns |   0.1535 ns |  1.00 |    0.00 | 0.0038 |      - |      20 B |
|      ForLoopWithDictionary |   Int32[4] |     11 |      90.132 ns |   1.5212 ns |   1.4229 ns | 10.27 |    0.14 | 0.0290 |      - |     152 B |
|                 LinqSelect |   Int32[4] |     11 |     118.203 ns |   2.0859 ns |   1.9512 ns | 13.47 |    0.29 | 0.0327 |      - |     172 B |
| WhileLoopWithContainsCheck |   Int32[4] |     11 |     125.525 ns |   2.0193 ns |   1.8888 ns | 14.30 |    0.27 | 0.0038 |      - |      20 B |
|                            |            |        |                |             |             |       |         |        |        |           |
|      ForLoopWithDictionary | Int32[500] |    997 |  12,159.459 ns | 130.2873 ns | 121.8709 ns |  0.19 |    0.00 | 6.5308 | 0.4272 |  34,307 B |
|             NestedForLoops | Int32[500] |    997 |  63,417.095 ns | 929.9568 ns | 869.8822 ns |  1.00 |    0.00 |      - |      - |      21 B |
|                 LinqSelect | Int32[500] |    997 |  72,599.272 ns | 737.0107 ns | 689.4003 ns |  1.14 |    0.02 | 1.8311 |      - |  10,107 B |
| WhileLoopWithContainsCheck | Int32[500] |    997 | 130,856.502 ns | 967.5237 ns | 905.0222 ns |  2.06 |    0.04 |      - |      - |      22 B |
