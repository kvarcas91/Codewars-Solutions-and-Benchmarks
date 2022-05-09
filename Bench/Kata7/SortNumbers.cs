using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bench.Kata7
{

    /// <summary>
    /// Finish the solution so that it sorts the passed in array of numbers. If the function passes in an empty array or null/nil value then it should return an empty array.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class SortNumbers
    {

        public IEnumerable<int[]> DataList()
        {
            yield return Enumerable.Range(0, 5).Reverse().ToArray();
            yield return Enumerable.Range(0, 50).Reverse().ToArray();
            yield return Enumerable.Range(0, 500).Reverse().ToArray();
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int[] ArraySort(int[] nums)
        {
            if (nums == null)
                nums = new int[0];

            Array.Sort(nums);
            return nums;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] ListSort(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[] { };
            var n = nums.ToList();
            n.Sort();
            return n.ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] LinqOrderBy(int[] nums) => nums?.OrderBy(i => i).ToArray() ?? new int[0];

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] QuickSort(int[] nums)
        {
            if (nums == null)
                return new int[0];
            else
            {
                SupportQuickSort.QuickSort(nums, 0, nums.Length - 1);
                return nums;
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] BubbleSort(int[] nums)
        {
            if (nums != null)
            {
                int temp;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] > nums[j])
                        {
                            temp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = temp;
                        }
                    }
                }
                return nums;
            }
            return new int[] { };
        }
    }

    public static class SupportQuickSort
    {
        public static int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right],
                i = (left - 1),
                temp = 0;
            for (int j = left; j < right; j++)
            {
                if (nums[j] < pivot)
                {
                    i++;

                    temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }

            temp = nums[i + 1];
            nums[i + 1] = nums[right];
            nums[right] = temp;

            return i + 1;
        }

        public static void QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int mid = Partition(nums, left, right);

                QuickSort(nums, left, mid - 1);
                QuickSort(nums, mid + 1, right);
            }
        }
    }
}
