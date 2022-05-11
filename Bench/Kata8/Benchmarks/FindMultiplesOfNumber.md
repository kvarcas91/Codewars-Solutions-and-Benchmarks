## Challenge

n this simple exercise, you will build a program that takes a value, *integer* , and returns a list of its multiples up to another value, *limit* . If *limit* is a multiple of *integer*, it should be included as well. 
There will only ever be positive integers passed into the function, not consisting of 0. The limit will always be higher than the base.

For example, if the parameters passed are *(2, 6)*, the function should return *[2, 4, 6]* as 2, 4, and 6 are the multiples of 2 up to 6.

If you can, try writing it in only one line of code.

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|           Method | integer | limit |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Allocated |
|----------------- |-------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|-------:|----------:|
|          ForLoop |       2 |    12 |     51.32 ns |   0.965 ns |   0.856 ns |  0.23 |    0.01 | 0.0183 |      - |      96 B |
| EnumerableSelect |       2 |    12 |    171.84 ns |   2.693 ns |   2.519 ns |  0.77 |    0.02 | 0.0412 |      - |     216 B |
|  EnumerableWhere |       2 |    12 |    221.94 ns |   2.170 ns |   1.694 ns |  1.00 |    0.00 | 0.0403 |      - |     212 B |
|                  |         |       |              |            |            |       |         |        |        |           |
|          ForLoop |       5 |  5000 |  2,606.90 ns |   5.767 ns |   4.502 ns |  0.07 |    0.00 | 1.5831 | 0.0648 |   8,320 B |
| EnumerableSelect |       5 |  5000 | 11,628.01 ns | 124.645 ns | 116.593 ns |  0.32 |    0.00 | 1.6022 | 0.0610 |   8,441 B |
|  EnumerableWhere |       5 |  5000 | 36,260.90 ns | 111.223 ns |  98.596 ns |  1.00 |    0.00 | 1.5869 | 0.0610 |   8,438 B |
