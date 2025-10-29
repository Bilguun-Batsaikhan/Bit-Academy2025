using System.Text.Json;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Simple Linq example

            var list = new List<TestSubject>()
            {
                new() { Index = 0, Name = "X0" },
                new() { Index = 1, Name = "X1" },
                new() { Index = 2, Name = "X2" }
            };

            var items = (from i in list
                         where i.Index >= 1
                         orderby i.Name descending
                         select i);

            var res = list.Where(i => i.Index >= 1).OrderByDescending(i => i.Name);

            #endregion

            #region Linq GroupBy

            List<Person> persons = [
                new() { Id = 1, Car = "Ferrari" },
                new() { Id = 1, Car = "Fiat" },
                new() { Id = 2, Car = "Audi" },
                new() { Id = 3, Car = "BMW" }
            ];

            persons = persons.FilterAndOrderDescending(p => p.Id < 10, p => p.Id).ToList();

            var results = from p in persons
                          group p.Car by p.Id into g
                          select new { PersondId = g.Key, Cars = g.ToList() };

            Console.WriteLine(JsonSerializer.Serialize(results));

            results = persons.GroupBy(p => p.Id, p => p.Car, (key, g) => new { PersondId = key, Cars = g.ToList() });

            Console.WriteLine(JsonSerializer.Serialize(results));

            #endregion
        }
    }

    class TestSubject
    {
        public int Index { get; set; }
        public string? Name { get; set; }
    }

    class Person
    {
        public int Id { get; set; }
        public string? Car { get; set; }
    }

    static class Extensions
    {
        public static IEnumerable<Person> FilterAndOrderDescending(this IEnumerable<Person> people, Func<Person, bool> expression, Func<Person, int> orderExpression)
        {
            return people.OrderByDescending(orderExpression).Where(expression);
        }
    }
}
