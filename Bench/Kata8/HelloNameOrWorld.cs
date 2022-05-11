using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Globalization;
using System.Linq;

namespace Bench.Kata8
{
    /// <summary>
    /// Define a method hello that returns "Hello, Name!" to a given name, or says Hello, World! if name is not given (or passed as an empty String).
    /// Assuming that name is a String and it checks for user typos to return a name with a first capital letter(Xxxx).
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class HelloNameOrWorld
    {
        [Benchmark(Baseline = true)]
        [Arguments("Eddie")]
        [Arguments("SomeRandomLongNameWhichMightBeABitOfAChallenge")]
        public string InterpolationAndStringConcat(string name)
        {
            if (string.IsNullOrEmpty(name)) return "Hello, World!";

            var firstPart = name.Substring(0, 1).ToUpper();
            var secondPart = name.Substring(1).ToLower();
            return $"Hello, {string.Concat(firstPart, secondPart)}!";
        }

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("SomeRandomLongNameWhichMightBeABitOfAChallenge")]
        public string StringAppend(string name)
        {
            if (name == "" || name == null) return "Hello, World!";
            
            return "Hello, " + name[0].ToString().ToUpper() + name.Substring(1).ToLower() + "!";
            
        }

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("SomeRandomLongNameWhichMightBeABitOfAChallenge")]
        public string InterpolationAndGlobalization(string name)
        {
            return string.IsNullOrEmpty(name)
            ? "Hello, World!"
        :   $"Hello, {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}!";

        }

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("SomeRandomLongNameWhichMightBeABitOfAChallenge")]
        public string StringAppendAndForLoop(string name)
        {
            if (name == string.Empty)
            {
                return "Hello, World!";
            }
            char nameturn = char.ToUpper(name[0]);
            string nameturn2 = "";
            char temp;
            for (int i = 1; i < name.Length; i++)
            {
                temp = char.ToLower(name[i]);
                nameturn2 += temp;
            }
            return $"Hello, {nameturn}{nameturn2}!";

        }

        [Benchmark]
        [Arguments("Eddie")]
        [Arguments("SomeRandomLongNameWhichMightBeABitOfAChallenge")]
        public string Linq(string name)
        {
            return string.IsNullOrEmpty(name)
            ? "Hello, World!"
        :   $"Hello, {string.Concat(name.Select((c, i) => i == 0 ? char.ToUpper(c) : char.ToLower(c)))}!";

        }

    }
}
