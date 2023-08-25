using System;
using System.Linq.Expressions;

namespace ApaGroup.Framework.Basis.Extensions
{
    public static class ExpressionExtension
    {
        #region Public Methods

        public static Expression<Func<T, bool>> True<T>()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true, typeof (bool)),
                                                    new[] {Expression.Parameter(typeof (T), "f")});
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(false, typeof (bool)),
                                                    new[] {Expression.Parameter(typeof (T), "f")});
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> inExpression1,
                                                      Expression<Func<T, bool>> inExpression2)
        {
            var invocationExpression = Expression.Invoke(inExpression2, inExpression1.Parameters);

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(inExpression1.Body, invocationExpression),
                                                    inExpression1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> inExpression1,
                                                       Expression<Func<T, bool>> inExpression2)
        {
            var invocationExpression = Expression.Invoke(inExpression2, inExpression1.Parameters);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(inExpression1.Body, invocationExpression),
                                                    inExpression1.Parameters);
        }

        #endregion
    }
}