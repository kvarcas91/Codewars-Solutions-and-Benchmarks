using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench.Kata7
{
    /// <summary>
    /// Write a function named sumDigits which takes a number as input and returns the sum of the absolute value of each of the number's decimal digits. 
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class SummingNumberDigits
    {


        public IEnumerable<int> DataList()
        {
            yield return 5;
            yield return 50;
            yield return 500;
            yield return -5000;
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DataList))]
        public int ForEach(int number)
        {
            var sum = 0;
            foreach (var c in Math.Abs(number).ToString())
            {
                if (!char.IsNumber(c)) continue;
                sum += (int)char.GetNumericValue(c);
            }

            return sum;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int ForLoopConvertToInt32(int number)
        {
            if (number < 0)
            {
                number *= -1;
            }
            int answer = 0;
            string number_string = Convert.ToString(number);
            for (int x = 0; x < number_string.Length; x++)
            {

                int temp_1_int = Convert.ToInt32(number_string[x]);
                temp_1_int -= 48;
                answer += temp_1_int;
            }
            return answer;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int WhileAndMod(int number)
        {
            number = Math.Abs(number);
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int LinqSumTenary(int number) => (int)number.ToString().Sum(x => char.IsNumber(x) ? char.GetNumericValue(x) : 0);

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int LinqSumTrim(int number) => (int)number.ToString().TrimStart('-').Sum(x => char.GetNumericValue(x));

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int LinqSumSelect(int number) => Math.Abs(number).ToString().Select(x => int.Parse(x.ToString())).Sum();

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int LinqSumReplaceSelect(int number) => number.ToString().Replace("-", "").Select(x => int.Parse(x.ToString())).Sum();

        [Benchmark]
        [ArgumentsSource(nameof(DataList))]
        public int Recursion(int number)
        {
            if (number < 0)
                number *= -1;
            if (number == 0)
                return 0;
            return number % 10 + Recursion(number / 10);
        }

    }
}
