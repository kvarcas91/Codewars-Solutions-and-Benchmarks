using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata8
{
    /// <summary>
    /// In this simple exercise, you will build a program that takes a value, integer , and returns a list of its multiples up to another value, limit . If limit is a multiple of integer, it should be included as well. 
    /// There will only ever be positive integers passed into the function, not consisting of 0. The limit will always be higher than the base.
    /// For example, if the parameters passed are(2, 6), the function should return [2, 4, 6] as 2, 4, and 6 are the multiples of 2 up to 6.
    /// If you can, try writing it in only one line of code.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class FindMultiplesOfNumber
    {

        [Benchmark(Baseline = true)]
        [Arguments(2,12)]
        [Arguments(5, 5000)]
        public List<int> EnumerableWhere(int integer, int limit) => Enumerable.Range(1, limit).Where(x => x % integer == 0).ToList();

        [Benchmark]
        [Arguments(2, 12)]
        [Arguments(5, 5000)]
        public List<int> EnumerableSelect(int integer, int limit) => Enumerable.Range(1, limit / integer).Select(x => x * integer).ToList();


        [Benchmark]
        [Arguments(2, 12)]
        [Arguments(5, 5000)]
        public List<int> ForLoop(int integer, int limit)
        {
            List<int> result = new List<int>();
            for (int i = integer; i <= limit; i += integer)
            {
                result.Add(i);
            }
            return result;
        }

    }
}
