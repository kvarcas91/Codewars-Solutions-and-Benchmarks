using Bench.Kata7;
using Bench.Kata8;
using BenchmarkDotNet.Running;

namespace Bench
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var results = BenchmarkRunner.Run<StringRepeat>();
            // var results = BenchmarkRunner.Run<SumWithoutHighestAndLowest>();
            var results = BenchmarkRunner.Run<CheckTheExam>();

        }
    }
}
