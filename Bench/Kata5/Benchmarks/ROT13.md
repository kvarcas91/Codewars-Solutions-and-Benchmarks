## Challenge

How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.

I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it? According to Wikipedia, ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.

Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc.

Test examples:

```c#
"EBG13 rknzcyr." -->
"ROT13 example."

"This is my first ROT13 excercise!" -->
"Guvf vf zl svefg EBG13 rkprepvfr!"
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                       Method |                input |        Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------------------- |--------------------- |------------:|----------:|----------:|-------:|----------:|
| StringBuilderWithPresetLists |       EBG13 rknzcyr. |    355.4 ns |   2.95 ns |   2.62 ns | 0.0219 |     116 B |
|     CharManipulationWithLinq |       EBG13 rknzcyr. |    504.7 ns |   3.36 ns |   2.80 ns | 0.0439 |     232 B |
|                      ForEach |       EBG13 rknzcyr. |    530.1 ns |   7.20 ns |   6.74 ns | 0.1154 |     609 B |
|           StringJoinWithLinq |       EBG13 rknzcyr. |    655.0 ns |   5.94 ns |   5.27 ns | 0.1030 |     541 B |
| StringBuilderWithPresetLists | This (...)more! [63] |  1,779.9 ns |  25.22 ns |  22.36 ns | 0.0725 |     389 B |
|                      ForEach | This (...)more! [63] |  2,007.8 ns |  30.63 ns |  28.65 ns | 0.4539 |   2,396 B |
|     CharManipulationWithLinq | This (...)more! [63] |  2,152.2 ns |  18.48 ns |  17.29 ns | 0.1221 |     645 B |
|                        Regex |       EBG13 rknzcyr. |  2,818.9 ns |  15.95 ns |  14.92 ns | 0.3853 |   2,027 B |
|           StringJoinWithLinq | This (...)more! [63] |  2,950.6 ns |  41.96 ns |  39.25 ns | 0.3815 |   2,011 B |
|                        Regex | This (...)more! [63] | 12,413.7 ns | 135.49 ns | 120.11 ns | 1.6479 |   8,673 B |
