using NUnit.Framework;
using System.Text.RegularExpressions;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/decode-string/
    /// </summary>
    public class TestProbDecodeString
    {
        private Regex rx;
        [SetUp]
        public void OnSetup()
        {
            rx = new Regex(@"\d+\[\w+\]");
        }

        [Test]
        public void Test1()
        {
            // Input
            string s = "3[a]2[bc]";

            // Output
            string expectedResult = "aaabcbc";
            string result = DecodeString(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            string s = "3[a2[c]]";

            // Output
            string expectedResult = "accaccacc";
            string result = DecodeString(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            string s = "2[abc]3[cd]ef";

            // Output
            string expectedResult = "abcabccdcdcdef";
            string result = DecodeString(s);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        public string DecodeString(string s)
        {

            MatchCollection matches = rx.Matches(s);
            if (matches.Count == 0)
            {
                return s;
            }

            foreach (Match m in matches)
            {
                s = s.Replace(m.Value, DecodeStringPart(m.Value));
            }

            return DecodeString(s);
        }

        public string DecodeStringPart(string s)
        {
            string[] parts1 = s.Split("[");
            int repeatCount = int.Parse(parts1[0]);
            string[] parts2 = parts1[1].Split("]");
            string strToRepeat = parts2[0];

            string result = "";
            for (int i = 0; i < repeatCount; i++)
            {
                result += strToRepeat;
            }

            return result;
        }
    }
}