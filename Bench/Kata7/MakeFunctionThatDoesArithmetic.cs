using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;

namespace Bench.Kata7
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]

    /// Given two numbers and an arithmetic operator (the name of it, as a string), return the result of the two numbers having that operator used on them.
    /// a and b will both be positive integers, and a will always be the first number in the operation, and b always the second.
    /// The four operators are "add", "subtract", "divide", "multiply". 
    public class MakeFunctionThatDoesArithmetic
    {
        [Benchmark(Baseline = true)]
        [Arguments(5, 2, "divide")]
        public double Switch(double a, double b, string op)
        {
            switch (op)
            {
                case "add": return a + b;
                case "subtract": return a - b;
                case "multiply": return a * b;
                case "divide": return a / b;
                default: return 0;
            }
        }

        [Benchmark]
        [Arguments(5, 2, "divide")]
        public double Tennary(double a, double b, string op) => op[0] == 'a' ? a + b : op[0] == 's' ? a - b : op[0] == 'm' ? a * b : a / b;

        [Benchmark]
        [Arguments(5, 2, "divide")]
        public double IfStatements(double a, double b, string op)
        {
            if ("add".Equals(op)) return a + b;
            if ("subtract".Equals(op)) return a - b;
            if ("multiply".Equals(op)) return a * b;
            if ("divide".Equals(op)) return a / b;
            
            throw new ArgumentException(nameof(op));
        }

        [Benchmark]
        [Arguments(5, 2, "divide")]
        public double Dictionary(double a, double b, string op)
        {
            Dictionary<string, Func<double, double, double>> dico = new Dictionary<string, Func<double, double, double>>
            {
                { "add", (x, y) => x + y },
                { "subtract", (x, y) => x - y },
                { "multiply", (x, y) => x * y },
                { "divide", (x, y) => x / y }
            };

            return dico[op](a, b);
        }
    }
}
