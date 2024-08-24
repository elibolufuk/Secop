using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System.Text;

namespace Secop.Core.Application.Extensions
{
    public static class EntityConfigurationExtensions
    {
        public static PropertyBuilder<TProperty> HasColumnDefaultName<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        {
            var propertyName = propertyBuilder.Metadata.Name;
            var columnName = propertyName.ToSnakeCase();
            propertyBuilder.HasColumnName(columnName);
            return propertyBuilder;
        }

        public static string HasTableName<T>()
        {
            return ToSnakeCase(typeof(T).Name);
        }

        public static string GetColumnName<T>(Expression<Func<T, object>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                return ToSnakeCase(memberExpression.Member.Name);
            }
            else if (propertyExpression.Body is UnaryExpression unaryExpression)
            {
                if (unaryExpression.Operand is MemberExpression operand)
                {
                    return ToSnakeCase(operand.Member.Name);
                }
            }

            throw new ArgumentException("Invalid property expression");
        }

        private static string ToSnakeCase(this string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return propertyName;

            var result = new StringBuilder();
            for (int i = 0; i < propertyName.Length; i++)
            {
                char currentChar = propertyName[i];

                if (char.IsUpper(currentChar))
                {
                    if (i > 0)
                        result.Append('_');

                    result.Append(char.ToLower(currentChar));
                }
                else
                {
                    result.Append(currentChar);
                }
            }
            return result.ToString();
        }
    }
}
