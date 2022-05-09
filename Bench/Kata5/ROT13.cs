using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace Bench.Kata5
{
    /// <summary>
    /// How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.
    /// I found this joke on USENET, but the punchline is scrambled.Maybe you can decipher it? According to Wikipedia, ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.
    /// Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class ROT13
    {

        [Benchmark]
        [Arguments("EBG13 rknzcyr.")]
        [Arguments("This is my first ROT13 excercise! Can't wait to have some more!")]
        public string StringJoinWithLinq(string input)
        {
            var s1 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
            var s2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return string.Join("", input.Select(x => char.IsLetter(x) ? s1[s2.IndexOf(x)] : x));
        }

        [Benchmark]
        [Arguments("EBG13 rknzcyr.")]
        [Arguments("This is my first ROT13 excercise! Can't wait to have some more!")]
        public string Regex(string input) =>
            Replace(input, "[a-zA-Z]", new MatchEvaluator(c => ((char)(c.Value[0] + (char.ToLower(c.Value[0]) >= 'n' ? -13 : 13))).ToString()));

        [Benchmark]
        [Arguments("EBG13 rknzcyr.")]
        [Arguments("This is my first ROT13 excercise! Can't wait to have some more!")]
        public string CharManipulationWithLinq(string input) => new string(input.Select(x => char.IsLetter(x) ? (char)(x + (char.ToUpper(x) < 'N' ? 13 : -13)) : x).ToArray());

        [Benchmark]
        [Arguments("EBG13 rknzcyr.")]
        [Arguments("This is my first ROT13 excercise! Can't wait to have some more!")]
        public string ForEach(string input)
        {
            var array = input.ToArray();
            int i = 0;

            foreach (var item in array)
            {
                if ((item >= 'a' && item <= 'm') || (item >= 'A' && item <= 'M'))
                    array[i] = (char)(item + 13);
                if ((item >= 'n' && item <= 'z') || (item >= 'N' && item <= 'Z'))
                    array[i] = (char)(item - 13);
                i++;

            }

            return string.Join("", array);
        }

        [Benchmark]
        [Arguments("EBG13 rknzcyr.")]
        [Arguments("This is my first ROT13 excercise! Can't wait to have some more!")]
        public string StringBuilderWithPresetLists(string input)
        {
            string inpt = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string output = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";

            var result = new StringBuilder();

            foreach (var c in input)
            {
                int idx = inpt.IndexOf(c);
                result.Append(idx > -1 ? output[idx] : c);
            }

            return result.ToString();
        }
    }
}
