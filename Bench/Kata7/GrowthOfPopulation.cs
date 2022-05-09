using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace Bench.Kata7
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]

    /// In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by 2 percent per year and moreover 50 new inhabitants per year 
    /// come to live in the town. How many years does the town need to see its population greater or equal to p = 1200 inhabitants?
    public class GrowthOfPopulation
    {
        [Benchmark(Baseline = true)]
        [Arguments(1500, 5, 100, 5000)]
        [Arguments(1500000, 2.5, 10000, 2000000)]
        public int AdditionWithForLoop(int p0, double percent, int aug, int p)
        {
            int year;
            for (year = 0; p0 < p; year++)
                p0 += (int)(p0 * percent / 100) + aug;
            return year;
        }

        [Benchmark]
        [Arguments(1500, 5, 100, 5000)]
        [Arguments(1500000, 2.5, 10000, 2000000)]
        public int AdditionWithWhileLoop(int p0, double percent, int aug, int p)
        {
            int i = 0;
            while (p0 < p)
            {
                p0 = (int)(p0 * (1 + percent / 100)) + aug;
                i++;
            }
            return i;
        }

        [Benchmark]
        [Arguments(1500, 5, 100, 5000)]
        [Arguments(1500000, 2.5, 10000, 2000000)]
        public int AdditionWithRecursion(int p0, double percent, int aug, int p) => p0 >= p? 0 : 1 + AdditionWithRecursion((int) (p0 + p0* percent / 100 + aug), percent, aug, p);
    }
}
