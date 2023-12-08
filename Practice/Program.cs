using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Convert.ToString(Console.ReadLine());

            if (!CheckAlphabet(str))
            {
                string temp = "";
                foreach (var item in str)
                {
                    temp += CheckAlphabet(item);
                }
                throw new AlphabetException("Неподходящие символы: " + temp);
            }
           
            if (str.Length % 2 == 0)
            {
                string firstHalf = str.Substring(0, str.Length / 2);
                string secondHalf = str.Substring(str.Length / 2);

                char[] firstHalfArray = firstHalf.ToCharArray();
                Array.Reverse(firstHalfArray);
                char[] secondHalfArray = secondHalf.ToCharArray();
                Array.Reverse(secondHalfArray);

                string reversedString = new string(firstHalfArray) + new string(secondHalfArray);
                Console.WriteLine(reversedString);

                GetCountChar(reversedString);

                string temp = FindLargestSubstring(reversedString);
                Console.WriteLine("Наибольшая подстрока начинающаяся и оканчивающаяся на гласную: " + temp);
            }

            else
            {
                char[] strArray = str.ToCharArray();
                Array.Reverse(strArray);

                string resultString = new string(strArray) + str;
                Console.WriteLine(resultString);

                GetCountChar(resultString);

                string temp = FindLargestSubstring(resultString);
                Console.WriteLine("Наибольшая подстрока начинающаяся и оканчивающаяся на гласную: " + temp);
            }
        }

        static string FindLargestSubstring(string s)
        {
            string vowels = "aeiouy";
            string maxSubstring = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (vowels.Contains(s[i]) && vowels.Contains(s[j]))
                    {
                        string substring = s.Substring(i, j - i + 1);
                        if (substring.Length > maxSubstring.Length)
                        {
                            maxSubstring = substring;
                        }
                    }
                }
            }
            return maxSubstring;
        }
    
        public static void GetCountChar(string str)
        {
            foreach (var item in str.Distinct().ToArray())
            {
                var count = str.Count(chr => chr == item);
                Console.WriteLine("Количество символов {0} = {1}", item, count);
            }
        }

        public static bool CheckAlphabet(string str)
        {
            Regex regex = new Regex("^[a-z]*$");
            bool fls = regex.IsMatch(str);
            return fls;
        }

        public static char CheckAlphabet(char chr)
        {
            Regex regex = new Regex("^[a-z]*$");
            if (!regex.IsMatch(chr.ToString()))
            {
                return chr;
            }
            else
            {
                return ' ';
            }
        }
    }

    class AlphabetException : Exception
    {
        public AlphabetException(string message): base(message) { }
    }
}
