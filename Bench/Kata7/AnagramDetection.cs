using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata7
{
    /// <summary>
    /// An anagram is the result of rearranging the letters of a word to produce a new word (see wikipedia).
    /// Note: anagrams are case insensitive
    /// Complete the function to return true if the two arguments given are anagrams of each other; return false otherwise.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class AnagramDetection
    {

        public IEnumerable<string[]> DataList()
        {
            yield return new [] { "foefet", "toffee" };
            yield return new [] { "Buckethead", "DeathCubeK" };
            yield return new [] { "basiparachromatin", "marsipobranchiata" };
            yield return new [] { "hydroxydeoxycorticosterones", "hydroxydesoxycorticosterone" };
        }



        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public bool ArraySortAndConcat(string test, string original)
        {
            var s = test.ToUpper().ToCharArray();
            Array.Sort(s);

            var t = original.ToUpper().ToCharArray();
            Array.Sort(t);
            return string.Concat(s).Equals(string.Concat(t));
        }

        public string SortLower(string str)
        {
            return string.Concat(str.ToLower().OrderBy(c => c));
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public bool LinqOrderByAndConcat(string test, string original) => SortLower(test) == SortLower(original);

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public bool LinqOrderByAndSequanceEqual(string test, string original) => test.ToLower().OrderBy(x => x).SequenceEqual(original.ToLower().OrderBy(x => x));

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public bool LinqAggregateAndStringAppend(string test, string original) => (test + original).ToLower().Aggregate(0, (a, n) => a ^ n) == 0;

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public bool ArraySortAndNewString(string test, string original)
        {
            test = test.ToLower();
            original = original.ToLower();

            char[] testarr = test.ToCharArray();
            char[] origarr = original.ToCharArray();

            Array.Sort(testarr);
            Array.Sort(origarr);

            string s1 = new string(testarr);
            string s2 = new string(origarr);
            return s1 == s2;
        }

    }
}
