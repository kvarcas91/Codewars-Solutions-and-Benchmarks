using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bench.Kata8
{
    /// <summary>
    /// Given a non-negative integer, 3 for example, return a string with a murmur: "1 sheep...2 sheep...3 sheep...". Input will always be valid, i.e. no negative integers.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class IfYouCantSleeJustCountSheep
    {

        public IEnumerable<int> DataList()
        {
            yield return 5;
            yield return 50;
            yield return 500;
            yield return 5000;
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringArrayAndConcat(int n)
        {
            var strArr = new string[n];
            for (int i = 0; i < n; i++)
            {
                strArr[i] = $"{i + 1} sheep...";
            }
            return string.Concat(strArr);
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringAppend(int n)
        {
            string result = "";
            for (int i = 1; i <= n; i++)
            {
                result += $"{i} sheep...";
            }
            return result;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringBuilder(int n)
        {
            StringBuilder sheepBuilder = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                sheepBuilder.Append(i).Append(" sheep...");
            }
            return sheepBuilder.ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringBuilderFixedSize(int n)
        {
            StringBuilder sheepBuilder = new StringBuilder(n);
            for (int i = 1; i <= n; i++)
            {
                sheepBuilder.Append(i).Append(" sheep...");
            }
            return sheepBuilder.ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string LinqConcat(int n) => string.Concat(Enumerable.Range(1, n).Select(i => $"{i} sheep..."));

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string LinqRangeAggregate(int n) => Enumerable.Range(1, n).Aggregate("", (a, b) => a + b + " sheep...");
    }
}
