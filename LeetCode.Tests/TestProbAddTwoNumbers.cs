using NUnit.Framework;

namespace LeetCode.Tests
{
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    public class TestProbAddTwoNumbers
    {
        public ListNode res;
        [SetUp]
        public void OnSetup()
        {
            res = null;
        }

        [Test]
        public void Test1()
        {
            // Input
            ListNode l1 = this.GetListNodeFromArray(new int[] { 2, 4, 3 });
            ListNode l2 = this.GetListNodeFromArray(new int[] { 5, 6, 4 });

            // Output
            ListNode expectedResult = this.GetListNodeFromArray(new int[] { 7, 0, 8 });
            ListNode result = this.AddTwoNumbers(l1, l2);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test2()
        {
            // Input
            ListNode l1 = this.GetListNodeFromArray(new int[] { 0 });
            ListNode l2 = this.GetListNodeFromArray(new int[] { 0 });

            // Output
            ListNode expectedResult = this.GetListNodeFromArray(new int[] { 0 });
            ListNode result = this.AddTwoNumbers(l1, l2);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        [Test]
        public void Test3()
        {
            // Input
            ListNode l1 = this.GetListNodeFromArray(new int[] { 9, 9, 9, 9, 9, 9, 9 });
            ListNode l2 = this.GetListNodeFromArray(new int[] { 9, 9, 9, 9 });

            // Output
            ListNode expectedResult = this.GetListNodeFromArray(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 });
            ListNode result = this.AddTwoNumbers(l1, l2);

            // Compare outputs
            this.AreExactlySame(expectedResult, result);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return res;
            }

            int sum = 0;
            int carry = 0;
            if (l1 == null)
            {
                sum = l2.val;
            }
            else if (l2 == null)
            {
                sum = l1.val;
            }
            else
            {
                sum = l1.val + l2.val;
            }

            if (sum >= 10)
            {
                carry = 1;
                sum -= 10;
            }

            if (carry > 0)
            {
                if (l1 == null)
                {
                    if (l2.next == null)
                    {
                        l2.next = new ListNode(carry);
                    }
                    else
                    {
                        l2.next.val += carry;
                    }
                }
                else
                {
                    if (l1.next == null)
                    {
                        l1.next = new ListNode(carry);
                    }
                    else
                    {
                        l1.next.val += carry;
                    }
                }
            }

            Add(ref res, sum);
            if (l1 == null)
            {
                return AddTwoNumbers(null, l2.next);
            }
            else if (l2 == null)
            {
                return AddTwoNumbers(l1.next, null);
            }
            else
            {
                return AddTwoNumbers(l1.next, l2.next);
            }
        }

        /// <summary>
        /// Inserts value to the link list
        /// </summary>
        public void Add(ref ListNode ll, int val)
        {
            if (ll == null)
                ll = new ListNode(val);
            else
                Add(ref ll.next, val);
        }

        /// <summary>
        /// Helper method to prepare link list from given array
        /// </summary>
        public ListNode GetListNodeFromArray(int[] vals)
        {
            ListNode ln = null;
            foreach (int val in vals)
            {
                Add(ref ln, val);
            }

            return ln;
        }

        private void AreExactlySame(ListNode expected, ListNode actual)
        {
            while (expected != null || actual != null)
            {
                Assert.IsNotNull(expected);
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.val, actual.val);
                expected = expected.next;
                actual = actual.next;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}