## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/ReturningStrings.cs)

Make a function that will return a greeting statement that uses an input; your program should return, "Hello, *<name> how are you doing today?"*.

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|        Method |                 name |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
|        Insert |                Eddie |  35.51 ns | 0.771 ns | 0.721 ns | 0.0168 |      88 B |
| Interpolation |                Eddie |  40.37 ns | 0.492 ns | 0.460 ns | 0.0168 |      88 B |
|           Add |                Eddie |  40.50 ns | 0.545 ns | 0.510 ns | 0.0168 |      88 B |
|        Insert | Maybe(...)rName [25] |  51.53 ns | 0.242 ns | 0.215 ns | 0.0244 |     128 B |
| Interpolation | Maybe(...)rName [25] |  58.00 ns | 0.701 ns | 0.622 ns | 0.0244 |     128 B |
|           Add | Maybe(...)rName [25] |  58.20 ns | 0.715 ns | 0.669 ns | 0.0244 |     128 B |
|       Replace |                Eddie |  96.17 ns | 1.685 ns | 1.576 ns | 0.0168 |      88 B |
|       Replace | Maybe(...)rName [25] | 103.08 ns | 2.005 ns | 1.875 ns | 0.0244 |     128 B |
|        Format |                Eddie | 150.63 ns | 2.037 ns | 1.806 ns | 0.0167 |      88 B |
|        Format | Maybe(...)rName [25] | 182.88 ns | 2.724 ns | 2.415 ns | 0.0243 |     128 B |
