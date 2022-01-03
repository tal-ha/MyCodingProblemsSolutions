using NUnit.Framework;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public class TestProbTwoSum
    {
        [Test]
        public void Test1()
        {
            // Input
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;

            // Output
            int[] expectedResult = new int[] { 0, 1 };
            int[] result = this.TwoSum(nums, target);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;

            // Output
            int[] expectedResult = new int[] { 1, 2 };
            int[] result = this.TwoSum(nums, target);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            int[] nums = new int[] { 3, 3 };
            int target = 6;

            // Output
            int[] expectedResult = new int[] { 0, 1 };
            int[] result = this.TwoSum(nums, target);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        private int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[0];
        }

        private void AreExactlySame(int[] expected, int[] actual)
        {
            Assert.IsTrue(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}