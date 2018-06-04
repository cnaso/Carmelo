using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Carmelo.Word.Extensions
{
    /// <summary>
    /// Convenience extensions for <see cref="Expression"/>.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Calls the Invoke() method on the <see cref="Expression"/> to return it's value.
        /// </summary>
        /// <typeparam name="T">Expressions type.</typeparam>
        /// <param name="expression">Expression to get property from.</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> expression)
        {
            return expression.Compile().Invoke();
        }

        /// <summary>
        /// Sets the <see cref="Expression"/> property value.
        /// </summary>
        /// <typeparam name="T">Expressions type.</typeparam>
        /// <param name="expression">Expression to set property of.</param>
        /// <param name="value">The value to set the property.</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> expression, T value)
        {
            var lambdaExpression = expression.Body as MemberExpression;
            var propertyInfo = lambdaExpression.Member as PropertyInfo;
            var target = Expression.Lambda(lambdaExpression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
