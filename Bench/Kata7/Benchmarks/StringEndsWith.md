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
|          Method |     str | ending |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|---------------- |-------- |------- |----------:|----------:|----------:|------:|-------:|----------:|
|         ForLoop | samurai |     ai |  4.180 ns | 0.0684 ns | 0.0639 ns |  0.05 |      - |         - |
| SubStringsEqual | samurai |     ai | 15.273 ns | 0.2570 ns | 0.2404 ns |  0.18 | 0.0038 |      20 B |
|     RemoveEqual | samurai |     ai | 15.363 ns | 0.2110 ns | 0.1974 ns |  0.18 | 0.0038 |      20 B |
|        EndsWith | samurai |     ai | 84.535 ns | 1.6984 ns | 1.8878 ns |  1.00 |      - |         - |
