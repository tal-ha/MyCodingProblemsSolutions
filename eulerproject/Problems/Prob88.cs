using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob88 : IProblem
    {
        public int Solve()
        {
            long res = SumOfMinProdSum(2, 6);

            return 0;
        }

        public long SumOfMinProdSum(int kFrom, int kTo)
        {
            HashSet<long> res = new HashSet<long>();
            int initialVal = 1;
            for (int k = kFrom; k <= kTo; k++)
            {
                int[] set = new int[k];

                //init array
                for (int i = 0; i < set.Length; i++)
                {
                    set[i] = initialVal;
                }

                res.Add(MinProdSum(set, k));
            }

            return res.Sum();
        }

        public long MinProdSum(int[] set, int k)
        {
            long p = Prod(set);
            long s = Sum(set);

            if (p == s)
            {
                return s;
            }
            
            IncrAt(set, 0, k);
            return MinProdSum(set, k);
        }

        public long MinProdSum2(int[] set, int k)
        {
            long p = Prod(set);
            long s = Sum(set);

            if (p == s)
            {
                return s;
            }

            IncrAt(set, 0, k);
            return MinProdSum(set, k);
        }

        public void IncrAt(int[] set, int i, int k, int upperBound = 9)
        {
            if (i >= k)
            {
                return;
            }

            if (set[i] >= upperBound)
            {
                set[i] = 1;
                IncrAt(set, ++i, k, upperBound);
            }
            else
            {
                set[i]++;
            }
        }

        public long Prod(int[] set)
        {
            long prod = 1;
            for (int i = 0; i < set.Length; i++)
            {
                prod *= set[i];
            }

            return prod;
        }

        public long Sum(int[] set)
        {
            long sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                sum += set[i];
            }

            return sum;
        }
    }
}
