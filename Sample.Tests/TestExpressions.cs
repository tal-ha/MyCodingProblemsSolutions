using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sample.Tests
{
    public class TestExpressions
    {
        [Test]
        public void Test1()
        {
            long[] ids = new long[] { 1, 2, 3, 4, 5, 6, 7 };
            var res = GetChunks(ids);
            //var res = GetByExpressionContains<Test>(ids, t => t.Name.Contains("Entity") && ids.Contains(t.ID), typeof(Test));
        }

        public IList<T> GetByExpressionContains<T>(long[] ids, Expression<Func<T, bool>> expression, Type tt)
        {
            int maxParamCount = 5;
            List<T> result = new List<T>();

            for (int i = 0; i < ids.Length; i += maxParamCount)
            {
                long[] idsPart = ids.Skip(i).Take(maxParamCount).ToArray();
                //expression = expression.AndAlso(x => idsPart.Contains(((Test)x).ID));
                //result.AddRange(data.Where(expression));
            }

            return result;
        }

        public T[][] GetChunks<T>(IEnumerable<T> arr, int chunkSize = 5)
        {
            T[][] result = arr
                .Select((v, i) => new { Val = v, Index = i })
                .GroupBy(x => x.Index / chunkSize)
                .Select(g => g.Select(x => x.Val).ToArray())
                .ToArray();

            return result;
        }

        public IList<Test> GetData() 
        {
            return new List<Test>()
            { 
                new Test(1, "Entity 1"),
                new Test(2, "Entity 2"),
                new Test(3, "Entity 3"),
                new Test(4, "Entity 4"),
                new Test(5, "Entity 5"),
                new Test(6, "Entity 6"),
                new Test(7, "Entity 7"),
                new Test(8, "Entity 8"),
                new Test(9, "Entity 9"),
                new Test(10, "Entity 10"),
            };
        }

        public class Test 
        {
            public Test()
            {
            }

            public Test(long id) : this()
            {
                this.ID = id;
            }

            public Test(long id, string name) : this(id)
            {
                this.Name = name;
            }

            public long ID { get; set; }
            public string Name { get; set; }
        }

        
    }

    public static class LinqExt
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.Subst[b.Parameters[0]] = p;

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.And(expr2);
        }

        internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
        {
            #region Fields

            private Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

            #endregion Fields

            #region Properties

            internal Dictionary<Expression, Expression> Subst
            {
                get { return this.subst; }
            }

            #endregion Properties

            #region Methods

            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression newValue;
                if (this.subst.TryGetValue(node, out newValue))
                {
                    return newValue;
                }

                return node;
            }

            #endregion Methods
        }
    }
}
