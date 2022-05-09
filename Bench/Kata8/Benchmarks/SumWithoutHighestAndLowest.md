
## Challenge

Sum all the numbers of a given array ( cq. list ), except the highest and the lowest element ( by value, not by index! ).
The highest or lowest element respectively is a single element at each edge, even if there are more than one with the same value.

Mind the input validation.

Example

```c#
{ 6, 2, 1, 8, 10 } => 16
{ 1, 1, 11, 2, 3 } => 6
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|             Method |    numbers |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------- |----------- |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|
|     SumWithForLoop |   Int32[5] |     5.431 ns |  0.0505 ns |  0.0473 ns |  0.05 |    0.00 |      - |         - |
|     SumWithForLoop |  Int32[50] |    44.513 ns |  0.2708 ns |  0.2401 ns |  0.38 |    0.01 |      - |         - |
|     SumWithForLoop | Int32[100] |    79.998 ns |  0.9582 ns |  0.8963 ns |  0.68 |    0.01 |      - |         - |
|        SumWithLinq |   Int32[5] |   118.297 ns |  2.1888 ns |  2.0474 ns |  1.00 |    0.00 | 0.0114 |      60 B |
| SumWithLinqOrderBy |   Int32[5] |   276.110 ns |  4.9222 ns |  4.6042 ns |  2.33 |    0.05 | 0.0510 |     268 B |
|        SumWithLinq |  Int32[50] |   735.722 ns | 13.2786 ns | 12.4208 ns |  6.22 |    0.16 | 0.0114 |      60 B |
|        SumWithLinq | Int32[100] | 1,373.077 ns | 13.3844 ns | 12.5198 ns | 11.61 |    0.20 | 0.0114 |      60 B |
| SumWithLinqOrderBy |  Int32[50] | 2,505.603 ns | 47.1082 ns | 44.0650 ns | 21.19 |    0.59 | 0.1526 |     809 B |
| SumWithLinqOrderBy | Int32[100] | 5,408.556 ns | 65.2005 ns | 60.9886 ns | 45.73 |    0.68 | 0.2670 |   1,410 B |
