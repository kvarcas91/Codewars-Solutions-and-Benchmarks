## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/HelloNameOrWorld.cs)

Define a method *hello* that *returns* "Hello, Name!" to a given *name*, or says Hello, World! if name is not given (or passed as an empty String).

Assuming that *name* is a *String* and it checks for user typos to return a name with a first capital letter (Xxxx).

```c#
* With `name` = "john"  => return "Hello, John!"
* With `name` = "aliCE" => return "Hello, Alice!"
* With `name` not given 
  or `name` = ""        => return "Hello, World!"
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                        Method |                 name |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------ |--------------------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|
|                  StringAppend |                Eddie |   202.8 ns |  0.85 ns |  0.71 ns |  0.99 |    0.00 | 0.0229 |     120 B |
|  InterpolationAndStringConcat |                Eddie |   205.4 ns |  0.56 ns |  0.52 ns |  1.00 |    0.00 | 0.0229 |     120 B |
| InterpolationAndGlobalization |                Eddie |   273.6 ns |  2.48 ns |  2.32 ns |  1.33 |    0.01 | 0.0348 |     184 B |
|        StringAppendAndForLoop |                Eddie |   274.8 ns |  3.69 ns |  3.45 ns |  1.34 |    0.02 | 0.0372 |     196 B |
|                          Linq |                Eddie |   328.3 ns |  3.35 ns |  3.13 ns |  1.60 |    0.02 | 0.0510 |     268 B |
|                               |                      |            |          |          |       |         |        |           |
|  InterpolationAndStringConcat | SomeR(...)lenge [46] |   325.8 ns |  3.79 ns |  3.55 ns |  1.00 |    0.00 | 0.0691 |     365 B |
|                  StringAppend | SomeR(...)lenge [46] |   327.8 ns |  6.08 ns |  5.69 ns |  1.01 |    0.02 | 0.0691 |     365 B |
| InterpolationAndGlobalization | SomeR(...)lenge [46] |   831.6 ns | 12.98 ns | 12.14 ns |  2.55 |    0.05 | 0.1183 |     621 B |
|                          Linq | SomeR(...)lenge [46] | 2,217.2 ns | 29.10 ns | 27.22 ns |  6.81 |    0.10 | 0.3014 |   1,586 B |
|        StringAppendAndForLoop | SomeR(...)lenge [46] | 2,553.5 ns | 31.37 ns | 29.34 ns |  7.84 |    0.10 | 0.6866 |   3,605 B |
