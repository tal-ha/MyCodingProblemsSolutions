using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob9000 : IProblem
    {
        public int Solve()
        {
            method2(10000);
            return 0;
        }

        public void method1(int len)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in calc(len))
            {
                builder.Append(item);
            }
        }

        public void method2(int len)
        {
            List<string> lst = calc(len);
            StringBuilder builder = new StringBuilder();
            foreach (var item in lst)
            {
                builder.Append(item);
            }
        }

        public List<string> calc(int len)
        {
            List<string> strList = new List<string>();
            for (int i = 0; i < len; i++)
            {
                strList.Add(i.ToString());
            }
            return strList;
        }
    }
}
