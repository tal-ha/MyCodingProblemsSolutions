using NUnit.Framework;
using System.Text.RegularExpressions;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/valid-number/
    /// </summary>
    public class TestProbValidNumber
    {
        private Regex rx;
        [SetUp]
        public void OnSetup()
        {
            rx = new Regex(@"[-+]?(\d+\.\d+|\d+\.|\.\d+|\d+)(e[-+]?\d+)?", RegexOptions.IgnoreCase);
        }

        [Test]
        public void Test1()
        {
            // Input
            string s = "0";

            // Output
            bool expectedResult = true;
            bool result = this.IsNumber(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            string s = "e";

            // Output
            bool expectedResult = false;
            bool result = this.IsNumber(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            string s = ".";

            // Output
            bool expectedResult = false;
            bool result = this.IsNumber(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsNumber(string s)
        {
            Match match = rx.Match(s);
            return match.Success && match.Value == s;
        }
    }
}