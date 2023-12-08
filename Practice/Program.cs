using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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
            TreeSortAlgorithm treeSortAlgorithm = new TreeSortAlgorithm();

            if (!CheckAlphabet(str))
            {
                string temp = "";
                foreach (var item in str)
                {
                    temp += CheckAlphabet(item);
                }
                throw new AlphabetException("Неподходящие символы: " + temp);
            }

            Console.WriteLine("Выберите алгоритм сортировки");
            Console.WriteLine("1) Быстрая сортировка (QuickSort)");
            Console.WriteLine("2) Сортировка бинарным деревом (TreeSort)");

            var choice = int.Parse(Console.ReadLine());

            char[] stringArray;

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

                stringArray = reversedString.ToCharArray();
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
                stringArray = resultString.ToCharArray();
            }

            char[] sortedString = new char [stringArray.Length]; 
            stringArray.CopyTo(sortedString, 0);
            if (choice == 1)
            {
                QuickSortString.QuickSort(sortedString, 0, sortedString.Length - 1);
            }
            else if (choice == 2)
            {
                treeSortAlgorithm.Sort(sortedString);
            }
            else
            {
                Console.WriteLine("Неверный выбор алгоритма сортировки");
            }

            Console.WriteLine("Отсортированная строка: " + new string(sortedString));

            string newString = new string(stringArray);
            int randomNumber = int.Parse(GetRandomNumber(newString.Length).Result);
            Console.WriteLine("Строка с случайно удаленным символом: ", newString.Remove(randomNumber, 1));
        }

        static async Task<string> GetRandomNumber(int lenMax)
        {
            lenMax -= 1;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://www.random.org/integers/?num=1&min=0&max=" + lenMax.ToString() + "&col=1&base=10&format=plain&rnd=new";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обращении к удаленному API: {ex.Message}");
            }

            Random random = new Random();
            return random.Next(1, 1000).ToString();
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

    public class TreeNode
    {
        public char Key;
        public TreeNode Left, Right;

        public TreeNode(char item)
        {
            Key = item;
            Left = Right = null;
        }
    }

    class TreeSortAlgorithm
    {
        private TreeNode root;

        public void Sort(char[] array)
        {
            root = null;

            foreach (var element in array)
            {
                Insert(element);
            }

            InOrderTraversal(root, array);
        }

        private void Insert(char key)
        {
            root = InsertRec(root, key);
        }

        private TreeNode InsertRec(TreeNode root, char key)
        {
            if (root == null)
            {
                root = new TreeNode(key);
                return root;
            }

            if (key < root.Key)
            {
                root.Left = InsertRec(root.Left, key);
            }
            else if (key >= root.Key)
            {
                root.Right = InsertRec(root.Right, key);
            }

            return root;
        }
        private void InOrderTraversal(TreeNode root, char[] result)
        {
            int index = 0;
            InOrderTraversal(root, result, ref index);
        }

        private void InOrderTraversal(TreeNode root, char[] result, ref int index)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left, result, ref index);
                result[index++] = root.Key;
                InOrderTraversal(root.Right, result, ref index);
            }
        }
    }

    class QuickSortString
    {
        public static void QuickSort(char[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                QuickSort(array, low, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, high);
            }
        }

        static int Partition(char[] array, int low, int high)
        {
            char pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;

                    char temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            char temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }
    }

    class AlphabetException : Exception
    {
        public AlphabetException(string message): base(message) { }
    }
}
