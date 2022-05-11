## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/AnagramDetection.cs)

An anagram is the result of rearranging the letters of a word to produce a new word.

Note: anagrams are case insensitive

Complete the function to return *true* if the two arguments given are anagrams of each other; *return* false otherwise.

Examples


```c#
"foefet" is an anagram of "toffee"

"Buckethead" is an anagram of "DeathCubeK"
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                       Method |                 test |             original |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |--------------------- |--------------------- |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|----------:|
| LinqAggregateAndStringAppend |           Buckethead |           DeathCubeK |   279.0 ns |  4.98 ns |   4.42 ns |   280.4 ns |  0.34 |    0.01 | 0.0248 |     132 B |
|        ArraySortAndNewString |           Buckethead |           DeathCubeK |   396.7 ns |  5.27 ns |   4.93 ns |   395.4 ns |  0.48 |    0.01 | 0.0396 |     208 B |
|           ArraySortAndConcat |           Buckethead |           DeathCubeK |   831.4 ns | 12.63 ns |  11.19 ns |   833.2 ns |  1.00 |    0.00 | 0.1535 |     809 B |
|  LinqOrderByAndSequanceEqual |           Buckethead |           DeathCubeK | 1,197.0 ns | 22.19 ns |  21.79 ns | 1,193.4 ns |  1.44 |    0.03 | 0.1221 |     649 B |
|         LinqOrderByAndConcat |           Buckethead |           DeathCubeK | 1,593.3 ns | 31.66 ns |  35.19 ns | 1,581.5 ns |  1.93 |    0.04 | 0.2441 |   1,282 B |
|                              |                      |                      |            |          |           |            |       |         |        |           |
| LinqAggregateAndStringAppend |    basiparachromatin |    marsipobranchiata |   380.2 ns |  7.56 ns |  11.08 ns |   377.3 ns |  0.31 |    0.01 | 0.0358 |     188 B |
|        ArraySortAndNewString |    basiparachromatin |    marsipobranchiata |   531.8 ns | 10.46 ns |  12.05 ns |   533.5 ns |  0.44 |    0.02 | 0.0544 |     288 B |
|           ArraySortAndConcat |    basiparachromatin |    marsipobranchiata | 1,214.2 ns | 23.83 ns |  29.26 ns | 1,223.7 ns |  1.00 |    0.00 | 0.2441 |   1,282 B |
|  LinqOrderByAndSequanceEqual |    basiparachromatin |    marsipobranchiata | 1,891.8 ns | 37.79 ns |  54.19 ns | 1,873.1 ns |  1.56 |    0.05 | 0.1717 |     913 B |
|         LinqOrderByAndConcat |    basiparachromatin |    marsipobranchiata | 2,497.0 ns | 49.74 ns |  68.08 ns | 2,505.4 ns |  2.05 |    0.07 | 0.3738 |   1,963 B |
|                              |                      |                      |            |          |           |            |       |         |        |           |
| LinqAggregateAndStringAppend |               foefet |               toffee |   206.0 ns |  4.11 ns |   5.34 ns |   204.3 ns |  0.33 |    0.01 | 0.0191 |     100 B |
|        ArraySortAndNewString |               foefet |               toffee |   304.7 ns |  5.98 ns |   6.89 ns |   302.9 ns |  0.49 |    0.01 | 0.0305 |     160 B |
|           ArraySortAndConcat |               foefet |               toffee |   624.6 ns | 12.51 ns |  14.40 ns |   622.6 ns |  1.00 |    0.00 | 0.1020 |     537 B |
|  LinqOrderByAndSequanceEqual |               foefet |               toffee |   762.2 ns | 15.15 ns |  22.68 ns |   779.1 ns |  1.22 |    0.05 | 0.0944 |     497 B |
|         LinqOrderByAndConcat |               foefet |               toffee | 1,041.3 ns | 20.44 ns |  28.66 ns | 1,053.7 ns |  1.67 |    0.07 | 0.1678 |     889 B |
|                              |                      |                      |            |          |           |            |       |         |        |           |
| LinqAggregateAndStringAppend | hydro(...)rones [27] | hydro(...)erone [27] |   534.9 ns | 10.49 ns |  13.64 ns |   543.4 ns |  0.31 |    0.01 | 0.0505 |     268 B |
|        ArraySortAndNewString | hydro(...)rones [27] | hydro(...)erone [27] |   742.0 ns | 14.14 ns |  13.23 ns |   739.8 ns |  0.43 |    0.01 | 0.0772 |     409 B |
|           ArraySortAndConcat | hydro(...)rones [27] | hydro(...)erone [27] | 1,719.0 ns | 33.69 ns |  40.10 ns | 1,720.5 ns |  1.00 |    0.00 | 0.3738 |   1,963 B |
|  LinqOrderByAndSequanceEqual | hydro(...)rones [27] | hydro(...)erone [27] | 3,293.5 ns | 65.35 ns | 105.52 ns | 3,318.1 ns |  1.91 |    0.08 | 0.2022 |   1,074 B |
|         LinqOrderByAndConcat | hydro(...)rones [27] | hydro(...)erone [27] | 4,227.0 ns | 83.79 ns | 144.54 ns | 4,246.3 ns |  2.46 |    0.11 | 0.5188 |   2,724 B |
