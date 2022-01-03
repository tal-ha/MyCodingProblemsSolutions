using NUnit.Framework;
using System.Collections.Generic;

namespace Sample.Tests
{
    public class TestFactSum
    {
        [Test]
        public void Test1()
        {
            int count = 0;
            List<double> chain;

            for (int i = 1; i < 1000000; i++)
            {
                double s = i;
                chain = new List<double>() { s };
                while (true)
                {
                    s = FactSum(s);
                    if (chain.Contains(s))
                    {
                        if (chain.Count == 60)
                        {
                            count++;
                        }
                        break;
                    }
                    chain.Add(s);    
                }
                
            }
        }

        public double FactSum(double num)
        {
            double sum = 0;
            foreach (char c in num.ToString().ToCharArray())
            {
                sum += Fact(char.GetNumericValue(c));
            }
            return sum;
        }

        public double Fact(double n)
        {
            if (n<2)
            {
                return 1;
            }

            return n * Fact(n - 1);
        }
    }
}
