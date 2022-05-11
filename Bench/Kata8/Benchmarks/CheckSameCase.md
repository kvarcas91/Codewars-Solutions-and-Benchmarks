## Challenge

Write a function that will check if two given characters are the same case.

* If either of the characters is not a letter, return -1
* If both characters are the same case, return 1
* If both characters are letters, but not the same case, return 0


```c#
'a' and 'g' returns 1
'A' and 'C' returns 1
'b' and 'G' returns 0
'B' and 'g' returns 0
'0' and '?' returns -1
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|        Method | a | b |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated |
|-------------- |-- |-- |----------:|----------:|----------:|------:|--------:|----------:|
|          XNOR | a | B |  7.572 ns | 0.1230 ns | 0.1090 ns |  1.00 |    0.00 |         - |
|         Equal | a | B |  7.600 ns | 0.1151 ns | 0.1077 ns |  1.00 |    0.01 |         - |
|            OR | a | B |  9.146 ns | 0.1902 ns | 0.1779 ns |  1.21 |    0.03 |         - |
|   MultipleIfs | a | B | 10.893 ns | 0.2221 ns | 0.2078 ns |  1.44 |    0.03 |         - |
| Globalization | a | B | 12.624 ns | 0.2657 ns | 0.2485 ns |  1.67 |    0.04 |         - |
|       IndexOf | a | B | 19.061 ns | 0.2297 ns | 0.2149 ns |  2.52 |    0.04 |         - |
|     ToUpperOR | a | B | 57.890 ns | 0.5358 ns | 0.5012 ns |  7.64 |    0.10 |         - |
|               |   |   |           |           |           |       |         |           |
|   MultipleIfs | a | b |  3.756 ns | 0.1028 ns | 0.1143 ns |  0.49 |    0.02 |         - |
|       IndexOf | a | b |  7.027 ns | 0.1696 ns | 0.1953 ns |  0.93 |    0.03 |         - |
|          XNOR | a | b |  7.573 ns | 0.1390 ns | 0.1300 ns |  1.00 |    0.00 |         - |
|         Equal | a | b |  7.973 ns | 0.1406 ns | 0.1316 ns |  1.05 |    0.02 |         - |
|            OR | a | b |  9.710 ns | 0.1285 ns | 0.1202 ns |  1.28 |    0.03 |         - |
| Globalization | a | b |  9.942 ns | 0.1443 ns | 0.1350 ns |  1.31 |    0.02 |         - |
|     ToUpperOR | a | b | 57.428 ns | 0.6314 ns | 0.5597 ns |  7.59 |    0.13 |         - |
