using System.Diagnostics;
using System.Linq;

namespace MoviesApp.Extensions
{
    public static class ObjectExtensions
    {
        public static TResult Copy<TSource, TResult>(this TSource input) where TResult : new()
        {
            return input.Copy(new TResult());
        }

        public static TResult Copy<TSource, TResult>(this TSource input, TResult output, bool skipKeys = true) where TResult : new()
        {
            if (input == null)
            {
                return default(TResult);
            }

            if (output == null)
            {
                output = new TResult();
            }

            var sourceProperties = input.GetType().GetProperties().Where(p => p.CanRead);
            var destinationProperties = output.GetType().GetProperties()
                .Where(p => sourceProperties.Select(s => s.Name).Contains(p.Name) && p.CanWrite);

            foreach (var dest in destinationProperties)
            {
                var source = sourceProperties.FirstOrDefault(p => p.Name == dest.Name && 
                                                                  p.PropertyType == dest.PropertyType && 
                                                                  p.Name != typeof(TResult).Name + "Id");
                if (source != null)
                {
                    var destValue = dest.GetValue(output);
                    var sourceValue = source.GetValue(input);
                    if (sourceValue != destValue)
                    {
                        dest.SetValue(output, sourceValue);
                    }
                }
            }

            return output;
        }

        public static int ToInt(this string input)
        {
            int value = -1;
            if (!int.TryParse(input, out value))
            {
                value = -1;
            }
            return value;
        }
    }
}