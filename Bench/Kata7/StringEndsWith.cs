using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace Bench.Kata7
{
    /// <summary>
    /// Make a function that will return a greeting statement that uses an input; your program should return, "Hello, <name> how are you doing today?".
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class StringEndsWith
    {
        [Benchmark(Baseline = true)]
        [Arguments("samurai", "ai")]
        public bool EndsWith(string str, string ending) => str.EndsWith(ending);

        [Benchmark]
        [Arguments("samurai", "ai")]
        public bool ForLoop(string str, string ending)
        {
            if (str == null || ending == null || ending.Length > str.Length)
                return false;
            if (ending.Length == 0 || ReferenceEquals(str, ending))
                return true;

            int endingIndex = ending.Length - 1;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (endingIndex < 0)
                    return true;

                if (str[i] != ending[endingIndex])
                    return false;

                endingIndex--;
            }

            return endingIndex < 0;
        }

        [Benchmark]
        [Arguments("samurai", "ai")]
        public bool SubStringsEqual(string str, string ending) => (str.Length >= ending.Length) && str.Substring(str.Length - ending.Length).Equals(ending);

        [Benchmark]
        [Arguments("samurai", "ai")]
        public bool RemoveEqual(string str, string ending)
        {
            if (ending.Length > str.Length)
            {
                return false;
            }
            str = str.Remove(0, str.Length - ending.Length);
            return str == ending;
        }
    }
}
