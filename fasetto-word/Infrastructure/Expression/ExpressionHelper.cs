using System;
using System.Linq.Expressions;
using System.Reflection;

namespace fasetto_word.Infrastructure.Expression
{
    public static class ExpressionHelper
    {
        /// <summary>
        /// compile a expression and get the function return value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> expression)
        {
            return expression.Compile().Invoke();
        }

        /// <summary>
        ///  set the underlying property value to the given value ,from a an expression that contains the property 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetPropertyValue<T>(this Expression<Func<T>> expression,T value)
        {
            //conver to a express ()=>some.property ,to some.property.
            if (!(expression.Body is MemberExpression memberExpression)) return;
            //get the property infomation. 
            var propertyInfo = (PropertyInfo) memberExpression.Member;
            //get the targer class.
            var target = System.Linq.Expressions.Expression.Lambda(memberExpression.Expression).Compile().DynamicInvoke();
            //set the value.
            propertyInfo.SetValue(target,value);
        }
    }
}