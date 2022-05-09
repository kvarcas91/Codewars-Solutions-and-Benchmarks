## Challenge

Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for the development and functioning of living organisms.

If you want to know more: http://en.wikipedia.org/wiki/DNA

In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". You function receives one side of the DNA (string, except for Haskell); you need to return the other complementary side. 
DNA strand is never empty or there is no DNA at all (again, except for Haskell).

More similar exercise are found here: http://rosalind.info/problems/list-view/ (source)

Example: (input --> output)

```c#
"ATTGC" --> "TAACG"
"GTAT" --> "CATA"
```

```c#
dnaStrand []        `shouldBe` []
dnaStrand [A,T,G,C] `shouldBe` [T,A,C,G]
dnaStrand [G,T,A,T] `shouldBe` [C,A,T,A]
dnaStrand [A,A,A,A] `shouldBe` [T,T,T,T]
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                       Method |                  dna |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |--------------------- |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|
|  ArrayCharReplaceWithForLoop | AGCTT(...)GCAGC [70] |    179.13 ns |   0.718 ns |   0.600 ns |  0.56 |    0.00 | 0.0587 |     308 B |
|         StringBuilderForLoop | AGCTT(...)GCAGC [70] |    319.62 ns |   3.156 ns |   2.953 ns |  1.00 |    0.00 | 0.1092 |     573 B |
| StringReplaceWithPlaceholder | AGCTT(...)GCAGC [70] |    386.87 ns |   2.959 ns |   2.624 ns |  1.21 |    0.02 | 0.1783 |     937 B |
|      StringReplaceAndToUpper | AGCTT(...)GCAGC [70] |  1,285.70 ns |  16.458 ns |  15.395 ns |  4.02 |    0.05 | 0.1488 |     781 B |
|           LinqWithDictionary | AGCTT(...)GCAGC [70] |  1,661.27 ns |  16.766 ns |  14.863 ns |  5.19 |    0.08 | 0.2613 |   1,374 B |
|    ConcatWithLinqUsingSwitch | AGCTT(...)GCAGC [70] |  1,964.48 ns |  13.889 ns |  11.598 ns |  6.14 |    0.08 | 0.4196 |   2,207 B |
|               ConcatWithLinq | AGCTT(...)GCAGC [70] |  2,141.49 ns |   8.419 ns |   7.463 ns |  6.70 |    0.06 | 0.4120 |   2,175 B |
|                 JoinWithLinq | AGCTT(...)GCAGC [70] |  2,263.68 ns |  15.889 ns |  14.863 ns |  7.08 |    0.07 | 0.4120 |   2,175 B |
|          StringAppendForEach | AGCTT(...)GCAGC [70] |  2,380.78 ns |  27.139 ns |  24.058 ns |  7.44 |    0.11 | 1.1444 |   6,013 B |
|                 RegexReplace | AGCTT(...)GCAGC [70] | 17,590.97 ns | 252.012 ns | 235.733 ns | 55.04 |    0.83 | 2.5940 |  13,644 B |
|                              |                      |              |            |            |       |         |        |           |
|  ArrayCharReplaceWithForLoop | ATGCT(...)TTACG [21] |     77.04 ns |   1.373 ns |   1.217 ns |  0.68 |    0.01 | 0.0213 |     112 B |
|         StringBuilderForLoop | ATGCT(...)TTACG [21] |    113.20 ns |   1.800 ns |   1.683 ns |  1.00 |    0.00 | 0.0381 |     200 B |
| StringReplaceWithPlaceholder | ATGCT(...)TTACG [21] |    172.89 ns |   2.735 ns |   2.558 ns |  1.53 |    0.03 | 0.0641 |     336 B |
|          StringAppendForEach | ATGCT(...)TTACG [21] |    488.48 ns |   4.763 ns |   4.222 ns |  4.32 |    0.07 | 0.1450 |     761 B |
|      StringReplaceAndToUpper | ATGCT(...)TTACG [21] |    500.90 ns |   8.378 ns |   7.837 ns |  4.43 |    0.08 | 0.0534 |     280 B |
|    ConcatWithLinqUsingSwitch | ATGCT(...)TTACG [21] |    611.97 ns |  12.074 ns |  13.420 ns |  5.41 |    0.13 | 0.1392 |     733 B |
|               ConcatWithLinq | ATGCT(...)TTACG [21] |    654.15 ns |  12.466 ns |  12.244 ns |  5.77 |    0.09 | 0.1335 |     701 B |
|                 JoinWithLinq | ATGCT(...)TTACG [21] |    693.77 ns |  13.209 ns |  14.682 ns |  6.13 |    0.17 | 0.1335 |     701 B |
|           LinqWithDictionary | ATGCT(...)TTACG [21] |    699.75 ns |   8.032 ns |   7.513 ns |  6.18 |    0.12 | 0.1278 |     673 B |
|                 RegexReplace | ATGCT(...)TTACG [21] |  5,463.91 ns |  90.607 ns |  84.754 ns | 48.27 |    0.85 | 0.8087 |   4,242 B |
