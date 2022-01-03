using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// https://projecteuler.net/problem=75
    /// </summary>
    public class Prob75 : IProblem
    {
        public int Solve()
        {
            int len = 600;
            int hlen = len / 2;
            Dictionary<double, string> res = new Dictionary<double, string>();
            for (int c = 5; c < hlen; c++)
            {
                int csq = c * c;
                List<double> skip = new List<double>();
                for (int a = 1; a < c; a++)
                {
                    if (skip.Contains(a))
                        continue;
                    int asq = a * a;
                    int bsq = csq - asq;
                    double b = Math.Sqrt(bsq);
                    if (b % 1 == 0)
                    {
                        skip.Add(b);
                        double sum = a + b + c;
                        string set = string.Format("<{0},{1},{2}> ", a,b,c);
                        if (res.ContainsKey(sum))
                        {
                            res[sum] += set;
                        }
                        else
                        {
                            res.Add(sum, set);
                        }
                    }
                }
            }

            int finRes = res.Count(kvp => kvp.Value.Split(new char[] { '<' }, StringSplitOptions.RemoveEmptyEntries).Length == 1);
            bool oddSum = res.Any(kvp => kvp.Key % 2 != 0);
            Console.WriteLine(finRes);

            return 0;
        }
    }
}
