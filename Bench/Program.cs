using Bench.Kata7;
using Bench.Kata8;
using BenchmarkDotNet.Running;
using System.Linq;

namespace Bench
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var results = BenchmarkRunner.Run<StringRepeat>();
            // var results = BenchmarkRunner.Run<SumWithoutHighestAndLowest>();
            // var results = BenchmarkRunner.Run<CheckTheExam>();
            // var results = BenchmarkRunner.Run<SortNumbers>();
            // var results = BenchmarkRunner.Run<GrowthOfPopulation>();
            // var results = BenchmarkRunner.Run<ComplementaryDNA>();
            var results = BenchmarkRunner.Run<MakeFunctionThatDoesArithmetic>();
        }
    }
}
