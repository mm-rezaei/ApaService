using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ApaGroup.Framework.Basis.Extensions
{
    public static class QueryableExtension
    {
        #region Public Methods

        public static IQueryable Union(this IQueryable inSource1, IQueryable inSource2)
        {
            var methodCallExpression = Expression.Call(typeof(Queryable), "Union", new[]
                {
                    inSource1.ElementType
                }, new[]
                    {
                        inSource1.Expression,
                        inSource2.Expression
                    });
            return inSource2.Provider.CreateQuery(methodCallExpression);
        }

        public static IQueryable OrderBy(this IQueryable inSource, string inOrderByProperty, bool inAscending = true)
        {
            var elementType = inSource.ElementType;
            var propertyInfo = Enumerable.OfType<PropertyInfo>(((new[]
            {
                elementType
            }).Union(elementType.GetInterfaces()).Select((t => t.GetProperty(inOrderByProperty))))).FirstOrDefault();
            if (propertyInfo == null)
                throw new Exception(string.Format("Type {0} does not have {1} property.", elementType, inOrderByProperty));
            var parameterExpression = Expression.Parameter(elementType);
            var lambdaExpression =
                Expression.Lambda(Expression.MakeMemberAccess(parameterExpression, propertyInfo),
                                  new[]
                                      {
                                          parameterExpression
                                      });
            var methodCallExpression = Expression.Call(typeof(Queryable), inAscending ? "OrderBy" : "OrderByDescending", new[]
                {
                    elementType,
                    propertyInfo.PropertyType
                }, new[]
                    {
                        inSource.Expression,
                        Expression.Quote(lambdaExpression)
                    });
            return inSource.Provider.CreateQuery(methodCallExpression);
        }

        public static IQueryable ThenBy(this IQueryable inSource, string inOrderByProperty, bool inAscending = true)
        {
            var elementType = inSource.ElementType;
            var property = elementType.GetProperty(inOrderByProperty);
            var parameterExpression = Expression.Parameter(elementType);
            var lambdaExpression =
                Expression.Lambda(Expression.MakeMemberAccess(parameterExpression, property), new[]
                    {
                        parameterExpression
                    });
            var methodCallExpression = Expression.Call(typeof(Queryable), inAscending ? "ThenBy" : "ThenByDescending", new[]
                {
                    elementType,
                    property.PropertyType
                }, new[]
                    {
                        inSource.Expression,
                        Expression.Quote(lambdaExpression)
                    });
            return inSource.Provider.CreateQuery(methodCallExpression);
        }

        public static IQueryable Page(this IQueryable inSource, int inStartIndex, int inRecordCount)
        {
            var queryable = inSource;
            var elementType = inSource.ElementType;
            if (inStartIndex > 0)
            {
                var methodCallExpression = Expression.Call(typeof(Queryable), "Skip", new[]
                    {
                        elementType
                    }, new[]
                        {
                            queryable.Expression,
                            Expression.Constant(inStartIndex)
                        });
                queryable = queryable.Provider.CreateQuery(methodCallExpression);
            }
            if (inRecordCount > 0)
            {
                var methodCallExpression = Expression.Call(typeof(Queryable), "Take", new[]
                    {
                        elementType
                    }, new[]
                        {
                            queryable.Expression,
                            Expression.Constant(inRecordCount)
                        });
                queryable = inSource.Provider.CreateQuery(methodCallExpression);
            }
            return queryable;
        }

        public static IQueryable Page(this IQueryable inSource, int inPageNumber)
        {
            return Page(inSource, inPageNumber, 50);
        }

        public static IQueryable Where(this IQueryable inSource, LambdaExpression inPredicate)
        {
            var methodCallExpression = Expression.Call(typeof(Queryable), "Where", new[]
                {
                    inSource.ElementType
                }, new[]
                    {
                        inSource.Expression,
                        Expression.Quote(inPredicate)
                    });
            return inSource.Provider.CreateQuery(methodCallExpression);
        }

        #endregion
    }
}