using Expedia.CodingExercise.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
public static class Utilities
{
    /// <summary>
    /// Get application settings value.
    /// </summary>
    /// <param name="key">The application settings key.</param>
    /// <param name="defaultValue">The default Value incase the key not found.</param>
    /// <returns>
    /// The value of the key application settings.
    /// </returns>
    public static T GetConfigurationValue<T>(string key, T defaultValue)
    {
        var item = ConfigurationManager.AppSettings[key];
        if (!string.IsNullOrEmpty(item))
        {
            return (T)Convert.ChangeType(item, typeof(T));
        }
        return defaultValue;
    }
    /// <summary>
    /// Convert list of strings to single line string.
    /// </summary>
    /// <param name="list">The list needs to be single line.</param>
    /// <param name="separator">The separator you need between the values.</param>
    /// <returns>
    /// The single string.
    /// </returns>
    public static string ToSingleLine(this List<string> list, string separator = "\r\n")
    {
        return string.Join(separator, list);
    }
    /// <summary>
    /// Get the resource message based on eResponseCode enum.
    /// </summary>
    /// <param name="value">The eResponseCode enum.</param>
    /// <returns>
    /// The Message of the code.
    /// </returns>
    public static string Message(this eResponseCode value)
    {
        var code = value.Code();

        return ResourcesManager.GetMessage(code);
    }
    /// <summary>
    /// Convert enum to its string value.
    /// </summary>
    /// <param name="value">The enum.</param>
    /// <returns>
    /// The string value.
    /// </returns>
    public static string Code(this Enum value)
    {
        return (Convert.ToInt32(value)).ToString();
    }

    /// <summary>
    /// Do orderby and sorting by string parameter
    /// </summary>
    /// <param name="list">The unsorted list.</param>
    /// <param name="orderBy">The sorting parameters.</param>
    /// <returns>
    /// The sorted list.
    /// </returns>
    public static List<T> ApplyOrder<T>(this List<T> list, string orderBy)
    {
        return list.AsQueryable().ApplyOrder(orderBy).ToList();
    }
    public static IOrderedQueryable<T> ApplyOrder<T>(this IQueryable<T> query, string orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
        {
            return query as IOrderedQueryable<T>;
        }
        var orders = orderBy.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < orders.Length; i++)
        {
            var orderByExpression = orders[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (orderByExpression.Length == 1 || orderByExpression[1].ToUpper().Equals("ASC"))
            {
                query = query.ApplyOrder<T>(orderByExpression[0], true, i == 0);
            }
            else if (orderByExpression[1].ToUpper().Equals("DESC"))
            {
                query = query.ApplyOrder<T>(orderByExpression[0], false, i == 0);
            }
            else
            {
                throw new ArgumentException("OrderDirection is not valid");
            }
        }
        return query as IOrderedQueryable<T>;
    }
    public static IOrderedQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string property, bool ascending, bool first)
    {
        string methodName = "OrderBy";
        if (!first)
            methodName = "ThenBy";
        if (!ascending)
        {
            methodName += "Descending";
        }

        ParameterExpression parameter = Expression.Parameter(typeof(T), "t");
        Expression expr = parameter;
        foreach (string prop in property.Split('.'))
        {
            expr = Expression.PropertyOrField(expr, prop);
        }
        Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), expr.Type);
        LambdaExpression keySelector = Expression.Lambda(delegateType, expr, parameter);
        return (IOrderedQueryable<T>)
        typeof(Queryable).GetMethods().Single(
            method => method.Name == methodName
            && method.IsGenericMethodDefinition
            && method.GetGenericArguments().Length == 2
            && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), expr.Type)
            .Invoke(null, new object[] { source, keySelector });
    }

}