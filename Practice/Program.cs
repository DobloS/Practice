using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                string a = "";
                foreach (var item in str)
                {
                    a += CheckAlphabet(item);
                }
                throw new AlphabetException("Неподходящие символы " + a);
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
            }

            else
            {
                char[] strArray = str.ToCharArray();
                Array.Reverse(strArray);
                string resultString = new string(strArray) + str;
                Console.WriteLine(resultString);
            }
        }

        public static bool CheckAlphabet(string str)
        {
            Regex regex = new Regex("^[a-z]*$");
            bool fls = regex.IsMatch(str);
            return fls;
        }
        public static char CheckAlphabet(char c)
        {
            Regex regex = new Regex("^[a-z]*$");
            if (!regex.IsMatch(c.ToString()))
            {
                return c;
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
