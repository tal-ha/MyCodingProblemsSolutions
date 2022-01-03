using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Sample.Tests
{
    public enum Comparison
    {
        LessThan,
        LessThanEqual,
        GreaterThan,
        GreaterThanEqual
    }

    public class TestAdvancedForLoop
    {
        [Test]
        public void Test1()
        {
            For(0, Comparison.LessThan, 5, 0.1M).Do((i) =>
            {
                Console.WriteLine(i);
            }, (i) =>
            {
                return false;
            }, (i) =>
            {
                return false;
            }, (i) =>
            {
                return i == 2.2M;
            });
        }

        public static IEnumerable<decimal> For(decimal from, Comparison operation, decimal to, decimal step = 1)
        {
            Func<decimal, decimal, bool> op;
            Func<decimal, decimal> itr;
            switch (operation)
            {
                case Comparison.LessThan:
                    op = (a, b) => a < b;
                    itr = (a) => a + step;
                    break;
                case Comparison.LessThanEqual:
                    op = (a, b) => a <= b;
                    itr = (a) => a + step;
                    break;
                case Comparison.GreaterThan:
                    op = (a, b) => a > b;
                    itr = (a) => a - step;
                    break;
                case Comparison.GreaterThanEqual:
                    op = (a, b) => a >= b;
                    itr = (a) => a - step;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            for (decimal i = from; op(i, to); i = itr(i))
            {
                yield return i;
            }
        }
        
    }

    public static class Ext
    {
        public static void Do(this IEnumerable<decimal> itr, Action<decimal> act, Func<decimal, bool> _breakBefore = null, Func<decimal, bool> _breakAfter = null, Func<decimal, bool> _continue = null)
        {
            foreach (decimal i in itr)
            {
                if (_breakBefore != null && _breakBefore(i))
                {
                    break;
                }

                if (_continue != null && _continue(i))
                {
                    continue;
                }

                act(i);

                if (_breakAfter != null && _breakAfter(i))
                {
                    break;
                }
            }
        }
    }


}
