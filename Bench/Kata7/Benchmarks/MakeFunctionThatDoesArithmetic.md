## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/MakeFunctionThatDoesArithmetic.cs)

Given two numbers and an arithmetic operator (the name of it, as a string), return the result of the two numbers having that operator used on them.

*a* and *b* will both be positive integers, and *a* will always be the first number in the operation, and *b* always the second.

The four operators are "add", "subtract", "divide", "multiply". 

For example:

```c#
5, 2, "add"      --> 7
5, 2, "subtract" --> 3
5, 2, "multiply" --> 10
5, 2, "divide"   --> 2.5
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|       Method | a | b |     op |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |  Gen 0 | Allocated |
|------------- |-- |-- |------- |------------:|----------:|----------:|------------:|-------:|--------:|-------:|----------:|
|      Tennary | 5 | 2 | divide |   0.0029 ns | 0.0091 ns | 0.0081 ns |   0.0000 ns |  0.001 |    0.00 |      - |         - |
| IfStatements | 5 | 2 | divide |   4.2402 ns | 0.1191 ns | 0.1114 ns |   4.1981 ns |  0.982 |    0.05 |      - |         - |
|       Switch | 5 | 2 | divide |   4.3245 ns | 0.1846 ns | 0.1727 ns |   4.3047 ns |  1.000 |    0.00 |      - |         - |
|   Dictionary | 5 | 2 | divide | 187.5369 ns | 3.4727 ns | 3.2484 ns | 186.2029 ns | 43.441 |    2.13 | 0.0565 |     296 B |
