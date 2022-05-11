using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Text.RegularExpressions.Regex;

namespace Bench.Kata8
{
    /// <summary>
    /// write me a function stringy that takes a size and returns a string of alternating '1s' and '0s'.
    /// the string should start with a 1.
    /// a string with size 6 should return :'101010'.
    /// with size 4 should return : '1010'.
    /// with size 12 should return : '101010101010'.
    /// The size will always be positive and will only use whole numbers.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class StringyString
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
        public string ForLoopWithCharArray(int size)
        {
            var arr = new char[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i % 2 == 0 ? '1' : '0';
            }

            return new string(arr);
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringBuilder(int size)
        {
            var result = new StringBuilder();
            for (var i = 1; i <= size; i++)
            {
                result.Append(i % 2);
            }
            return result.ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string LinqJoin(int size) => string.Join("", Enumerable.Range(0, size).Select(x => (x + 1) % 2));

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string LinqConcat(int size) => string.Concat(Enumerable.Range(0, size).Select(x => x % 2 == 0 ? "1" : "0"));

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string Regex(int size) => Replace(new string('1', size), "11", "10");

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ForLoopWithStringAppend(int size)
        {
            var aux = string.Empty;
            for (int i = 0; i < size; i++)
                if (i % 2 == 0)
                    aux += "1";
                else
                    aux += "0";
            return aux;
        }

    }
}
