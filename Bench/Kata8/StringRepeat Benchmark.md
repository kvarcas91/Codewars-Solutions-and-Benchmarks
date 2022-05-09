
## Challenge

Write a function called repeatStr which repeats the given string *string* exactly **n** times.

```c#
repeatStr(6, "I") // "IIIIII"
repeatStr(5, "Hello") // "HelloHelloHelloHelloHello"
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```


|                     Method | repeatCount |  text |         Mean |     Error |    StdDev |       Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|--------------------------- |------------ |------ |-------------:|----------:|----------:|-------------:|------:|--------:|--------:|-------:|----------:|
|  StringAppendWithRecursion |           2 | hello |     19.64 ns |  0.411 ns |  0.384 ns |     19.69 ns |  0.42 |    0.01 |  0.0069 |      - |      36 B |
|               StringAppend |           2 | hello |     22.09 ns |  0.340 ns |  0.318 ns |     22.17 ns |  0.47 |    0.01 |  0.0069 |      - |      36 B |
|          JoinWithNewString |           2 | hello |     33.37 ns |  0.732 ns |  1.049 ns |     33.36 ns |  0.71 |    0.02 |  0.0114 |      - |      60 B |
|       StringBuilderForLoop |           2 | hello |     47.12 ns |  0.270 ns |  0.252 ns |     47.22 ns |  1.00 |    0.00 |  0.0206 |      - |     108 B |
|       NewStringWithReplace |           2 | hello |     51.15 ns |  0.862 ns |  0.807 ns |     50.81 ns |  1.09 |    0.02 |  0.0137 |      - |      72 B |
|           StringPadReplace |           2 | hello |     56.93 ns |  1.131 ns |  1.058 ns |     56.74 ns |  1.21 |    0.02 |  0.0107 |      - |      56 B |
|    StringBuilderWithInsert |           2 | hello |     64.27 ns |  0.580 ns |  0.542 ns |     64.08 ns |  1.36 |    0.01 |  0.0182 |      - |      96 B |
| NewStringWithLINQAggregate |           2 | hello |     64.54 ns |  1.290 ns |  1.267 ns |     64.69 ns |  1.37 |    0.03 |  0.0236 |      - |     124 B |
|      ConcatWithArrayRepeat |           2 | hello |     75.80 ns |  0.638 ns |  0.566 ns |     75.71 ns |  1.61 |    0.01 |  0.0244 |      - |     128 B |
|             ConcatWithLinq |           2 | hello |     93.27 ns |  1.857 ns |  1.737 ns |     92.42 ns |  1.98 |    0.04 |  0.0144 |      - |      76 B |
|               JoinWithLinq |           2 | hello |     98.08 ns |  1.192 ns |  1.115 ns |     98.34 ns |  2.08 |    0.02 |  0.0144 |      - |      76 B |
|                            |             |       |              |           |           |              |       |         |         |        |           |
|       StringBuilderForLoop |           5 |     A |     40.86 ns |  0.880 ns |  0.864 ns |     40.88 ns |  1.00 |    0.00 |  0.0183 |      - |      96 B |
|          JoinWithNewString |           5 |     A |     61.60 ns |  1.273 ns |  1.611 ns |     62.54 ns |  1.51 |    0.04 |  0.0114 |      - |      60 B |
|       NewStringWithReplace |           5 |     A |     68.87 ns |  1.424 ns |  1.399 ns |     69.64 ns |  1.69 |    0.04 |  0.0122 |      - |      64 B |
|           StringPadReplace |           5 |     A |     75.35 ns |  1.560 ns |  1.669 ns |     74.90 ns |  1.84 |    0.06 |  0.0091 |      - |      48 B |
|  StringAppendWithRecursion |           5 |     A |     81.40 ns |  1.530 ns |  1.431 ns |     82.14 ns |  2.00 |    0.04 |  0.0168 |      - |      88 B |
|               StringAppend |           5 |     A |     81.41 ns |  1.492 ns |  1.396 ns |     81.83 ns |  2.00 |    0.06 |  0.0168 |      - |      88 B |
|    StringBuilderWithInsert |           5 |     A |     86.20 ns |  1.739 ns |  1.786 ns |     86.56 ns |  2.11 |    0.06 |  0.0144 |      - |      76 B |
|             ConcatWithLinq |           5 |     A |    110.54 ns |  2.236 ns |  2.828 ns |    110.91 ns |  2.72 |    0.08 |  0.0122 |      - |      64 B |
|               JoinWithLinq |           5 |     A |    122.74 ns |  2.385 ns |  2.651 ns |    123.87 ns |  3.01 |    0.04 |  0.0122 |      - |      64 B |
|      ConcatWithArrayRepeat |           5 |     A |    133.97 ns |  2.598 ns |  2.552 ns |    135.48 ns |  3.28 |    0.07 |  0.0274 |      - |     144 B |
| NewStringWithLINQAggregate |           5 |     A |    134.13 ns |  2.461 ns |  2.302 ns |    134.32 ns |  3.29 |    0.08 |  0.0358 |      - |     188 B |
|                            |             |       |              |           |           |              |       |         |         |        |           |
|       NewStringWithReplace |          20 | hello |    216.93 ns |  4.333 ns |  4.636 ns |    217.72 ns |  0.64 |    0.01 |  0.0548 |      - |     288 B |
|          JoinWithNewString |          20 | hello |    223.59 ns |  4.402 ns |  6.026 ns |    221.51 ns |  0.66 |    0.02 |  0.0594 |      - |     312 B |
|           StringPadReplace |          20 | hello |    227.28 ns |  3.400 ns |  3.180 ns |    229.07 ns |  0.67 |    0.02 |  0.0517 |      - |     272 B |
|    StringBuilderWithInsert |          20 | hello |    292.75 ns |  5.727 ns |  5.357 ns |    295.36 ns |  0.86 |    0.02 |  0.0868 |      - |     457 B |
|       StringBuilderForLoop |          20 | hello |    340.18 ns |  5.901 ns |  5.519 ns |    342.85 ns |  1.00 |    0.00 |  0.1206 |      - |     633 B |
|             ConcatWithLinq |          20 | hello |    404.55 ns |  7.983 ns |  9.504 ns |    410.66 ns |  1.19 |    0.02 |  0.0486 |      - |     256 B |
|      ConcatWithArrayRepeat |          20 | hello |    428.99 ns |  7.912 ns |  7.401 ns |    425.12 ns |  1.26 |    0.02 |  0.0982 |      - |     517 B |
|               JoinWithLinq |          20 | hello |    461.63 ns |  9.178 ns | 13.737 ns |    464.35 ns |  1.37 |    0.05 |  0.0486 |      - |     256 B |
|               StringAppend |          20 | hello |    739.34 ns |  6.944 ns |  6.495 ns |    741.91 ns |  2.17 |    0.04 |  0.4530 |      - |   2,380 B |
|  StringAppendWithRecursion |          20 | hello |    780.19 ns | 14.867 ns | 13.907 ns |    778.11 ns |  2.29 |    0.06 |  0.4530 |      - |   2,380 B |
| NewStringWithLINQAggregate |          20 | hello |    874.55 ns | 11.890 ns | 11.122 ns |    878.07 ns |  2.57 |    0.06 |  0.4835 | 0.0010 |   2,540 B |
|                            |             |       |              |           |           |              |       |         |         |        |           |
|       NewStringWithReplace |         100 | hello |    847.95 ns | 14.395 ns | 13.465 ns |    853.46 ns |  0.66 |    0.02 |  0.2375 | 0.0010 |   1,250 B |
|           StringPadReplace |         100 | hello |    889.60 ns | 17.430 ns | 17.118 ns |    878.38 ns |  0.69 |    0.01 |  0.2346 | 0.0010 |   1,234 B |
|          JoinWithNewString |         100 | hello |  1,055.02 ns | 20.532 ns | 31.355 ns |  1,068.85 ns |  0.82 |    0.03 |  0.2728 | 0.0019 |   1,434 B |
|    StringBuilderWithInsert |         100 | hello |  1,296.99 ns | 25.437 ns | 24.983 ns |  1,305.86 ns |  1.00 |    0.03 |  0.3910 | 0.0038 |   2,059 B |
|       StringBuilderForLoop |         100 | hello |  1,298.20 ns | 25.139 ns | 29.927 ns |  1,307.32 ns |  1.00 |    0.00 |  0.4349 | 0.0038 |   2,283 B |
|      ConcatWithArrayRepeat |         100 | hello |  1,897.03 ns | 37.973 ns | 46.635 ns |  1,913.03 ns |  1.46 |    0.04 |  0.4330 | 0.0019 |   2,280 B |
|             ConcatWithLinq |         100 | hello |  2,033.39 ns | 40.714 ns | 52.940 ns |  2,049.01 ns |  1.57 |    0.05 |  0.4425 | 0.0038 |   2,323 B |
|               JoinWithLinq |         100 | hello |  2,348.88 ns | 46.185 ns | 77.165 ns |  2,369.10 ns |  1.81 |    0.07 |  0.4425 | 0.0038 |   2,323 B |
|               StringAppend |         100 | hello | 10,152.73 ns | 57.277 ns | 50.775 ns | 10,154.75 ns |  7.84 |    0.19 |  9.9182 | 0.0763 |  52,055 B |
|  StringAppendWithRecursion |         100 | hello | 10,593.77 ns | 50.159 ns | 41.885 ns | 10,580.33 ns |  8.19 |    0.18 |  9.9182 | 0.0763 |  52,055 B |
| NewStringWithLINQAggregate |         100 | hello | 10,617.99 ns | 38.995 ns | 36.476 ns | 10,607.11 ns |  8.21 |    0.18 | 10.0098 | 0.0916 |  52,537 B |
