## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/SummingNumberDigits.cs)

Write a function named sumDigits which takes a number as input and returns the sum of the absolute value of each of the number's decimal digits.

For example: (Input --> Output)

```c#
10 --> 1
99 --> 18
-32 --> 5
```

Let's assume that all numbers in the input will be integer values.

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                Method | number |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------- |------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|
|           WhileAndMod |  -5000 |  15.786 ns | 0.0938 ns | 0.0783 ns |  0.16 |    0.00 |      - |         - |
|             Recursion |  -5000 |  20.190 ns | 0.0788 ns | 0.0658 ns |  0.21 |    0.00 |      - |         - |
| ForLoopConvertToInt32 |  -5000 |  74.887 ns | 1.1822 ns | 1.1059 ns |  0.76 |    0.01 | 0.0045 |      24 B |
|               ForEach |  -5000 |  98.386 ns | 0.2057 ns | 0.1718 ns |  1.00 |    0.00 | 0.0045 |      24 B |
|           LinqSumTrim |  -5000 | 185.709 ns | 2.0011 ns | 1.7739 ns |  1.88 |    0.02 | 0.0236 |     124 B |
|         LinqSumTenary |  -5000 | 185.921 ns | 2.8597 ns | 2.6750 ns |  1.89 |    0.03 | 0.0160 |      84 B |
|         LinqSumSelect |  -5000 | 417.102 ns | 3.9777 ns | 3.5261 ns |  4.24 |    0.04 | 0.0272 |     144 B |
|  LinqSumReplaceSelect |  -5000 | 459.993 ns | 4.8126 ns | 4.5017 ns |  4.67 |    0.05 | 0.0319 |     168 B |
|                       |        |            |           |           |       |         |        |           |
|           WhileAndMod |      5 |   4.138 ns | 0.0192 ns | 0.0161 ns |  0.06 |    0.00 |      - |         - |
|             Recursion |      5 |   5.276 ns | 0.0711 ns | 0.0630 ns |  0.08 |    0.00 |      - |         - |
| ForLoopConvertToInt32 |      5 |  55.590 ns | 0.7190 ns | 0.6725 ns |  0.87 |    0.01 | 0.0030 |      16 B |
|               ForEach |      5 |  64.214 ns | 0.4560 ns | 0.4266 ns |  1.00 |    0.00 | 0.0030 |      16 B |
|         LinqSumTenary |      5 | 116.038 ns | 1.7949 ns | 1.6789 ns |  1.81 |    0.03 | 0.0143 |      76 B |
|           LinqSumTrim |      5 | 122.209 ns | 2.4671 ns | 3.1202 ns |  1.91 |    0.06 | 0.0174 |      92 B |
|         LinqSumSelect |      5 | 171.034 ns | 3.3265 ns | 3.9600 ns |  2.67 |    0.07 | 0.0167 |      88 B |
|  LinqSumReplaceSelect |      5 | 190.767 ns | 3.7891 ns | 4.9269 ns |  2.98 |    0.07 | 0.0167 |      88 B |
|                       |        |            |           |           |       |         |        |           |
|           WhileAndMod |     50 |   7.148 ns | 0.0661 ns | 0.0586 ns |  0.10 |    0.00 |      - |         - |
|             Recursion |     50 |   9.940 ns | 0.1268 ns | 0.1186 ns |  0.13 |    0.00 |      - |         - |
| ForLoopConvertToInt32 |     50 |  61.208 ns | 1.0009 ns | 0.9362 ns |  0.82 |    0.02 | 0.0038 |      20 B |
|               ForEach |     50 |  75.009 ns | 1.0146 ns | 0.9490 ns |  1.00 |    0.00 | 0.0038 |      20 B |
|         LinqSumTenary |     50 | 134.471 ns | 2.5882 ns | 2.4210 ns |  1.79 |    0.05 | 0.0153 |      80 B |
|           LinqSumTrim |     50 | 137.827 ns | 2.4367 ns | 2.2793 ns |  1.84 |    0.04 | 0.0181 |      96 B |
|         LinqSumSelect |     50 | 251.147 ns | 4.9238 ns | 5.0564 ns |  3.35 |    0.09 | 0.0205 |     108 B |
|  LinqSumReplaceSelect |     50 | 270.318 ns | 5.1429 ns | 5.9226 ns |  3.60 |    0.10 | 0.0205 |     108 B |
|                       |        |            |           |           |       |         |        |           |
|           WhileAndMod |    500 |  10.223 ns | 0.0601 ns | 0.0502 ns |  0.12 |    0.00 |      - |         - |
|             Recursion |    500 |  14.913 ns | 0.0545 ns | 0.0426 ns |  0.17 |    0.00 |      - |         - |
| ForLoopConvertToInt32 |    500 |  68.093 ns | 0.6652 ns | 0.6222 ns |  0.78 |    0.01 | 0.0038 |      20 B |
|               ForEach |    500 |  87.557 ns | 1.1309 ns | 1.0579 ns |  1.00 |    0.00 | 0.0038 |      20 B |
|           LinqSumTrim |    500 | 155.938 ns | 1.8632 ns | 1.6517 ns |  1.78 |    0.03 | 0.0181 |      96 B |
|         LinqSumTenary |    500 | 156.014 ns | 2.5211 ns | 2.3582 ns |  1.78 |    0.04 | 0.0153 |      80 B |
|         LinqSumSelect |    500 | 341.066 ns | 6.6825 ns | 6.2508 ns |  3.90 |    0.07 | 0.0234 |     124 B |
|  LinqSumReplaceSelect |    500 | 363.935 ns | 7.3037 ns | 6.8319 ns |  4.16 |    0.10 | 0.0234 |     124 B |
