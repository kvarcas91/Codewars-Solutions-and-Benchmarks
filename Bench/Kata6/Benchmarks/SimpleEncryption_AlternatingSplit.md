## Challenge

Implement a pseudo-encryption algorithm which given a string *S* and an integer *N* concatenates all the odd-indexed characters of *S* with all the even-indexed characters of *S*, this process should be repeated *N* times.

Examples:

```c#
encrypt("012345", 1)  =>  "135024"
encrypt("012345", 2)  =>  "135024"  ->  "304152"
encrypt("012345", 3)  =>  "135024"  ->  "304152"  ->  "012345"

encrypt("01234", 1)  =>  "13024"
encrypt("01234", 2)  =>  "13024"  ->  "32104"
encrypt("01234", 3)  =>  "13024"  ->  "32104"  ->  "20314"
```

Together with the encryption function, you should also implement a decryption function which reverses the process.

If the string *S* is an empty value or the integer *N* is not positive, return the first argument without changes.

---

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22616
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
  [Host]             : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT
  .NET Framework 4.8 : .NET Framework 4.8 (4.8.9032.0), X86 LegacyJIT

Job=.NET Framework 4.8  Runtime=.NET Framework 4.8  

```
|                   Method |                 text |   n |            Mean |         Error |        StdDev | Ratio | RatioSD |    Gen 0 |   Allocated |
|------------------------- |--------------------- |---- |----------------:|--------------:|--------------:|------:|--------:|---------:|------------:|
|      ForLoopAndCharArray |               012345 |   2 |        94.20 ns |      0.928 ns |      0.868 ns |  0.32 |    0.00 |   0.0397 |       208 B |
|  ForLoopAndStringBuilder |               012345 |   2 |       299.00 ns |      1.534 ns |      1.281 ns |  1.00 |    0.00 |   0.1345 |       705 B |
|            LinqAggregate |               012345 |   2 |       452.84 ns |      1.020 ns |      0.797 ns |  1.51 |    0.01 |   0.1311 |       689 B |
| RecursionAndStringAppend |               012345 |   2 |       518.01 ns |      2.418 ns |      2.019 ns |  1.73 |    0.01 |   0.1450 |       761 B |
|   ForLoopAndStringAppend |               012345 |   2 |       653.69 ns |      3.741 ns |      3.123 ns |  2.19 |    0.01 |   0.1869 |       981 B |
|                     Linq |               012345 |   2 |     1,933.18 ns |     17.829 ns |     15.805 ns |  6.46 |    0.06 |   0.3853 |     2,027 B |
|                          |                      |     |                 |               |               |       |         |          |             |
|      ForLoopAndCharArray | qwert(...)56789 [61] | 200 |    65,744.10 ns |    346.587 ns |    307.241 ns |  0.52 |    0.00 |  20.7520 |   108,961 B |
|  ForLoopAndStringBuilder | qwert(...)56789 [61] | 200 |   126,436.05 ns |    949.983 ns |    842.135 ns |  1.00 |    0.00 |  42.4805 |   222,730 B |
|            LinqAggregate | qwert(...)56789 [61] | 200 |   202,642.27 ns |    754.493 ns |    630.036 ns |  1.60 |    0.01 |  27.0996 |   142,755 B |
| RecursionAndStringAppend | qwert(...)56789 [61] | 200 |   786,563.32 ns |  2,723.688 ns |  2,126.476 ns |  6.22 |    0.04 | 347.6563 | 1,824,288 B |
|   ForLoopAndStringAppend | qwert(...)56789 [61] | 200 |   862,650.41 ns |  4,210.699 ns |  3,516.124 ns |  6.82 |    0.05 | 371.0938 | 1,947,957 B |
|                     Linq | qwert(...)56789 [61] | 200 | 1,074,880.73 ns | 11,743.710 ns | 10,410.493 ns |  8.50 |    0.11 | 226.5625 | 1,193,768 B |
