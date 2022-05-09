using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace Bench.Kata8
{
    /// <summary>
    /// Make a function that will return a greeting statement that uses an input; your program should return, "Hello, <name> how are you doing today?".
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class ReturningStrings
    {

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("MaybeALittleBitLongerName")]
        public string Interpolation(string name) => $"Hello, {name} how are you doing today?";

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("MaybeALittleBitLongerName")]
        public string Format(string name) => string.Format("Hello, {0} how are you doing today?", name);

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("MaybeALittleBitLongerName")]
        public string Add(string name) => "Hello, " + name + " how are you doing today?";

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("MaybeALittleBitLongerName")]
        public string Insert(string name)
        {
            string str = "Hello,  how are you doing today?";
            return str.Insert(7, name);
        }

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("MaybeALittleBitLongerName")]
        public string Replace(string name)
        {
            string AA = "Hello, <name> how are you doing today?";
            return AA.Replace("<name>", name);
        }
    }
}
