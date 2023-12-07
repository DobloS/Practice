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
            string[] words = str.Split(new char[] { ' ' });
            int a = str.Length;
            if (a / 2 == 0)
            {
                str = str.Substring(a/2);
                

            }
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(words);


        }
    }
}
