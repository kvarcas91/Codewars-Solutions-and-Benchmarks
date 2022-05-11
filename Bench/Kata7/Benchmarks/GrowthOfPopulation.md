## Challenge [(solutions)](https://github.com/kvarcas91/Codewars-Solutions-and-Benchmarks/blob/master/Bench/Kata7/GrowthOfPopulation.cs)

In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by 2 percent per year and moreover 50 new inhabitants per year come to live in the town. 
How many years does the town need to see its population greater or equal to p = 1200 inhabitants?

For example:

``` ini
At the end of the first year there will be: 
1000 + 1000 * 0.02 + 50 => 1070 inhabitants

At the end of the 2nd year there will be: 
1070 + 1070 * 0.02 + 50 => 1141 inhabitants (** number of inhabitants is an integer **)

At the end of the 3rd year there will be:
1141 + 1141 * 0.02 + 50 => 1213

It will need 3 entire years.
```

More generally given parameters:

``` c#
p0, percent, aug (inhabitants coming or leaving each year), p (population to surpass)
```

the function *nb_year* should return *n* number of entire years needed to get a population greater or equal to *p*.
aug is an integer, percent a positive or null floating number, p0 and p are positive integers (> 0)

Example:

``` c#
nb_year(1500, 5, 100, 5000) -> 15
nb_year(1500000, 2.5, 10000, 2000000) -> 10
```

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                Method |      p0 | percent |   aug |       p |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated |
|---------------------- |-------- |-------- |------ |-------- |----------:|---------:|---------:|------:|--------:|----------:|
| AdditionWithWhileLoop |    1500 |       5 |   100 |    5000 |  58.85 ns | 0.555 ns | 0.519 ns |  0.59 |    0.01 |         - |
|   AdditionWithForLoop |    1500 |       5 |   100 |    5000 | 100.15 ns | 1.174 ns | 1.098 ns |  1.00 |    0.00 |         - |
| AdditionWithRecursion |    1500 |       5 |   100 |    5000 | 138.90 ns | 0.933 ns | 0.827 ns |  1.39 |    0.02 |         - |
|                       |         |         |       |         |           |          |          |       |         |           |
| AdditionWithWhileLoop | 1500000 |     2.5 | 10000 | 2000000 |  32.96 ns | 0.258 ns | 0.242 ns |  0.63 |    0.01 |         - |
|   AdditionWithForLoop | 1500000 |     2.5 | 10000 | 2000000 |  52.35 ns | 0.414 ns | 0.387 ns |  1.00 |    0.00 |         - |
| AdditionWithRecursion | 1500000 |     2.5 | 10000 | 2000000 |  73.61 ns | 0.483 ns | 0.403 ns |  1.40 |    0.01 |         - |
