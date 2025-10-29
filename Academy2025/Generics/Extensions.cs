using System.Text.Json;

namespace Generics
{
    public static class Extensions
    {
        public static void PrintValues<T>(this IEnumerable<T> list)
        {
            Console.WriteLine(JsonSerializer.Serialize(list));
        }

        public static IEnumerable<T> FilterAndOrderDescending<T>(this IEnumerable<T> list, Func<T, bool> expression, Func<T, int> orderExpression)
        {
            return list.OrderByDescending(orderExpression).Where(expression);
        }
    }
}
