using System.Text.Json;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car("Toyota", "Corolla", 2020),
                new Car("Honda", "Civic", 2019),
                new Car("Ford", "Focus", 2018),
                new Car("BMW", "3 Series", 2021),
                new Car("Audi", "A4", 2022)
            };

            var filteredCars = cars.Where(c => c.Year < 2020);
            Console.WriteLine(JsonSerializer.Serialize(filteredCars));
            // TSource is a generic type parameter. It represents the type of elements in the collection you are working with.
            //public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

            /*
            •	public static: This is a static method, accessible without an instance.

            •	IEnumerable<TSource> Where<TSource>: It’s a generic method that returns an IEnumerable<TSource>, and works for any type TSource.

            •	(this IEnumerable<TSource> source, ...): The this keyword makes it an extension method, so you can call it on any IEnumerable<TSource> (like a list or array).

            •	Func<TSource, bool> predicate: This is a delegate (function pointer) that takes a TSource and returns a bool. It’s used to filter the collection.
             */

            /*
             •	A lambda expression (arrow function) is not itself a delegate, but it can be automatically converted to a delegate type if the context expects it.
             •	For example, c => c.Year < 2020 is a lambda expression. When you pass it to a method like Where, which expects a Func<Car, bool> delegate, the compiler creates a delegate instance from your lambda.
             */

            var results = from c in cars
                          group c by c.Year into g
                          select new { Year = g.Key, Count = g.Count() };
            // In LINQ, select new is used to create a new object (often an anonymous type) for each element in the result set.
            //•	For each group g, it creates a new object with two properties: Year (the group key) and Count (number of cars in that year).
            //•	The result is a collection of these new objects, not the original elements.
        }
    }
}
