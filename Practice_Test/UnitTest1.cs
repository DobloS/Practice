using Microsoft.VisualStudio.TestPlatform.TestHost;
using Practice;

namespace Practice_Test
{
    public class Tests
    {
        [Test]
        public void ProcessedStringTest()
        {
            var res = StringOperation.ProcessedString("aa");
            Assert.AreEqual("aa", res);
        }

        [Test]
        public void FindLargestSubstringTest()
        {
            var res = StringOperation.FindLargestSubstring("aa");
            Assert.AreEqual("aa", res);
        }

        [Test]
        public void GetCountCharTest()
        {
            List<string> list = new List<string>(); 
            var res = StringOperation.GetCountChar("aa");
            list.Add("a 2"); 
            Assert.AreEqual(list, res);
        }

        [Test]
        public void CheckAlphabetTestTrue()
        {
            var res = StringOperation.CheckAlphabet("aa");
            Assert.AreEqual(true, res);
        }

        [Test]
        public void CheckAlphabetTestFalse()
        {
            var res = StringOperation.CheckAlphabet("AA");
            Assert.AreEqual(false, res);
        }

        [Test]
        public void CheckAlphabetTestBadAlphabet()
        {
            var res = StringOperation.CheckAlphabet("פûגפ");
            Assert.AreEqual(false, res);
        }

        [Test]
        public void CheckAlphabetTestInputInt()
        {
            var res = StringOperation.CheckAlphabet("123");
            Assert.AreEqual(false, res);
        }

        [Test]
        public void TreeSortAlgorithmTest()
        {
            TreeSortAlgorithm tsa = new TreeSortAlgorithm();
            var input = "cba".ToCharArray();
            tsa.Sort(input);
            string output = "abc";
            Assert.AreEqual(output, input);

        }

        [Test]
        public void QuickSortStringTest()
        {
            var input = "cba".ToCharArray();
            QuickSortString.QuickSort(input, 0 , input.Length - 1);
            string output = "abc";
            Assert.AreEqual(output, input);
        }
    }
}