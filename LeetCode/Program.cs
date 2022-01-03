using System;
using System.Diagnostics;
using LeetCode.Problems;

namespace LeetCode
{
    class Program
    {
        #region Fields

        public static string PROBLEMNAME = "TwoSum";
        public static int LOOPCOUNT = 1;
        public const string PROBLEMPREFIX = "LeetCode.Problems.Prob";

        #endregion Fields

        #region Methods

        static void Main(string[] args)
        {
        Repeat:
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                decimal elapsedMs = 0;
                for (int i = 0; i < LOOPCOUNT; i++)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    Execute();
                    stopwatch.Stop();
                    elapsedMs += stopwatch.ElapsedMilliseconds;
                }
                elapsedMs /= LOOPCOUNT;
                Console.WriteLine(string.Format("Problem#{0}", PROBLEMNAME));
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

        public static void Execute()
        {
            Type type = Type.GetType(PROBLEMPREFIX + PROBLEMNAME.ToString(), true);
            IProblem problem = (IProblem)Activator.CreateInstance(type);
            problem.Solve();
        }

        #endregion Methods
    }
}