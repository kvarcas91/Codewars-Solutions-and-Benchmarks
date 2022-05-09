## Challenge

Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument (also a string). 

For example:

```c#
solution('abc', 'bc') // returns true
solution('abc', 'd') // returns false
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```

|          Method |                  str | ending |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|---------------- |--------------------- |------- |----------:|----------:|----------:|------:|-------:|----------:|
|       ForLoopV2 |              samurai |     ai |  3.048 ns | 0.0676 ns | 0.0632 ns |  0.04 |      - |         - |
|         ForLoop |              samurai |     ai |  4.371 ns | 0.1136 ns | 0.1308 ns |  0.05 |      - |         - |
| SubStringsEqual |              samurai |     ai | 15.681 ns | 0.3183 ns | 0.2977 ns |  0.18 | 0.0038 |      20 B |
|     RemoveEqual |              samurai |     ai | 15.706 ns | 0.1630 ns | 0.1524 ns |  0.18 | 0.0038 |      20 B |
|        EndsWith |              samurai |     ai | 86.274 ns | 1.4156 ns | 1.4538 ns |  1.00 |      - |         - |
|                 |                      |        |           |           |           |       |        |           |
|       ForLoopV2 | someR(...)Power [68] |   ower |  5.020 ns | 0.1250 ns | 0.1439 ns |  0.06 |      - |         - |
|         ForLoop | someR(...)Power [68] |   ower |  6.558 ns | 0.1583 ns | 0.1555 ns |  0.08 |      - |         - |
| SubStringsEqual | someR(...)Power [68] |   ower | 15.884 ns | 0.2970 ns | 0.2778 ns |  0.18 | 0.0046 |      24 B |
|     RemoveEqual | someR(...)Power [68] |   ower | 16.538 ns | 0.3524 ns | 0.3917 ns |  0.19 | 0.0046 |      24 B |
|        EndsWith | someR(...)Power [68] |   ower | 87.302 ns | 1.4416 ns | 1.3485 ns |  1.00 |      - |         - |
