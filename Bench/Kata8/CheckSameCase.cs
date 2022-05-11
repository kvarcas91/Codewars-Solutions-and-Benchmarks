using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Globalization;

namespace Bench.Kata8
{
    /// <summary>
    /// Write a function that will check if two given characters are the same case.
    /// If either of the characters is not a letter, return -1
    /// If both characters are the same case, return 1
    /// If both characters are letters, but not the same case, return 0
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class CheckSameCase
    {

        [Benchmark(Baseline = true)]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int XNOR(char a, char b)
        {
            if (!char.IsLetter(a) || !char.IsLetter(b)) return -1;

            if (char.IsUpper(a) ^ char.IsUpper(b)) return 0;
            return 1;
        }

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int IndexOf(char a, char b)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int aIndex = alphabet.IndexOf(a);
            int bIndex = alphabet.IndexOf(b);

            if (aIndex < 0 || bIndex < 0)
            {
                return -1;
            }
            else if ((aIndex <= 25 && bIndex <= 25) || (aIndex >= 26 && bIndex >= 26))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int OR(char a, char b) =>
             !char.IsLetter(a) || !char.IsLetter(b) ? -1 : char.IsUpper(a) && char.IsUpper(b) || char.IsLower(a) && char.IsLower(b) ? 1 : 0;

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int Equal(char a, char b) =>
             char.IsLetter(a) && char.IsLetter(b)
            ? System.Convert.ToInt32(char.IsUpper(a) == char.IsUpper(b))
            : -1;

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int Globalization(char a, char b) =>
             !char.IsLetter(a) || !char.IsLetter(b)
                ? -1
                : char.GetUnicodeCategory(a) == UnicodeCategory.LowercaseLetter && char.GetUnicodeCategory(b) == UnicodeCategory.LowercaseLetter
                    ? 1
                    : char.GetUnicodeCategory(a) == UnicodeCategory.UppercaseLetter && char.GetUnicodeCategory(b) == UnicodeCategory.UppercaseLetter
                        ? 1 : 0;

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int ToUpperOR(char a, char b)
        {
            if (!char.IsLetter(a) || !char.IsLetter(b)) return -1;
            return (char.ToUpper(a) == a && char.ToUpper(b) == b) || (char.ToLower(a) == a && char.ToLower(b) == b) ? 1 : 0;
        }

        [Benchmark]
        [Arguments('a', 'b')]
        [Arguments('a', 'B')]
        public int MultipleIfs(char a, char b)
        {
            int result = -1;
            if (char.IsLower(a) && char.IsLower(b)) result = 1;
            else if (char.IsUpper(a) && char.IsUpper(b)) result = 1;
            else if (char.IsUpper(a) && char.IsLower(b)) result = 0;
            else if (char.IsLower(a) && char.IsUpper(b)) result = 0;
            return result;
        }
    }
}
