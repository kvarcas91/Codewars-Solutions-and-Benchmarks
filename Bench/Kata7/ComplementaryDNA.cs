using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Text.RegularExpressions.Regex;

namespace Bench.Kata7
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    
    /// Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for the development and functioning of living organisms.
    /// If you want to know more: http://en.wikipedia.org/wiki/DNA
    /// In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". You function receives one side of the DNA(string, except for Haskell); you need to return the other complementary side.
    /// DNA strand is never empty or there is no DNA at all (again, except for Haskell).
    /// More similar exercise are found here: http://rosalind.info/problems/list-view/ (source)
    public class ComplementaryDNA
    {
        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string ConcatWithLinqUsingSwitch(string dna) => string.Concat(dna.Select(GetComplement));
        public char GetComplement(char symbol)
        {
            switch (symbol)
            {
                case 'A':
                    return 'T';
                case 'T':
                    return 'A';
                case 'C':
                    return 'G';
                case 'G':
                    return 'C';
                default:
                    throw new ArgumentException();
            }
        }

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string ConcatWithLinq(string dna) => string.Concat(dna.Select(c => "AGCT"["TCGA".IndexOf(c)]));

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string JoinWithLinq(string dna) => string.Join("", from ch in dna select "AGCT"["TCGA".IndexOf(ch)]);

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string LinqWithDictionary(string dna)
        {
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                {'T', 'A'},
                {'A', 'T'},
                {'C', 'G'},
                {'G', 'C'}
            };

            var mychars = dna.ToCharArray();

            var outChars = new string(mychars.Select(x => map[x]).ToArray());

            return outChars;
        }

        [Benchmark(Baseline = true)]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string StringBuilderForLoop(string dna)
        {
            StringBuilder strain = new StringBuilder();

            for (int i = 0; i < dna.Length; i++)
            {
                switch (dna[i])
                {
                    case 'A':
                        strain.Append('T');
                        break;
                    case 'T':
                        strain.Append('A');
                        break;
                    case 'C':
                        strain.Append('G');
                        break;
                    case 'G':
                        strain.Append('C');
                        break;
                }
            }
            return strain.ToString();
        }

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string ArrayCharReplaceWithForLoop(string dna)
        {
            var array = dna.ToCharArray();

            for (var i = array.Length - 1; i >= 0; --i)
            {
                switch (array[i])
                {
                    case 'A':
                        array[i] = 'T';
                        break;
                    case 'T':
                        array[i] = 'A';
                        break;
                    case 'C':
                        array[i] = 'G';
                        break;
                    case 'G':
                        array[i] = 'C';
                        break;
                }
            }

            return new string(array);
        }

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string StringReplaceWithPlaceholder(string dna) => dna.Replace('T', '?').Replace('A', 'T').Replace('?', 'A').Replace('G', '?').Replace('C', 'G').Replace('?', 'C');

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string StringReplaceAndToUpper(string dna) => dna.Replace("A", "t").Replace("T", "a").Replace("G", "c").Replace("C", "g").ToUpper();

        [Benchmark]
        [Arguments("ATGCTTCAGAAAGGTCTTACG")]
        [Arguments("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC")]
        public string RegexReplace(string dna) => Replace(dna, ".", m => $"{"TAGC"["ATCG".IndexOf(m.Value[0])]}");
    }
}
