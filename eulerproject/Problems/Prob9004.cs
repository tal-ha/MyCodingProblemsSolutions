using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob9004 : IProblem
    {
        public int Solve()
        {
            string Name1 = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string Name2 = System.Environment.UserName;
            string Name3 = Environment.GetEnvironmentVariable("USERNAME");
            string Name4 = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.WriteLine(Name1);
            Console.WriteLine(Name2);
            Console.WriteLine(Name3);
            Console.WriteLine(Name4);
            return 0;
        }


    }
}
