using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Tests
{
    public class TestTimeIntervalOverlaps
    {
        [Test]
        public void Test1()
        {
            TimeInterval t1 = new TimeInterval(new DateTime(2013, 1, 1), new DateTime(2013, 12, 31));
            TimeInterval t2 = new TimeInterval(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31));
            TimeInterval t3 = new TimeInterval(new DateTime(2013, 6, 1), new DateTime(2014, 6, 1));
            TimeInterval t4 = new TimeInterval(new DateTime(2014, 1, 1), new DateTime(2014, 12, 31));
            TimeInterval t5 = new TimeInterval(new DateTime(2014, 7, 1), new DateTime(2014, 7, 2));

            TimeInterval t6 = new TimeInterval(new DateTime(2016, 1, 1), new DateTime(9999, 12, 31));
            TimeInterval t7 = new TimeInterval(new DateTime(2015, 1, 1), new DateTime(2015, 12, 31));
            TimeInterval t8 = new TimeInterval(new DateTime(2014, 1, 1), new DateTime(2015, 1, 1));
            TimeInterval t9 = new TimeInterval(new DateTime(2016, 1, 1), new DateTime(9999, 12, 31));

            //IList<TimeInterval> tList = new List<TimeInterval>() { t1, t2, t3, t4, t5 };
            IList<TimeInterval> tList = new List<TimeInterval>() { t6, t7, t8 };
            Console.WriteLine(HasNoOverlap(t9, tList));
            
            //IList<IList<TimeInterval>> res = GetOverlappingPairs(tList);

            //int i = 0;
            //foreach (var subList in res)
            //{
            //    Console.WriteLine(string.Format("Pair#{0}", ++i));
            //    int j = 0;
            //    foreach (var item in subList)
            //    {
            //        Console.WriteLine(string.Format("--#{0} {1}-{2}", ++j, item.StartDate.ToString("dd.MM.yyy"), item.EndDate.ToString("dd.MM.yyy")));
            //    }
                
            //}
        }

        public static IList<IList<T>> GetOverlappingPairs<T>(IList<T> listToCheck) where T : TimeInterval
        {
            listToCheck = listToCheck.OrderBy(t => t.StartDate).ThenBy(t => t.EndDate).ToList();

            IList<IList<T>> overlappingPairsList = new List<IList<T>>();

            foreach(T t1 in listToCheck)
            {
                IList<T> pairs = new List<T>();
                foreach (T t2 in listToCheck)
                {
                    if (!t1.Equals(t2) && HasNoOverlap(t1, new List<T>() { t2 }))
                    {
                        continue;
                    }

                    bool insert = true;
                    foreach (T t3 in pairs)
                    {
                        if (HasNoOverlap(t2, new List<T>() { t3 }))
                        {
                            insert = false;
                            break;
                        }
                    }

                    if (insert)
                    {
                        pairs.Add(t2);
                    }
                }

                if (pairs.Count > 1)
                {
                    pairs = pairs.OrderBy(t => t.StartDate).ThenBy(t => t.EndDate).ToList();
                    if(IsUniquePair(overlappingPairsList, pairs))
                    {
                        overlappingPairsList.Add(pairs);
                    }
                }
            }

            return overlappingPairsList;

        }

        public static bool IsUniquePair<T>(IList<IList<T>> listOfPairs, IList<T> pairToCheck) where T : TimeInterval
        {
            if(listOfPairs.Count == 0)
            {
                return true;
            }

            foreach (var pair in listOfPairs)
            {
                if(pair.Count != pairToCheck.Count)
                {
                    continue;
                }

                bool duplicate = true;
                for (int i = 0; i < pair.Count; i++)
                {
                    if(pair[i].StartDate != pairToCheck[i].StartDate || pair[i].EndDate != pairToCheck[i].EndDate)
                    {
                        duplicate = false;
                        break;
                    }
                }
                if (duplicate)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasNoOverlap<T>(T intervalToCheck, IList<T> targetList) where T : TimeInterval
        {
            if (intervalToCheck == null || targetList == null || targetList.Count == 0)
            {
                return true;
            }

            return HasNoOverlap(intervalToCheck, targetList.Cast<TimeInterval>().ToList());
        }

        public static bool HasNoOverlap(TimeInterval intervalToCheck, IList<TimeInterval> targetList)
        {
            if (intervalToCheck == null || targetList == null || targetList.Count == 0)
            {
                return true;
            }

            IList<TimeInterval> fixedTargetList = targetList.Where(t => !t.Equals(intervalToCheck)).ToList();

            return HasNoOverlap(intervalToCheck.StartDate.Date, intervalToCheck.EndDate.Date, fixedTargetList);
        }

        public static bool HasNoOverlap(DateTime start, DateTime end, IList<TimeInterval> targetList)
        {
            ////no intervalToCheck means no overlap
            if (targetList == null || targetList.Count == 0)
            {
                return true;
            }

            foreach (TimeInterval current in targetList)
            {
                // case 1: intervalToCheck.Start and intervalToCheck.End before any current (historically valid) validfrom
                // orStart
                // case 7: intervalToCheck.Start and intervalToCheck.End greater than validTo => ok, but test against next interval
                if ((start < current.StartDate) & (end < current.StartDate)
                    || (start > current.EndDate) & (end > current.EndDate))
                {
                    continue;
                }

                // case 2: intervalToCheck.Start equals existing => overlap
                if (start.Date == current.StartDate.Date || end.Date == current.EndDate.Date)
                {
                    return false;
                }

                // case 3: intervalToCheck.Start and intervalToCheck.End overlap any current (historically valid) validFrom
                if (start.Date < current.StartDate.Date && end.Date >= current.StartDate.Date)
                {
                    return false;
                }


                // case 4: intervalToCheck.Start and intervalToCheck.End overlap any current (historically valid) intervalToCheck.End
                if (start.Date < current.StartDate.Date && end.Date > current.EndDate.Date)
                {
                    return false;
                }

                // case 5: intervalToCheck.Start and intervalToCheck.End are within existing intervalToCheck.Start and intervalToCheck.End
                if (start.Date > current.StartDate.Date && end.Date < current.EndDate.Date)
                {
                    return false;
                }

                // case 6: intervalToCheck.Start greater than existing but smaller than intervalToCheck.End => overlap
                if (start.Date > current.StartDate.Date && start.Date <= current.EndDate.Date)
                {
                    return false;
                }
            }

            return true;
        }

    }

    public class TimeInterval
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public TimeInterval(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
