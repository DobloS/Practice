using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Convert.ToString(Console.ReadLine());
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
    }
}
