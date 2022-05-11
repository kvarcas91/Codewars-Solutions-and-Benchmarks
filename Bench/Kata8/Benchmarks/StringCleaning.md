## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/StringCleaning.cs)

Your boss decided to save money by purchasing some cut-rate optical character recognition software for scanning in the text of old novels to your database. At first it seems to capture words okay, 
but you quickly notice that it throws in a lot of numbers at random places in the text.
Examples (input -> output)

``` c#
'! !'                 -> '! !'
'123456789'           -> ''
'This looks5 grea8t!' -> 'This looks great!'
``` 

Your harried co-workers are looking to you for a solution to take this garbled text and remove all of the numbers. Your program will take in a string and clean out all numeric characters, 
and return a string with spacing and special characters ~#$%^&!@*():;"'.,? all intact.


---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                      Method |                    s |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------- |--------------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|
| ReplaceNumbersWithEmptyChar | This (...)ext5! [26] |   109.4 ns |   1.71 ns |   1.60 ns |  0.70 |    0.02 | 0.0153 |      80 B |
|     StringBuilderAndForEach | This (...)ext5! [26] |   155.7 ns |   3.17 ns |   3.39 ns |  1.00 |    0.00 | 0.0396 |     208 B |
|                 LinqAndJoin | This (...)ext5! [26] |   781.3 ns |  14.04 ns |  13.13 ns |  5.03 |    0.14 | 0.1554 |     817 B |
|                       Regex | This (...)ext5! [26] |   992.1 ns |  19.12 ns |  21.25 ns |  6.38 |    0.20 | 0.0954 |     509 B |
|                             |                      |            |           |           |       |         |        |           |
|     StringBuilderAndForEach |  Your(...)okay [199] |   952.3 ns |  18.65 ns |  20.73 ns |  1.00 |    0.00 | 0.2127 |   1,118 B |
| ReplaceNumbersWithEmptyChar |  Your(...)okay [199] | 2,293.8 ns |  43.48 ns |  70.21 ns |  2.40 |    0.06 | 0.2441 |   1,286 B |
|                       Regex |  Your(...)okay [199] | 4,641.5 ns |  88.75 ns | 124.41 ns |  4.88 |    0.16 | 0.3204 |   1,719 B |
|                 LinqAndJoin |  Your(...)okay [199] | 5,636.0 ns | 112.46 ns | 184.78 ns |  5.94 |    0.23 | 1.1292 |   5,925 B |
