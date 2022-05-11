## Challenge [(solution)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/CatYearsDogYears.cs)

I have a cat and a dog.

I got them at the same time as kitten/puppy. That was *humanYears* years ago.

Return their respective ages now as *[humanYears,catYears,dogYears]*

NOTES:

* humanYears >= 1
* humanYears are whole numbers only

Cat Years

* 15 cat years for first year
* +9 cat years for second year
* +4 cat years for each year after that

Dog Years

* 15 dog years for first year
* +9 dog years for second year
* +5 dog years for each year after that


---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                Method | humanYears |           Mean |         Error |        StdDev |         Median |     Ratio |  RatioSD |  Gen 0 | Allocated |
|---------------------- |----------- |---------------:|--------------:|--------------:|---------------:|----------:|---------:|-------:|----------:|
|      SwitchAndForLoop |          1 |       3.735 ns |     0.1359 ns |     0.1768 ns |       3.759 ns |      0.83 |     0.05 | 0.0046 |      24 B |
| IfStatementsAndMathOp |          1 |       4.232 ns |     0.1454 ns |     0.2306 ns |       4.369 ns |      0.93 |     0.06 | 0.0046 |      24 B |
|        TenaryOneLiner |          1 |       4.312 ns |     0.1483 ns |     0.2478 ns |       4.348 ns |      0.96 |     0.07 | 0.0046 |      24 B |
|       TenaryAndMathOp |          1 |       4.529 ns |     0.1491 ns |     0.1938 ns |       4.540 ns |      1.00 |     0.00 | 0.0046 |      24 B |
|        LinqWhileYield |          1 |     100.859 ns |     2.0314 ns |     3.3939 ns |     103.033 ns |     22.22 |     1.25 | 0.0274 |     144 B |
|                       |            |                |               |               |                |           |          |        |           |
|        TenaryOneLiner |         10 |       4.620 ns |     0.1562 ns |     0.3084 ns |       4.678 ns |      0.97 |     0.08 | 0.0046 |      24 B |
| IfStatementsAndMathOp |         10 |       4.764 ns |     0.0583 ns |     0.0487 ns |       4.776 ns |      0.99 |     0.06 | 0.0046 |      24 B |
|       TenaryAndMathOp |         10 |       4.799 ns |     0.1580 ns |     0.2768 ns |       4.973 ns |      1.00 |     0.00 | 0.0046 |      24 B |
|      SwitchAndForLoop |         10 |       6.705 ns |     0.1956 ns |     0.3268 ns |       6.908 ns |      1.40 |     0.12 | 0.0046 |      24 B |
|        LinqWhileYield |         10 |     310.353 ns |     6.2670 ns |    10.9762 ns |     313.294 ns |     64.88 |     4.42 | 0.0272 |     144 B |
|                       |            |                |               |               |                |           |          |        |           |
|        TenaryOneLiner |        100 |       4.714 ns |     0.1590 ns |     0.3318 ns |       4.479 ns |      1.01 |     0.09 | 0.0046 |      24 B |
|       TenaryAndMathOp |        100 |       4.753 ns |     0.1579 ns |     0.2766 ns |       4.704 ns |      1.00 |     0.00 | 0.0046 |      24 B |
| IfStatementsAndMathOp |        100 |       4.823 ns |     0.1588 ns |     0.3060 ns |       4.626 ns |      1.03 |     0.08 | 0.0046 |      24 B |
|      SwitchAndForLoop |        100 |      36.748 ns |     0.1433 ns |     0.1271 ns |      36.737 ns |      7.81 |     0.44 | 0.0045 |      24 B |
|        LinqWhileYield |        100 |   2,098.674 ns |    41.9195 ns |    77.7006 ns |   2,078.524 ns |    442.79 |    31.81 | 0.0267 |     144 B |
|                       |            |                |               |               |                |           |          |        |           |
| IfStatementsAndMathOp |       1000 |       4.607 ns |     0.1556 ns |     0.3072 ns |       4.781 ns |      0.92 |     0.08 | 0.0046 |      24 B |
|        TenaryOneLiner |       1000 |       4.663 ns |     0.1553 ns |     0.3172 ns |       4.882 ns |      0.93 |     0.08 | 0.0046 |      24 B |
|       TenaryAndMathOp |       1000 |       5.026 ns |     0.1641 ns |     0.2917 ns |       5.196 ns |      1.00 |     0.00 | 0.0046 |      24 B |
|      SwitchAndForLoop |       1000 |     255.042 ns |     1.1237 ns |     0.8773 ns |     255.290 ns |     50.77 |     3.34 | 0.0043 |      24 B |
|        LinqWhileYield |       1000 |  19,369.331 ns |   385.4623 ns |   704.8395 ns |  19,771.205 ns |  3,862.45 |   263.75 |      - |     144 B |
|                       |            |                |               |               |                |           |          |        |           |
|        TenaryOneLiner |      10000 |       4.606 ns |     0.1534 ns |     0.2991 ns |       4.788 ns |      0.96 |     0.10 | 0.0046 |      24 B |
| IfStatementsAndMathOp |      10000 |       4.794 ns |     0.1559 ns |     0.2889 ns |       4.977 ns |      1.00 |     0.09 | 0.0046 |      24 B |
|       TenaryAndMathOp |      10000 |       4.807 ns |     0.1602 ns |     0.2848 ns |       4.990 ns |      1.00 |     0.00 | 0.0046 |      24 B |
|      SwitchAndForLoop |      10000 |   2,357.187 ns |     6.0817 ns |     5.6888 ns |   2,356.590 ns |    487.25 |    28.56 | 0.0038 |      24 B |
|        LinqWhileYield |      10000 | 191,123.206 ns | 3,804.1366 ns | 7,329.2797 ns | 195,930.457 ns | 39,903.83 | 3,040.36 |      - |     146 B |
