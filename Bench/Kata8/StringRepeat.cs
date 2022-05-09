using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections;
using System.Linq;
using System.Text;

namespace Bench.Kata8
{
    /// <summary>
    /// Write a function called repeatStr which repeats the given string string exactly n times.
    /// repeatStr(6, "I") // "IIIIII"
    /// repeatStr(5, "Hello") // "HelloHelloHelloHelloHello"
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class StringRepeat
    {
        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string ConcatWithLinq(int repeatCount, string text) => string.Concat(Enumerable.Repeat(text, repeatCount));

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string ConcatWithArrayRepeat(int repeatCount, string text) => string.Concat(ArrayList.Repeat(text, repeatCount).ToArray());

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string StringBuilderWithInsert(int repeatCount, string text) => new StringBuilder(text.Length * repeatCount).Insert(0, text, repeatCount).ToString();

        [Benchmark(Baseline = true)]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string StringBuilderForLoop(int repeatCount, string text)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < repeatCount; i++)
            {
                builder.Append(text);
            }
            return builder.ToString();
        }

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string StringAppend(int repeatCount, string text)
        {
            var res = "";
            for (int i = 0; i < repeatCount; i++)
            {
                res += text;
            }
            return res;
        }

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string StringAppendWithRecursion(int repeatCount, string text)
        {
            if (repeatCount == 1) return text;
            return StringAppendWithRecursion(repeatCount - 1, text) + text;
        }

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string JoinWithLinq(int repeatCount, string text) => string.Join("",Enumerable.Repeat(text, repeatCount));

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string JoinWithNewString(int repeatCount, string text) => string.Join(text, new string[repeatCount + 1]);

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string StringPadReplace(int repeatCount, string text) => "".PadLeft(repeatCount, 'X').Replace("X", text);

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string NewStringWithReplace(int repeatCount, string text) => new string(text[0], repeatCount).Replace(text[0] + "", text);

        [Benchmark]
        [Arguments(2, "hello")]
        [Arguments(5, "A")]
        [Arguments(20, "hello")]
        [Arguments(100, "hello")]
        public string NewStringWithLINQAggregate(int repeatCount, string text) => new string[repeatCount + 1].Aggregate((a, c) => a += text);

    }
}
