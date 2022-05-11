using Bench.Kata5;
using Bench.Kata6;
using Bench.Kata7;
using Bench.Kata8;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bench
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var results = BenchmarkRunner.Run<StringRepeat>();
            // var results = BenchmarkRunner.Run<SumWithoutHighestAndLowest>();
            // var results = BenchmarkRunner.Run<CheckTheExam>();
            // var results = BenchmarkRunner.Run<SortNumbers>();
            // var results = BenchmarkRunner.Run<GrowthOfPopulation>();
            // var results = BenchmarkRunner.Run<ComplementaryDNA>();
            // var results = BenchmarkRunner.Run<MakeFunctionThatDoesArithmetic>();
            // var results = BenchmarkRunner.Run<ReturningStrings>();
            // var results = BenchmarkRunner.Run<Mumbling>();
            // var results = BenchmarkRunner.Run<TwoSum>();
            // var results = BenchmarkRunner.Run<StringEndsWith>();
            // var results = BenchmarkRunner.Run<ROT13>();
            // var results = BenchmarkRunner.Run<ArrayDiff>();
            // var results = BenchmarkRunner.Run<TitleCase>();
            // var results = BenchmarkRunner.Run<SimpleEncryption_AlternatingSplit>();
            // var results = BenchmarkRunner.Run<CatYearsDogYears>();
            // var results = BenchmarkRunner.Run<HelloNameOrWorld>();
            // var results = BenchmarkRunner.Run<AnagramDetection>();
            // var results = BenchmarkRunner.Run<StringCleaning>();
            // var results = BenchmarkRunner.Run<CheckSameCase>();
            var results = BenchmarkRunner.Run<StringyString>();
        }
       
    }
}
