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
            yield return Enumerable.Range(0, 5000).Reverse().ToArray();
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
            if (nums == null || nums.Length == 0) return new int[0];

            for (int p = 0; p <= nums.Length - 2; p++)
                for (int i = 0; i <= nums.Length - 2; i++)
                    if (nums[i] > nums[i + 1]) (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
            return nums;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int[] MergeSort(int[] nums) => Merge(nums, 0, nums.Length - 1);

        public int[] Merge(int[] array, int left = -1, int right = -1)
        {
            if (left == -1 && right == -1)
            {
                left = 0; right = array.Length - 1;
            }

            if (left < right)
            {
                int middle = left + (right - left) / 2;
                Merge(array, left, middle);
                Merge(array, middle + 1, right);

                var leftArrayLength = middle - left + 1;
                var rightArrayLength = right - middle;
                var leftTempArray = new int[leftArrayLength];
                var rightTempArray = new int[rightArrayLength];
                int i, j;

                for (i = 0; i < leftArrayLength; ++i) leftTempArray[i] = array[left + i];
                for (j = 0; j < rightArrayLength; ++j) rightTempArray[j] = array[middle + 1 + j];

                i = 0;
                j = 0;
                int k = left;

                while (i < leftArrayLength && j < rightArrayLength)
                {
                    if (leftTempArray[i] <= rightTempArray[j]) array[k++] = leftTempArray[i++];
                    else array[k++] = rightTempArray[j++];
                }

                while (i < leftArrayLength) array[k++] = leftTempArray[i++];
                while (j < rightArrayLength) array[k++] = rightTempArray[j++];

            }

            return array;
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
