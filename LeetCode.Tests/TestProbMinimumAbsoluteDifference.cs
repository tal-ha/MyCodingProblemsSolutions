using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-absolute-difference/
    /// </summary>
    public class TestProbMinimumAbsoluteDifference
    {
        [Test]
        public void Test1()
        {
            // Input
            int[] arr = new int[] { 4, 2, 1, 3 };

            // Output
            IList<IList<int>> expectedResult = this.GetListOfListFromArray(new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } });
            IList<IList<int>> result = MinimumAbsDifference(arr);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            int[] arr = new int[] { 1, 3, 6, 10, 15 };

            // Output
            IList<IList<int>> expectedResult = this.GetListOfListFromArray(new int[][] { new int[] { 1, 3 } });
            IList<IList<int>> result = MinimumAbsDifference(arr);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            int[] arr = new int[] { 3, 8, -10, 23, 19, -4, -14, 27 };

            // Output
            IList<IList<int>> expectedResult = this.GetListOfListFromArray(new int[][] { new int[] { -14, -10 }, new int[] { 19, 23 }, new int[] { 23, 27 } });
            IList<IList<int>> result = MinimumAbsDifference(arr);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            // sort input arr asc
            arr = arr.OrderBy(a => a).ToArray();

            // find minimum abs diff
            int minAbsDiff = Math.Abs(arr[0] - arr[1]);
            if (minAbsDiff != 1)
            {
                for (int i = 0; i < arr.Length - 1 && minAbsDiff != 1; i++)
                {
                    int absDiff = Math.Abs(arr[i] - arr[i + 1]);
                    if (absDiff < minAbsDiff)
                    {
                        minAbsDiff = absDiff;
                    }
                }
            }

            // form pairs
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int a = arr[i];
                int b = arr[i + 1];
                int absDiff = Math.Abs(a - b);
                if (absDiff == minAbsDiff)
                {
                    res.Add(new List<int>() { a, b });
                }
            }

            return res;
        }

        private IList<IList<int>> GetListOfListFromArray(int[][] arr)
        {
            IList<IList<int>> list = new List<IList<int>>();
            foreach (int[] item in arr)
            {
                list.Add(item.ToList() as IList<int>);
            }

            return list;
        }

        private void AreExactlySame(IList<IList<int>> expected, IList<IList<int>> actual)
        {
            Assert.IsTrue(expected.Count == actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                IList<int> expectedItem = expected[i];
                IList<int> actualItem = actual[i];
                Assert.IsTrue(expectedItem.Count == actualItem.Count);

                for (int j = 0; j < expectedItem.Count; j++)
                {
                    Assert.AreEqual(expectedItem[j], actualItem[j]);
                }
            }
        }
    }
}