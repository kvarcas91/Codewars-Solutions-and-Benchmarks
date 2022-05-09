using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bench.Kata6
{
    /// <summary>
    ///Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.
    ///It should remove all values from list a, which are present in list b keeping their order.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class ArrayDiff
    {

        public IEnumerable<object[]> DataList()
        {
            yield return new object[] { Enumerable.Range(0, 20).ToArray(), Enumerable.Range(0, 5).ToArray() };
            yield return new object[] { Enumerable.Range(0, 50).ToArray(), Enumerable.Range(0, 20).ToArray() };
            yield return new object[] { Enumerable.Range(0, 100).ToArray(), Enumerable.Range(0, 50).ToArray() };
            yield return new object[] { Enumerable.Range(0, 500).ToArray() , Enumerable.Range(0, 200).ToArray() };
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int[] ForEachWithRemoveAll(int[] a, int[] b)
        {
            var list = a.ToList();
            foreach (var i in b) list.RemoveAll(x => x == i);
            
            return list.ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] DoubleForLoop(int[] a, int[] b)
        {
            List<int> result = new List<int>();
            bool alreadyIn;
            for (int i = 0; i < a.Length; i++)
            {
                alreadyIn = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                        alreadyIn = true;
                }

                if (!alreadyIn)
                    result.Add(a[i]);
            }

            return result.ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqWhereAndContains(int[] a, int[] b) => a.Where(n => !b.Contains(n)).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqWhereAndContainsInHashset(int[] a, int[] b)
        {
            HashSet<int> bSet = new HashSet<int>(b);

            return a.Where(v => !bSet.Contains(v)).ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] ArrayFindAllAndContains(int[] a, int[] b) => Array.FindAll(a, m => !b.Contains(m));
    }
}
