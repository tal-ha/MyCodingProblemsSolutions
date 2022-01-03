using NUnit.Framework;
using System;
using System.Linq;

namespace Sample.Tests
{
    public class TestDailyHoursSpread
    {
        [Test]
        public void Test1()
        {
            this.SpreadDailyHours(8, 30);
        }

        public void SpreadDailyHours(int startHr = 8, int intervalMins = 60)
        {
            startHr = startHr > 0 && startHr < 24 ? startHr : 8;

            int[] validIntervals = new int[] { 15, 30, 45, 60 };
            intervalMins = validIntervals.Contains(intervalMins) ? intervalMins : 60;

            decimal intervalHr = intervalMins / 60m;

            int totalHrs = 24 + startHr;
            for (decimal h = startHr; h < totalHrs; h = h + intervalHr)
            {
                Time fromTime = new Time(h);
                Time toTime = new Time(h + intervalHr);

                string label = string.Format("{0} - {1}", fromTime.ToString(), toTime.ToString());
                Console.WriteLine(label);
            }

        }
    }

    public class Time
    {
        decimal _hrs;
        decimal _mins;

        public Time()
        {
            this.Hrs = 0;
            this.Mins = 0;
        }

        public Time(decimal hrs)
        {
            decimal hrsFlr = Math.Floor(hrs);
            this.Hrs = hrsFlr;
            this.Mins = Math.Floor((hrs - hrsFlr) * 60);
        }

        public decimal Hrs
        {
            get { return _hrs; }
            private set
            {
                if (value >= 24)
                {
                    _hrs = value - 24;
                }
                else
                {
                    _hrs = value;
                }
            }
        }

        public decimal Mins
        {
            get { return _mins; }
            private set
            {
                if (value >= 60)
                {
                    _hrs++;
                    _mins = 0;
                }
                else
                {
                    _mins = value;
                }
            }
        }

        public override string ToString()
        {
            string hrs = this.Hrs < 10 ? string.Concat(0, this.Hrs) : this.Hrs.ToString();
            string mins = this.Mins < 10 ? string.Concat(0, this.Mins) : this.Mins.ToString();

            return string.Format("{0}:{1}", hrs, mins);
        }
    }
}
