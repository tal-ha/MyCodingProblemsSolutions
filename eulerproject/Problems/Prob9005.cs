using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject.Problems
{
    public class Prob9005 : IProblem
    {
        public int Solve()
        {
            IList<IPrintable> comps = new List<IPrintable>{
                new Company(1,"Comp_1", new List<Application>{ new Application("app1"), new Application("app2")}),
                new Company(2,"Comp_2", new List<Application>{ new Application("app1")}),
                new Company(3,"Comp_3", new List<Application>{ new Application("app1"), new Application("app2")}),
                new Company(4,"Comp_4", new List<Application>{ new Application("app1")}),
                new Company(5,"Comp_5", new List<Application>{ new Application("app1")}),
                new Company(6,"Comp_6", new List<Application>{ new Application("app1")}),
                new Company(7,"Comp_7", new List<Application>{ new Application("app1"), new Application("app2")}),
                new Company(8,"Comp_8", new List<Application>{ new Application("app1")}),
                new Company(9,"Comp_9", new List<Application>{ new Application("app1")}),
            };

            IList<string> test = new List<string> { "test1", "test2", "test3", "test4" };

            Println(test);


            return 0;
        }

        #region PrintMethods
        
        public void Println(object inp)
        {
            Print(inp);
            Console.WriteLine();
        }
        
        public void Print(object inp)
        {
            try
            {
                if (IsList(inp))
                {
                    foreach (var item in (IList<IPrintable>)inp)
                    {
                        item.Print();
                    }
                }
                else
                {
                    ((IPrintable)inp).Print();
                }
            }
            catch (Exception ex)
            {
                Console.Write(inp);
            }
        }

        public bool IsList(object o)
        {
            if (o == null)
                return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
        

        #endregion PrintMethods


    }


    public interface IPrintable
    {
        void Print();
    }

    public class Company : IPrintable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Application> Apps { get; set; }

        public Company(int id, string name, IList<Application> apps)
        {
            this.ID = id;
            this.Name = name;
            this.Apps = apps;
        }

        public void Print()
        {
            Console.WriteLine(string.Format("ID:{0}, Code:{1}, Apps#:{2}", this.ID, this.Name, this.Apps.Count));
        }

    }

    public class Application
    {
        public string Code { get; set; }

        public Application(string code)
        {
            this.Code = code;
        }
    }

}
