using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata6
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]

    /// Write a function that takes an array of numbers (integers for the tests) and a target number. It should find two different items in the array that, when added together, give the target value. 
    /// The indices of these items should then be returned in a tuple / list (depending on your language) like so: (index1, index2).
    /// For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.
    /// The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will be numbers; target will always be the sum of two different items from that array).
    public class TwoSum
    {
        public IEnumerable<object[]> DataList()
        {
            yield return new object[] { new [] { 1,2,3}, 5 };
            yield return new object[] { new [] { 2, 2, 3, 8 }, 11 };
            yield return new object[] { Enumerable.Range(0, 500).ToArray(), 997 };
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int[] NestedForLoops(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers[i] + numbers[j] == target)
                        return new int[] { i, j };

            return new int[0];
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqSelect(int[] numbers, int target) => numbers.Select((x, i) => new[] { i, Array.IndexOf(numbers, target - x, i + 1) }).First(x => x[1] != -1);


        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] ForLoopWithDictionary(int[] numbers, int target)
        {
            var targets = new Dictionary<int, int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                int match = target - numbers[i];
                if (targets.ContainsKey(match))
                {
                    return new int[] { i, targets[match] };
                }
                targets[numbers[i]] = i;
            }

            throw new ArgumentException("Bad numbers");
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] WhileLoopWithContainsCheck(int[] numbers, int target)
        {
            foreach (var number in numbers)
            {
                var num = target - number;
                if (numbers.Contains(num))
                {
                    var index1 = Array.IndexOf(numbers, num);
                    var index2 = Array.LastIndexOf(numbers, number);
                    return new int[] { index1, index2 };
                }
            }
            return new int[0];
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] Random(int[] numbers, int target)
        {
            int[] arr = new int[2];
            Random rand = new Random();
            while (true)
            {
                arr[0] = rand.Next(0, numbers.Length);
                arr[1] = rand.Next(0, numbers.Length);
                if (arr[0] == arr[1]) continue;
                if (numbers[arr[0]] + numbers[arr[1]] == target) break;
            }
            return arr.OrderBy(a => a).ToArray();
        }
    }
}
