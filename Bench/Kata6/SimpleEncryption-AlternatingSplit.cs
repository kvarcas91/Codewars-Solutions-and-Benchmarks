using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System;
using System.Linq;
using System.Text;

namespace Bench.Kata6
{
    /// <summary>
    ///Implement a pseudo-encryption algorithm which given a string S and an integer N concatenates all the odd-indexed characters of S with all the even-indexed characters of S, this process should be repeated N times.
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net48)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MemoryDiagnoser]
    public class SimpleEncryption_AlternatingSplit
    {


        private string Alternate(string text)
        {
            var evens = new StringBuilder();
            var odds = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 0) evens.Append(text[i]);
                else odds.Append(text[i]);
            }

            return string.Concat(odds, evens);
        }
        private string AlternateDecrpyt(string text)
        {
            var mid = text.Length / 2;
            var firstPart = text.Substring(0, mid);
            var secondPart = text.Substring(mid);
            var max = Math.Max(firstPart.Length, secondPart.Length);
            var output = new StringBuilder();

            for (int i = 0; i < max; i++)
            {
                if (i < secondPart.Length) output.Append(secondPart[i]);
                if (i < firstPart.Length) output.Append(firstPart[i]);
            }

            return output.ToString();
        }
        public string ForLoopAndStringBuilderEncrypt(string text, int n)
        {
            while (n-- > 0)
            {
                text = Alternate(text);
            }
            return text;
        }
        public string ForLoopAndStringBuilderDecrpyt(string text, int n)
        {
            while (n-- > 0)
            {
                text = AlternateDecrpyt(text);
            }
            return text;
        }

        [Benchmark(Baseline = true)]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string ForLoopAndStringBuilder(string text, int n)
        {
            var s = ForLoopAndStringBuilderEncrypt(text, n);
            return ForLoopAndStringBuilderDecrpyt(s, n);
        }

        private string LinqEncrypt(string text, int n)
        {
            if (string.IsNullOrWhiteSpace(text) || n <= 0) return text;
            
            while (n != 0)
            {
                text = string.Concat(text.Where((c, i) => i % 2 == 1).Concat(text.Where((c, i) => i % 2 == 0)));
                n--;
            }

            return text;
        }

        private string LinqDecrypt(string text, int n)
        {
            if (string.IsNullOrWhiteSpace(text) || n <= 0) return text;

            while (n != 0)
            {
                string leftPart = string.Concat(text.Take(text.Length / 2));
                string rightPart = string.Concat(text.Skip(text.Length / 2));

                text = string.Concat(Enumerable.Range(0, text.Length).Select(i => i % 2 == 0 ? rightPart[i / 2] : leftPart[i / 2]));

                n--;
            }

            return text;
        }

        [Benchmark]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string Linq(string text, int n)
        {
            var s = LinqEncrypt(text, n);
            return LinqDecrypt(s, n);
        }

        private string RecursionAndStringAppendEncrypt(string text, int n)
        {
            if (n <= 0 || text == null)
                return text;

            string result = "";

            for (int i = 1; i < text.Length; i += 2) result += text[i];
            for (int i = 0; i < text.Length; i += 2) result += text[i];

            return RecursionAndStringAppendEncrypt(result, n - 1);
        }

        private string RecursionAndStringAppendDecrpyt(string text, int n)
        {
            if (n <= 0 || text == null)
                return text;

            int shift = text.Length / 2;
            string result = "";

            for (int i = 0; i < shift; i++)
                result += text[i + shift].ToString() + text[i];

            if (text.Length % 2 == 1)
                result += text[text.Length - 1];

            return RecursionAndStringAppendDecrpyt(result, n - 1);
        }

        [Benchmark]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string RecursionAndStringAppend(string text, int n)
        {
            var s = RecursionAndStringAppendEncrypt(text, n);
            return RecursionAndStringAppendDecrpyt(s, n);
        }

        private string ForLoopAndCharArrayEncrypt(string text, int n)
        {
            if (string.IsNullOrEmpty(text) || n <= 0) return text;
            while (n-- > 0)
            {
                var s = new char[text.Length];
                for (var j = 0; j < s.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        s[s.Length / 2 + j / 2] = text[j];
                    }
                    else
                    {
                        s[j / 2] = text[j];
                    }
                }
                text = new string(s);
            }
            return text;
        }

        private string ForLoopAndCharArrayDecrpyt (string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText) || n <= 0) { return encryptedText; }
            while (n-- > 0)
            {
                var s = new char[encryptedText.Length];
                for (var j = 0; j < s.Length; j++)
                {
                    s[j] = j % 2 == 0 ? encryptedText[s.Length / 2 + j / 2] : s[j] = encryptedText[j / 2];
                }
                encryptedText = new string(s);
            }
            return encryptedText;
        }

        [Benchmark]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string ForLoopAndCharArray(string text, int n)
        {
            var s = ForLoopAndCharArrayEncrypt(text, n);
            return ForLoopAndCharArrayDecrpyt(s, n);
        }

        private string LinqAggregateEncrypt(string text, int n)
        {
            return (n > 0 && !string.IsNullOrEmpty(text)) ? Enumerable.Range(0, n).Aggregate(text, (previous, _) => LinqAggregateEncryptSupport(previous)) : text;
        }

        private string LinqAggregateEncryptSupport(string str)
        {
            return new string(Enumerable.Range(0, str.Length)
                             .Aggregate(new char[str.Length], (output, i) =>
                             {
                                 output[i % 2 != 0 ? i / 2 : (str.Length / 2) + i / 2] = str[i];
                                 return output;
                             }));
        }

        private string LinqAggregateDecrypt(string text, int n)
        {
            return (n > 0 && !string.IsNullOrEmpty(text)) ? Enumerable.Range(0, n).Aggregate(text, (previous, _) => LinqAggregateDecryptSupport(previous)) : text;
        }

        private string LinqAggregateDecryptSupport (string str)
        {
            return new string(Enumerable.Range(0, str.Length)
                           .Aggregate(new char[str.Length], (output, i) =>
                           {
                               output[i] = str[i % 2 != 0 ? i / 2 : (str.Length / 2) + i / 2];
                               return output;
                           }));
        }

        [Benchmark]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string LinqAggregate(string text, int n)
        {
            var s = LinqAggregateEncrypt(text, n);
            return LinqAggregateDecrypt(s, n);
        }


        public string ForLoopAndStringAppendEncrypt(string text, int n)
        {
            if (text != null)
            {                                //if text isn't null, continue
                string encryptText1 = "";
                string encryptText2 = "";
                string encrypted = text;

                if (n != 0)
                {                                    //if n isn't 0, continue
                    for (int i = 0; i < n; i++)
                    {
                        encryptText1 = "";
                        encryptText2 = "";

                        for (int j = 0; j < text.Length; j++)
                        {         //split the text into two strings
                            if (j % 2 == 0)
                            {
                                encryptText2 += encrypted[j];          //one string gets all the even indexed letters
                            }
                            else
                            {
                                encryptText1 += encrypted[j];          //the other gets all the odd indexed letters
                            }
                        }
                        encrypted = encryptText1 + encryptText2;   //concatenate for the returned answer
                    }                                            //if n > 1 both encryptText variables are reset and new encrypted text is used in place of original text
                    return encrypted;
                }
                return text;                                   //if n=0, just return the original text
            }
            else
            {
                return null;                                   //return null if text is null
            }
        }

        public static string ForLoopAndStringAppendDecrypt(string encryptedText, int n)
        {
            if (encryptedText != null)
            {                                    //same idea, if text isn't null, continue
                string decrypted = "";
                int position = encryptedText.Length / 2;                       //we'll split the encrypted text down the middle (rounded down)
                string decryptText1 = encryptedText.Substring(0, position);  //assign each variable with a substring half
                string decryptText2 = encryptedText.Substring(position);


                if (n != 0)
                {                                                  //if n > 0 continue
                    for (int k = 0; k < n; k++)
                    {
                        decrypted = "";
                        for (int m = 0; m < position; m++)
                        {                           //add first letter from one half, then first letter from second half and so on
                            decrypted += decryptText2[m];                           //all this goes into the decrypted string
                            decrypted += decryptText1[m];
                        }

                        if (encryptedText.Length % 2 != 0)
                        {                       //if the initial text is odd lengthed, the last character will not get touched in the loop above
                            decrypted += decryptText2[decryptText2.Length - 1];      //so we manually concatenate it onto the decrypted variable  
                        }

                        decryptText1 = decrypted.Substring(0, position);          //update the two decryptText variables in case n > 1 and another round is required
                        decryptText2 = decrypted.Substring(position);
                    }
                    return decryptText1 + decryptText2;                         //return decrypted variable concatenated
                }
                return encryptedText;                                         //if n=0, just return the initial text
            }
            else
            {
                return null;                                                  //if text is null, return null
            }
        }

        [Benchmark]
        [Arguments("012345", 2)]
        [Arguments("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789", 200)]
        public string ForLoopAndStringAppend(string text, int n)
        {
            var s = ForLoopAndStringAppendEncrypt(text, n);
            return ForLoopAndStringAppendDecrypt(s, n);
        }
    }
}
