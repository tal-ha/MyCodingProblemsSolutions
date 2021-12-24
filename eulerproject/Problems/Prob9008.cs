using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob9008 : IProblem
    {
        public string Bool(object a) => Validate(a, typeof(bool));
        public string Int(object a) => Validate(a, typeof(int));
        public int Solve()
        {

            int a = 1;
            string result = Int(a);
            Console.WriteLine(result);

            return 0;
        }


        public string Validate(object obj, Type type)
        {
            if (obj == null || obj.GetType() != type)
            {
                throw new InvalidCastException();
            }
            
            return obj.ToString();
        }
       
    }
}
