using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// https://projecteuler.net/problem=26
    /// </summary>
    public class Prob26 : IProblem
    {
        public int Solve()
        {
            int maxRO = 6;
            for (decimal i = 11; i < 1000; i++)
            {
                decimal res = 1 / i;
                //int max = RecurringCycleDigitCount(res);
                int max = 9999;
                if (max > maxRO)
                {
                    maxRO = max;
                }
            }

            return 998;
        }

        //12121231212123

        //private int RecurringCycleDigitCount(int[] vals)
        //{
        //    for (int i = 0; i < vals.Length; i++)
        //    {
        //        int v = vals[i];


        //    }
        //}
    }
}
