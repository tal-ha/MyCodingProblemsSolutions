using NUnit.Framework;
using System;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/power-of-two/
    /// </summary>
    public class TestProbPowerOfTwo
    {
        [Test]
        public void Test1()
        {
            // Input
            int n = 1;

            // Output
            bool expectedResult = true;
            bool result = IsPowerOfTwo(n);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            int n = 16;

            // Output
            bool expectedResult = true;
            bool result = IsPowerOfTwo(n);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            int n = 3;

            // Output
            bool expectedResult = false;
            bool result = IsPowerOfTwo(n);

            // Compare outputs
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsPowerOfTwo(int n)
        {
            for (int x = -31; x < 31; x++)
            {
                if (Math.Pow(2, x) == n)
                    return true;
            }

            return false;
        }
    }
}