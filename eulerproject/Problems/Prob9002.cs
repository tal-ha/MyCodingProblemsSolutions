using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob9002 : IProblem
    {
        public int Solve()
        {
            int length = 9999999;
            //int[] primes = FindPrimes(length);
            List<int> nonPrimes = NonPrimeOdd(length);
            int minP = 0;
            //var hmm = AllesOk(nonPrimes);

            for (int i = nonPrimes.Count - 1; i >= 0; i--)
            {
                int n = nonPrimes[i];
                int phiN = Tot(n);
                if (IsPerm(phiN, n))
                {
                    int res = n / phiN;
                    if (res < minP)
                    {
                        minP = res;
                        Console.WriteLine(string.Format("minP {0}: {1}", n, minP));
                    }
                }
            }

            Console.WriteLine(string.Format("minP {0}", minP));

            return 0;
        }

        public static bool AllesOk(List<int> nonPrimes)
        {
            return !nonPrimes.Any(x => x % 2 == 0 || IsPrime(x));
        }

        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static List<int> NonPrimeOdd(int len)
        {
            List<int> allNums = new List<int>();
            for (int i = 2; i <= len; i++)
            {
                allNums.Add(i);
            }
            
            int[] primes = FindPrimes(len, allNums);
            allNums = allNums.Except(primes).ToList(); //remove primes
            allNums.RemoveAll(RemoveEven); //remove evens
            return allNums;
        }

        public static void Init2()
        {
            int len = 10000000;
            int len2 = 127;
            //int[] primes = FindPrimes(len);
            for (int i = 27; i > 1; i = i-2)
            {
                Console.WriteLine(i);
            }
            //int[] primes2 = FindPrimes2(len2);
            //var q = primes.Except(primes2).ToList();
            //bool res = primes.SequenceEqual(primes2);
            //Console.WriteLine(res ? res.ToString() : res.ToString() + ":" + q.Count);
            //Hack(primes);
        }

        public static void Hack(int[] primes)
        {
            int len = primes.Length;
            int maxP = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                int n = primes[i];
                int phiN = n - 1;
                if (IsPerm(phiN, n))
                {
                    int res = n / phiN;
                    if (res > maxP)
                    {
                        maxP = res;
                        Console.WriteLine(string.Format("MaxP {0}: {1}", n, maxP));
                    }
                }
            }
        }

        public static int Tot(int n)
        {
            int count = 1;
            for (int i = 2; i < n; i++)
            {
                if (n % i != 0 && GCD(n, i) == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public static bool IsPerm(int x, int y) // 20000ms
        {
            return x.ToString().OrderBy(o=>o).SequenceEqual(y.ToString().OrderBy(o => o));
        }

        public static int GCD(int a, int b) // 4500ms
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static int[] FindPrimes(int n)
        {
            
            List<int> allNums = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                allNums.Add(i);
            }

            return FindPrimes(n, allNums);
        }

        public static int[] FindPrimes(int n, List<int> numList)
        {
            List<int> allNums = new List<int>(numList);
            double sqrtN = Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= sqrtN; i++)
            {
                int p = allNums.Where(x => x == i).FirstOrDefault();
                if (p == 0) continue;
                int s = 0;
                for (int j = s, d = 2; j < allNums.Count; j++)
                {
                    int num = allNums[j];
                    int pd = p * d;
                    if (num == pd)
                    {
                        allNums[j] = -1;
                        d++;
                        s = j + 1;
                    }
                    else if (num > pd)
                    {
                        d++;
                        j--;
                        s = j + 1;
                    }
                }

                allNums.RemoveAll(RemoveNegative);

            }

            return allNums.ToArray();
        }

        private static bool RemoveNegative(int i)
        {
            return i == -1;
        }

        private static bool RemoveEven(int i)
        {
            return i % 2 == 0;
        }

        public static int[] FindPrimes2(int n)
        {
            double sqrtN = Math.Floor(Math.Sqrt(n));
            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                primes.Add(i);
            }

            for (int i = 2; i <= sqrtN; i++)
            {
                int p = primes.Where(x => x == i).FirstOrDefault();
                if (p == 0) continue;
                for (int j = 2; ((p * j) - 2) < primes.Count; j++)
                {
                    primes[(p * j) - 2] = -1;
                }
                                
            }

            primes.RemoveAll(RemoveNegative);

            return primes.ToArray();
        }

    }
}
