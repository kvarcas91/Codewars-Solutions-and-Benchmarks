## Challenge

The first input array is the key to the correct answers to an exam, like ["a", "a", "b", "d"]. The second one contains a student's submitted answers.

The two arrays are not empty and are the same length. Return the score for this array of answers, giving +4 for each correct answer, -1 for each incorrect answer, and +0 for each blank answer, represented as an empty string (in C the space character is used).

If the score < 0, return 0.

For example:

```c#
checkExam(["a", "a", "b", "b"], ["a", "c", "b", "d"]) ? 6
checkExam(["a", "a", "c", "b"], ["a", "a", "b",  ""]) ? 7
checkExam(["a", "a", "b", "c"], ["a", "a", "b", "c"]) ? 16
checkExam(["b", "c", "b", "a"], ["",  "a", "a", "c"]) ? 0
```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                 Method |       arr1 |       arr2 |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------- |----------- |----------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|
|         SumWithForLoop |  String[4] |  String[4] |  18.23 ns | 0.121 ns | 0.114 ns |  1.00 |    0.00 |      - |         - |
| SumWithForLoopOneLiner |  String[4] |  String[4] |  18.46 ns | 0.096 ns | 0.090 ns |  1.01 |    0.01 |      - |         - |
|         SumWithForLoop |  String[8] |  String[8] |  36.15 ns | 0.188 ns | 0.167 ns |  1.98 |    0.01 |      - |         - |
| SumWithForLoopOneLiner |  String[8] |  String[8] |  37.52 ns | 0.218 ns | 0.204 ns |  2.06 |    0.02 |      - |         - |
|         SumWithForLoop | String[20] | String[20] |  99.86 ns | 0.498 ns | 0.466 ns |  5.48 |    0.04 |      - |         - |
| SumWithForLoopOneLiner | String[20] | String[20] | 100.77 ns | 0.512 ns | 0.479 ns |  5.53 |    0.04 |      - |         - |
|      SumPointsWithLinq |  String[4] |  String[4] | 103.00 ns | 0.547 ns | 0.511 ns |  5.65 |    0.05 | 0.0206 |     108 B |
|      SumPointsWithLinq |  String[8] |  String[8] | 173.89 ns | 1.853 ns | 1.733 ns |  9.54 |    0.10 | 0.0205 |     108 B |
|      SumPointsWithLinq | String[20] | String[20] | 344.33 ns | 0.747 ns | 0.699 ns | 18.89 |    0.12 | 0.0205 |     108 B |
