using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace Bench.Kata6
{
    /// A string is considered to be in title case if each word in the string is either(a) capitalised(that is, only the first letter of the word is in upper case) or(b) considered to be an exception and put 
    /// entirely into lower case unless it is the first word, which is always capitalised.
    /// Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. 
    /// Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.
    /// ###Arguments (Haskell)
    /// First argument: space-delimited list of minor words that must always be lowercase except for the first word in the string.
    /// Second argument: the original string to be converted.
    /// ###Arguments (Other languages)
    /// First argument (required): the original string to be converted.
    /// Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. The JavaScript/CoffeeScript tests will pass undefined when this argument is unused.

    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class TitleCase
    {

        private string FirstToUpper(string input)
        {
            var s = input.ToCharArray();
            s[0] = char.ToUpper(s[0]);
            return new string(s);
        }

        [Benchmark]
        [Arguments("THE WIND IN THE WILLOWS", "a an the of")]
        public string Linq(string title, string minorWords = "")
        {
            if (string.IsNullOrEmpty(title)) return title;

            var titleWords = title.Split(' ').Select(w => w.ToLower());
            var minWords = (minorWords ?? "").Split(' ').Select(w => w.ToLower());

            return FirstToUpper(string.Join(" ", titleWords.Select(w => minWords.Contains(w) ? w : FirstToUpper(w))));
        }


        private string FirstUpper(string str)
        {
            return string.Concat(str.Substring(0, 1).ToUpper(), str.Substring(1));
        }

        [Benchmark(Baseline = true)]
        [Arguments("THE WIND IN THE WILLOWS", "a an the of")]
        public string ForLoop(string title, string minorWords = "")
        {
            if (string.IsNullOrEmpty(title))
                return title;
            if (minorWords == null)
                minorWords = "";

            var words = title.ToLower().Split(' ').ToList();
            var minors = minorWords.ToLower().Split(' ').ToList();

            words[0] = FirstUpper(words[0]);

            for (var i = 1; i < words.Count; i++)
            {
                if (!minors.Contains(words[i]))
                {
                    words[i] = FirstUpper(words[i]);
                }
            }

            return string.Join(" ", words);
        }

        [Benchmark]
        [Arguments("THE WIND IN THE WILLOWS", "a an the of")]
        public string LinqWithTextInfo(string title, string minorWords = "")
        {
            string[] minors = string.IsNullOrEmpty(minorWords) ? new string[0] : minorWords.Split().Select(w => w.ToLower()).ToArray();
            return string.Join(" ", title.Split().Select((w, i) => i == 0 || Array.IndexOf(minors, w.ToLower()) == -1 ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.ToLower()) : w.ToLower()));
        }

        [Benchmark]
        [Arguments("THE WIND IN THE WILLOWS", "a an the of")]
        public string Regex(string title, string minorWords = "") =>
            Replace(title.ToLower(), @"(?<=^|\s" + (string.IsNullOrWhiteSpace(minorWords) ? null : $@"(?!({minorWords.Replace(' ', '|')})(\s|$))") + @")(\w)", a => a.Value.ToUpper(), RegexOptions.IgnoreCase);
        



    }
}
