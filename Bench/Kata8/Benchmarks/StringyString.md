## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata8/StringyString.cs)

write me a function *stringy* that takes a *size* and returns a *string* of alternating *'1s'* and *'0s'*.

the string should start with a *1*.

a string with *size* 6 should return :*'101010'*.

with *size* 4 should return : *'1010'*.

with *size* 12 should return : *'101010101010'*.

The *size* will always be positive and will only use whole numbers.



---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                   Method | size |            Mean |         Error |        StdDev |          Median |  Ratio | RatioSD |     Gen 0 |    Gen 1 |  Gen 2 |    Allocated |
|------------------------- |----- |----------------:|--------------:|--------------:|----------------:|-------:|--------:|----------:|---------:|-------:|-------------:|
|     ForLoopWithCharArray |    5 |        18.66 ns |      0.422 ns |      0.395 ns |        18.55 ns |   1.00 |    0.00 |    0.0091 |        - |      - |         48 B |
|  ForLoopWithStringAppend |    5 |        80.96 ns |      1.668 ns |      2.227 ns |        80.15 ns |   4.38 |    0.15 |    0.0168 |        - |      - |         88 B |
|               LinqConcat |    5 |       169.12 ns |      3.361 ns |      4.820 ns |       171.21 ns |   9.22 |    0.30 |    0.0191 |        - |      - |        100 B |
| ForLoopWithStringBuilder |    5 |       334.11 ns |      6.623 ns |     12.110 ns |       334.21 ns |  18.20 |    0.69 |    0.0334 |        - |      - |        176 B |
|                 LinqJoin |    5 |       484.82 ns |      9.755 ns |     19.705 ns |       485.34 ns |  25.86 |    0.93 |    0.0458 |        - |      - |        240 B |
|                    Regex |    5 |       616.43 ns |      4.387 ns |      4.104 ns |       614.31 ns |  33.04 |    0.70 |    0.1030 |        - |      - |        545 B |
|                          |      |                 |               |               |                 |        |         |           |          |        |              |
|     ForLoopWithCharArray |   50 |       105.28 ns |      2.145 ns |      2.384 ns |       104.78 ns |   1.00 |    0.00 |    0.0435 |        - |      - |        228 B |
|               LinqConcat |   50 |       936.76 ns |      5.106 ns |      4.264 ns |       937.38 ns |   8.89 |    0.26 |    0.0362 |        - |      - |        192 B |
|  ForLoopWithStringAppend |   50 |     1,550.18 ns |     30.880 ns |     46.219 ns |     1,535.16 ns |  14.71 |    0.53 |    0.6256 |        - |      - |      3,289 B |
| ForLoopWithStringBuilder |   50 |     2,994.16 ns |      7.214 ns |      6.024 ns |     2,996.54 ns |  28.42 |    0.71 |    0.2213 |        - |      - |      1,166 B |
|                 LinqJoin |   50 |     3,798.82 ns |     74.366 ns |    113.564 ns |     3,734.25 ns |  36.13 |    1.54 |    0.3014 |        - |      - |      1,594 B |
|                    Regex |   50 |     4,288.94 ns |     85.067 ns |    132.439 ns |     4,242.76 ns |  40.82 |    1.54 |    0.7172 |        - |      - |      3,762 B |
|                          |      |                 |               |               |                 |        |         |           |          |        |              |
|     ForLoopWithCharArray |  500 |       842.06 ns |     16.228 ns |     18.688 ns |       832.76 ns |   1.00 |    0.00 |    0.3872 |   0.0019 |      - |      2,031 B |
|               LinqConcat |  500 |     9,071.20 ns |    178.914 ns |    206.037 ns |     9,143.15 ns |  10.78 |    0.35 |    0.4425 |        - |      - |      2,360 B |
| ForLoopWithStringBuilder |  500 |    29,846.58 ns |    577.649 ns |    882.131 ns |    30,168.78 ns |  35.35 |    1.73 |    1.9531 |        - |      - |     10,295 B |
|                 LinqJoin |  500 |    37,277.94 ns |    732.122 ns |    871.539 ns |    36,801.95 ns |  44.30 |    1.25 |    3.1128 |        - |      - |     16,380 B |
|                    Regex |  500 |    38,823.83 ns |    766.948 ns |  1,023.854 ns |    38,334.43 ns |  46.16 |    1.86 |    6.5308 |   0.0610 |      - |     34,523 B |
|  ForLoopWithStringAppend |  500 |    52,143.11 ns |    944.686 ns |    883.659 ns |    51,614.09 ns |  62.03 |    1.23 |   49.2554 |   0.2441 |      - |    258,380 B |
|                          |      |                 |               |               |                 |        |         |           |          |        |              |
|     ForLoopWithCharArray | 5000 |     6,976.50 ns |    136.819 ns |    140.503 ns |     6,899.96 ns |   1.00 |    0.00 |    3.8223 |   0.1755 |      - |     20,052 B |
|               LinqConcat | 5000 |    83,926.42 ns |    802.877 ns |    626.833 ns |    83,970.69 ns |  11.99 |    0.30 |    5.1270 |   0.1221 |      - |     26,930 B |
| ForLoopWithStringBuilder | 5000 |   290,151.73 ns |  5,607.949 ns |  6,000.443 ns |   288,575.22 ns |  41.60 |    1.30 |   20.0195 |   1.4648 |      - |    106,958 B |
|                 LinqJoin | 5000 |   372,721.58 ns |  7,348.529 ns | 11,221.980 ns |   367,540.87 ns |  52.93 |    1.86 |   31.7383 |   2.4414 |      - |    167,119 B |
|                    Regex | 5000 |   379,432.13 ns |  7,428.507 ns | 11,344.115 ns |   379,500.93 ns |  55.23 |    1.64 |   65.9180 |   3.9063 |      - |    347,522 B |
|  ForLoopWithStringAppend | 5000 | 1,438,795.81 ns | 26,547.305 ns | 24,832.366 ns | 1,435,641.41 ns | 205.77 |    6.29 | 4787.1094 | 136.7188 | 3.9063 | 25,127,958 B |
