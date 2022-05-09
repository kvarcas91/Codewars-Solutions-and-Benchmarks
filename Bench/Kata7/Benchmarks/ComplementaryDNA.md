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
|  ArrayCharReplaceWithForLoop | AGCTT(...)GCAGC [70] |    184.15 ns |   2.790 ns |   2.329 ns |  0.55 |    0.01 | 0.0587 |     308 B |
|         StringBuilderForLoop | AGCTT(...)GCAGC [70] |    335.11 ns |   6.693 ns |   7.162 ns |  1.00 |    0.00 | 0.1092 |     573 B |
| StringReplaceWithPlaceholder | AGCTT(...)GCAGC [70] |    398.85 ns |   7.812 ns |   6.523 ns |  1.19 |    0.03 | 0.1783 |     937 B |
|      StringReplaceAndToUpper | AGCTT(...)GCAGC [70] |  1,299.04 ns |  25.450 ns |  28.288 ns |  3.88 |    0.13 | 0.1488 |     781 B |
|           LinqWithDictionary | AGCTT(...)GCAGC [70] |  1,710.92 ns |  19.026 ns |  15.887 ns |  5.11 |    0.11 | 0.2613 |   1,374 B |
|    ConcatWithLinqUsingSwitch | AGCTT(...)GCAGC [70] |  1,989.27 ns |   8.768 ns |   8.202 ns |  5.94 |    0.13 | 0.4196 |   2,207 B |
|               ConcatWithLinq | AGCTT(...)GCAGC [70] |  2,195.78 ns |  40.056 ns |  37.469 ns |  6.56 |    0.19 | 0.4120 |   2,175 B |
|                 JoinWithLinq | AGCTT(...)GCAGC [70] |  2,383.13 ns |  47.608 ns |  48.890 ns |  7.10 |    0.21 | 0.4120 |   2,175 B |
|                 RegexReplace | AGCTT(...)GCAGC [70] | 17,859.31 ns | 340.472 ns | 318.478 ns | 53.31 |    0.98 | 2.5940 |  13,644 B |
|                              |                      |              |            |            |       |         |        |           |
|  ArrayCharReplaceWithForLoop | ATGCT(...)TTACG [21] |     79.07 ns |   1.352 ns |   1.199 ns |  0.69 |    0.02 | 0.0213 |     112 B |
|         StringBuilderForLoop | ATGCT(...)TTACG [21] |    115.04 ns |   2.333 ns |   2.686 ns |  1.00 |    0.00 | 0.0381 |     200 B |
| StringReplaceWithPlaceholder | ATGCT(...)TTACG [21] |    173.01 ns |   3.471 ns |   3.409 ns |  1.50 |    0.04 | 0.0641 |     336 B |
|      StringReplaceAndToUpper | ATGCT(...)TTACG [21] |    508.05 ns |   9.926 ns |  11.817 ns |  4.41 |    0.16 | 0.0534 |     280 B |
|    ConcatWithLinqUsingSwitch | ATGCT(...)TTACG [21] |    602.87 ns |  11.801 ns |  12.119 ns |  5.24 |    0.13 | 0.1392 |     733 B |
|               ConcatWithLinq | ATGCT(...)TTACG [21] |    696.41 ns |  13.560 ns |  14.509 ns |  6.05 |    0.12 | 0.1335 |     701 B |
|                 JoinWithLinq | ATGCT(...)TTACG [21] |    736.46 ns |  14.589 ns |  23.139 ns |  6.40 |    0.17 | 0.1335 |     701 B |
|           LinqWithDictionary | ATGCT(...)TTACG [21] |    740.14 ns |  14.644 ns |  14.383 ns |  6.42 |    0.17 | 0.1278 |     673 B |
|                 RegexReplace | ATGCT(...)TTACG [21] |  5,622.52 ns | 112.456 ns | 153.931 ns | 49.02 |    1.63 | 0.8087 |   4,242 B |
