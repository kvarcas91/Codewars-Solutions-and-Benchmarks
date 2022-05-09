using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata8
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    ///Sum all the numbers of a given array ( cq. list ), except the highest and the lowest element ( by value, not by index! ).
    ///The highest or lowest element respectively is a single element at each edge, even if there are more than one with the same value.
    public class SumWithoutHighestAndLowest
    {
        
        public IEnumerable<int[]> DataList()
        {
            yield return Enumerable.Range(0, 5).ToArray();
            yield return Enumerable.Range(0, 50).ToArray();
            yield return Enumerable.Range(0, 100).ToArray();
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int SumWithLinq(int[] numbers)
        {
            return numbers == null || numbers.Length < 2
            ? 0
            : numbers.Sum() - numbers.Max() - numbers.Min();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int SumWithForLoop(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                return 0;
            }

            int min = numbers[0];
            int max = numbers[1];
            int sum = 0;

            foreach (var x in numbers)
            {
                if (x > max) max = x;
                if (x < min) min = x;
                sum += x;
            }

            return sum - min - max;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int SumWithLinqOrderBy(int[] numbers) => numbers?.OrderBy(i => i).Skip(1).Take(numbers.Length - 2).Sum() ?? 0;
    }
}
