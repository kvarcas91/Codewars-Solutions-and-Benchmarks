## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/Mumbling.cs)

This time no story, no theory. The examples below show you how to write function accum:

For example:

```c#
accum("abcd") -> "A-Bb-Ccc-Dddd"
accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
accum("cwAt") -> "C-Ww-Aaa-Tttt"
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|           Method |                    s |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|----------------- |--------------------- |-----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|
|    StringBuilder | aBcDe(...)TUVWZ [24] | 1,387.6 ns | 21.71 ns | 19.25 ns |  1.00 |    0.00 | 0.5093 | 0.0019 |   2,672 B |
|         LinqJoin | aBcDe(...)TUVWZ [24] | 3,004.1 ns |  9.16 ns |  7.65 ns |  2.16 |    0.03 | 0.8011 |      - |   4,218 B |
| StringAddForEach | aBcDe(...)TUVWZ [24] | 3,852.7 ns | 18.28 ns | 15.26 ns |  2.77 |    0.04 | 2.4719 | 0.0076 |  12,971 B |
|                  |                      |            |          |          |       |         |        |        |           |
|    StringBuilder |                 abcd |   245.1 ns |  1.31 ns |  1.23 ns |  1.00 |    0.00 | 0.0372 |      - |     196 B |
| StringAddForEach |                 abcd |   368.5 ns |  1.94 ns |  1.81 ns |  1.50 |    0.01 | 0.0629 |      - |     332 B |
|         LinqJoin |                 abcd |   423.1 ns |  3.66 ns |  3.43 ns |  1.73 |    0.02 | 0.0548 |      - |     288 B |
