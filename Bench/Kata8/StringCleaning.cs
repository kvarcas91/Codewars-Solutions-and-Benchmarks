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
    /// Your boss decided to save money by purchasing some cut-rate optical character recognition software for scanning in the text of old novels to your database. At first it seems to capture words okay, 
    /// but you quickly notice that it throws in a lot of numbers at random places in the text.
    /// Your harried co-workers are looking to you for a solution to take this garbled text and remove all of the numbers. Your program will take in a string and clean out all numeric characters, 
    /// and return a string with spacing and special characters ~#$%^&!@*():;"'.,? all intact.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class StringCleaning
    {
        public IEnumerable<string> DataList()
        {
            yield return "This is some random text5!";
            yield return "Your boss decided to save money by purchasing some cut-rate optical character recognition software for scanning in the text of ol234d novels to your database. At first 2it seems to capture words okay";
        }


        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public string StringBuilderAndForEach(string s)
        {
            
            var stringBuilder = new StringBuilder();

            foreach (var c in s)
            {
                if (!char.IsNumber(c)) stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string Regex(string s) => Replace(s, @"\d", "");

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string ReplaceNumbersWithEmptyChar(string s)
        {
            foreach (char c in s)
                if (c >= 48 && c <= 57) s = s.Replace(c.ToString(), "");
            return s;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public string LinqAndJoin(string s) => string.Join("", s.Where(x => !char.IsDigit(x)));

    }
}
