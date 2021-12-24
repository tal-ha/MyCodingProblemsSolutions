using eulerproject.Problems;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eulerproject
{
    class Program
    {
        #region Fields

        public static int PROBLEMNO = GetProblemNumberFromAppConfig();
        public static int LOOPCOUNT = GetLoopCountFromAppConfig();
        public const string PROBLEMPREFIX = "eulerproject.Problems.Prob";

        #endregion Fields

        #region Methods

        static void Main(string[] args)
        {
            Repeat:
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                decimal elapsedMs = 0;
                int ans = 0;
                for (int i = 0; i < LOOPCOUNT; i++)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    ans = Execute();
                    stopwatch.Stop();
                    elapsedMs += stopwatch.ElapsedMilliseconds;
                }
                elapsedMs /= LOOPCOUNT;
                Console.WriteLine(string.Format("Problem#{0} Answer:{1}", PROBLEMNO, ans));
                Console.WriteLine(string.Format("Elapsed ms:{0}, operations/s:{1:0.00}", elapsedMs, elapsedMs > 0 ? 1000 / elapsedMs : 0));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error occoured:{0}", ex.Message));
            }
            finally
            {
                stopwatch.Stop();
            }

            Console.WriteLine("Press 'r' to repeat or any other key to exit");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.R)
            {
                Console.Clear();
                goto Repeat;
            }
        }

        public static int Execute()
        {
            Type type = Type.GetType(PROBLEMPREFIX + PROBLEMNO.ToString(), true);
            IProblem problem = (IProblem)Activator.CreateInstance(type);
            return problem.Solve();
        }
        
        private static int GetProblemNumberFromAppConfig()
        {
            int result;
            if (!int.TryParse(ConfigurationManager.AppSettings["ProblemNumber"], out result))
            {
                Console.WriteLine("Invalid 'ProblemNumber' value. Provide a valid numbers.");
            }

            return result;
        }

        private static int GetLoopCountFromAppConfig()
        {
            int result;
            if (!int.TryParse(ConfigurationManager.AppSettings["LoopCount"], out result))
            {
                Console.WriteLine("Invalid 'LoopCount' value. Provide a valid numbers.");
            }

            return result;
        }

        #endregion Methods
    }
}
