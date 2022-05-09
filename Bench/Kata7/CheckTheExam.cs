using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata7
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    ///
    /// The first input array is the key to the correct answers to an exam, like["a", "a", "b", "d"]. The second one contains a student's submitted answers.
    /// The two arrays are not empty and are the same length.Return the score for this array of answers, giving +4 for each correct answer, -1 for each incorrect answer, and +0 for each blank answer, 
    /// represented as an empty string (in C the space character is used).
    /// If the score < 0, return 0.
    public class CheckTheExam
    {

        public IEnumerable<object[]> DataList()
        {
            yield return new object[] { new string[] { "a", "a", "b", "b" }, new string[] { "a", "c", "b", "d" } };
            yield return new object[] { new string[] { "a", "a", "b", "b", "a", "a", "b", "b" }, new string[] { "a", "c", "b", "d", "a", "c", "b", "d" } };
            yield return new object[] { new string[] { "a", "a", "b", "b", "a", "a", "b", "b", "a", "a", "b", "b", "a", "a", "b", "b", "a", "a", "b", "b" }, new string[] { "a", "c", "b", "d", "a", "c", "b", "d", "a", "c", "b", "d", "a", "c", "b", "d", "a", "c", "b", "d" } };
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int SumPointsWithLinq(string[] arr1, string[] arr2) => Math.Max(arr2.Select((s, i) => s == "" ? 0 : s == arr1[i] ? 4 : -1).Sum(), 0);

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int SumWithForLoop(string[] arr1, string[] arr2)
        {
            int counter = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr2[i] == "")
                    continue;
                if (arr1[i] == arr2[i])
                    counter += 4;
                else
                    counter--;
            }

            if (counter < 0)
                return 0;
            return counter;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int SumWithForLoopOneLiner(string[] arr1, string[] arr2)
        {
            int scores = 0;
            for (int i = 0; i < arr1.Length; i++) scores += arr2[i] == "" ? 0 : arr1[i] == arr2[i] ? 4 : -1;
            return scores < 0 ? 0 : scores;
        }
    }
}
