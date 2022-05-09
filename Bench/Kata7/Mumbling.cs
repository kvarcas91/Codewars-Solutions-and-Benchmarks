using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Linq;
using System.Text;

namespace Bench.Kata7
{
    /// <summary>
    /// Make a function that will return a greeting statement that uses an input; your program should return, "Hello, <name> how are you doing today?".
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class Mumbling
    {

        [Benchmark]
        [Arguments("abcd")]
        [Arguments("aBcDeFgHIjKlMnOPrqSTUVWZ")]
        public string LinqJoin(string s) => string.Join("-", s.Select((x, i) => char.ToUpper(x) + new string(char.ToLower(x), i)));

        [Benchmark(Baseline = true)]
        [Arguments("abcd")]
        [Arguments("aBcDeFgHIjKlMnOPrqSTUVWZ")]
        public string StringBuilder(string s)
        {
            if (s.Length < 1) return "";

            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (char c in s.ToLower())
                sb.Append(char.ToUpper(c), 1)
                  .Append(c, count++ - 1)
                  .Append('-');

            return sb.ToString().TrimEnd('-');
        }

        [Benchmark]
        [Arguments("abcd")]
        [Arguments("aBcDeFgHIjKlMnOPrqSTUVWZ")]
        public string StringAddForEach(string s)
        {
            string result = "";
            int count = 0;
            foreach (char c in s.ToUpper())
            {
                if (count != 0) result += "-";
                result += c + new string(char.ToLower(c), count);
                ++count;
            }
            return result;
        }

    }
}
