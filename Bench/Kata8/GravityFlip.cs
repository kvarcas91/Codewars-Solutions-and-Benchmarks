using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata8
{
    /// <summary>
    /// If you've completed this kata already and want a bigger challenge, here's the 3D version
    /// Bob is bored during his physics lessons so he's built himself a toy box to help pass the time. The box is special because it has the ability to change gravity.
    /// There are some columns of toy cubes in the box arranged in a line.The i-th column contains a_i cubes.At first, the gravity in the box is pulling the cubes downwards. When Bob switches the gravity, it 
    /// begins to pull all the cubes to a certain side of the box, d, which can be either 'L' or 'R' (left or right). Below is an example of what a box of cubes might look like before and after switching gravity.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class GravityFlip
    {

        public IEnumerable<object[]> DataList()
        {
            yield return new object[] { 'L', new int[] { 1, 2, 2, 3 } };
            yield return new object[] { 'R', new int[] { 5, 5, 4, 3, 1 } };
            yield return new object[] { 'L', Enumerable.Range(0, 500).ToArray() };
            yield return new object[] { 'R', Enumerable.Range(0, 500).Reverse().ToArray() };
            yield return new object[] { 'L', Enumerable.Range(0, 5000).ToArray() };
            yield return new object[] { 'R', Enumerable.Range(0, 5000).Reverse().ToArray() };
            yield return new object[] { 'L', Enumerable.Range(0, 50000).ToArray() };
            yield return new object[] { 'R', Enumerable.Range(0, 50000).Reverse().ToArray() };
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int[] ArraySortWithOneIfCheck(char dir, int[] arr)
        {
            Array.Sort(arr);
            if (dir == 'L') Array.Reverse(arr);
            return arr;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] ArraySortWithDoubleSort(char dir, int[] arr)
        {
            if (dir.Equals('R'))
            {
                Array.Sort(arr);
            }
            else
            {
                Array.Sort(arr);
                Array.Reverse(arr);
            }
            return arr;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqOrderByTenary(char dir, int[] arr) => dir == 'R' ? arr.OrderBy(x => x).ToArray() : arr.OrderByDescending(x => x).ToArray();

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqOrderByTenaryInside(char dir, int[] arr) => arr.OrderBy(i => dir == 'R' ? i : -i).ToArray();
    }
}
