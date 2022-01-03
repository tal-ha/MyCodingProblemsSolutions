using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// https://projecteuler.net/problem=24
    /// </summary>
    public class Prob24 : IProblem
    {
        public int Solve()
        {

            //CalcPermutations(new int[] { 0,1,2,3,4,5,6,7,8,9 });


            string str = "0123456789";
            char[] arr = str.ToCharArray();
            List<string> resLst = new List<string>();
            GetPer(arr, ref resLst);
            resLst.Sort();

            //2783915604
            long ans = 2783915604;
            return 0;
        }
        
        private void CalcPermutations(int[] arr)
        {
            int len = arr.Length;
            string initVal = arr.AsString();
            List<string> unsortedPList = new List<string>();
            unsortedPList.Add(initVal);

            int swapIndex = len - 1;
            while (true)
            {
                if (swapIndex - 1 < 0)
                {
                    swapIndex = len - 1;
                }

                int a = arr[swapIndex];
                arr[swapIndex] = arr[swapIndex - 1];
                arr[swapIndex - 1] = a;

                swapIndex = swapIndex - 1;

                string currVal = arr.AsString();

                if (initVal != currVal)
                {
                    unsortedPList.Add(currVal);
                }
                else
                {
                    break;
                }
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static void GetPer(char[] list, ref List<string> resultList)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x, ref resultList);
        }

        private static void GetPer(char[] list, int k, int m, ref List<string> resultList)
        {
            if (k == m)
            {
                //Console.WriteLine(list);
                resultList.Add(list.AsString());
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m, ref resultList);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }
    }
}
