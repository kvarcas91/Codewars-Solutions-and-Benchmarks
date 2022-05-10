## Challenge

A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.

Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.

Arguments 

* First argument (required): the original string to be converted.
* Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. The JavaScript/CoffeeScript tests will pass undefined when this argument is unused.


Example


```c#
Kata.TitleCase("a clash of KINGS", "a an the of")   => "A Clash of Kings"
Kata.TitleCase("THE WIND IN THE WILLOWS", "The In") => "The Wind in the Willows"
Kata.TitleCase("the quick brown fox")               => "The Quick Brown Fox"

```
---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|           Method |                title |  minorWords |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------- |--------------------- |------------ |---------:|----------:|----------:|------:|--------:|-------:|----------:|
|          ForLoop | THE W(...)LLOWS [23] | a an the of | 1.516 μs | 0.0167 μs | 0.0156 μs |  1.00 |    0.00 | 0.1965 |      1 KB |
| LinqWithTextInfo | THE W(...)LLOWS [23] | a an the of | 2.604 μs | 0.0082 μs | 0.0069 μs |  1.72 |    0.02 | 0.2632 |      1 KB |
|             Linq | THE W(...)LLOWS [23] | a an the of | 3.138 μs | 0.0193 μs | 0.0171 μs |  2.07 |    0.03 | 0.2937 |      2 KB |
|            Regex | THE W(...)LLOWS [23] | a an the of | 8.078 μs | 0.0159 μs | 0.0141 μs |  5.33 |    0.06 | 0.2899 |      1 KB |
