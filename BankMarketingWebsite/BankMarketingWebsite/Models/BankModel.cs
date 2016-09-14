using System.Collections;
using System.Linq;
using System.Reflection;

namespace BankMarketingWebsite.Models
{
    public class BankModel
    {
        public string WillSubscribe(InputParameters input)
        {
            return null;
        }

        static IEnumerable[] GetInputColumns(InputParameters input)
        {
            return GetInputProperties().Select(p =>
            {
                var value = p.GetValue(input);
                if (value is int)
                    return new[] {(int) value} as IEnumerable;
                if (value is double)
                    return new[] {(double) value} as IEnumerable;
                return new[] {(string) value};
            }).ToArray();
        }

        static string[] GetColumnNames()
        {
            return GetInputProperties().Select(p => p.Name).ToArray();
        }

        static PropertyInfo[] GetInputProperties()
        {
            return typeof(InputParameters).GetProperties()
                .Where(p => new[] {typeof(int), typeof(double), typeof(string)}.Contains(p.PropertyType))
                .ToArray();
        }
    }
}