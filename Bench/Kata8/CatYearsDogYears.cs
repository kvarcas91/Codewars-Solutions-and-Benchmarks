using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata8
{
    /// <summary>
    /// I have a cat and a dog.
    ///    I got them at the same time as kitten/puppy.That was humanYears years ago.

    ///   Return their respective ages now as [humanYears, catYears, dogYears]

    ///    NOTES:

    ///    humanYears >= 1
    ///    humanYears are whole numbers only

    ///Cat Years

    ///    15 cat years for first year
    ///    +9 cat years for second year
    ///    +4 cat years for each year after that

    ///Dog Years

    ///    15 dog years for first year
    ///    +9 dog years for second year
    ///    +5 dog years for each year after that

    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class CatYearsDogYears
    {

        public IEnumerable<int> DataList()
        {
            yield return 1;
            yield return 10;
            yield return 100;
            yield return 1000;
            yield return 10000;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] SwitchAndForLoop(int humanYears)
        {
            var catYear = 24;
            var dogYear = 24;

            switch (humanYears)
            {
                case 1:
                    return new int[] { humanYears, 15, 15 };
                case 2:
                    return new int[] { humanYears, 24, 24 };
                default:
                    for (int i = 3; i <= humanYears; i++)
                    {
                        catYear += 4;
                        dogYear += 5;
                    }
                    break;
            }

            return new int[] { humanYears, catYear, dogYear };
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int[] TenaryAndMathOp(int humanYears)
        {
            int catYear = 15 + (humanYears >= 2 ? 9 + 4 * (humanYears - 2) : 0);
            int dogYear = 15 + (humanYears >= 2 ? 9 + 5 * (humanYears - 2) : 0);

            return new int[] { humanYears, catYear, dogYear };
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] IfStatementsAndMathOp(int humanYears)
        {
            if (humanYears == 0) return new int[] { 0, 0, 0 };
            int catYears = 0, dogYears = 0;
            if (humanYears == 1)
            {
                catYears = 15;
                dogYears = 15;
            }
            else if (humanYears == 2)
            {
                catYears = 15 + 9;
                dogYears = 15 + 9;
            }
            else
            {
                catYears = 15 + 9 + (humanYears - 2) * 4;
                dogYears = 15 + 9 + (humanYears - 2) * 5;
            }
            return new int[] { humanYears, catYears, dogYears };
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] TenaryOneLiner(int humanYears) => 
            humanYears < 2 ? new int[] { 1, 15, 15 } : humanYears < 3 ? new int[] { 2, 24, 24 } : new int[] { humanYears, 24 + (humanYears - 2) * 4, 24 + (humanYears - 2) * 5 };

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqWhileYield(int humanYears)
        {
            return new int[]
             {
              humanYears,
              CatYears().Take(humanYears).Sum(),
              DogYears().Take(humanYears).Sum()
             };
        }

        IEnumerable<int> CatYears()
        {
            yield return 15;
            yield return 9;
            while (true)
            {
                yield return 4;
            }
        }

        IEnumerable<int> DogYears()
        {
            yield return 15;
            yield return 9;
            while (true)
            {
                yield return 5;
            }
        }

    }
}
