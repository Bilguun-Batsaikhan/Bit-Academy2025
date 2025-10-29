using System.Collections;

namespace ArraysAndCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[10];

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] numbers1 = new int[] { 1, 2, 3 };

            //string[] names = ["Christian", "Alessio", "Giorgia"];
            //var x = names.Append("Marian").ToArray()[3];
            //Console.WriteLine(x);
            //Console.WriteLine(names.Length);

            //List<int> list = new List<int>() { 0, 2, 5 };
            //List<string> names = new List<string>() { "Andrea", "Mario" };
            //List<string> names2 = ["Andrea", "Mario"];

            //list.Add(10);

            //Console.WriteLine(list.Count);

            //int[,] numbers = { { 1, 2, 3, 4 }, { 3, 4, 5, 6 } };
            //numbers[0, 1] = 200;
            //Console.WriteLine(numbers[0, 1]);

            Dictionary<string, List<string>> books = new();
            books.Add("Antonio", ["Book1", "Book2"]);
            books.Add("Mario", ["Book3", "Book4"]);

            Dictionary<string, List<string>> books_alt = new()
            {
                { "Antonio", ["Book1", "Book2"] },
                { "Mario", ["Book3", "Book4"] }
            };

            books.TryGetValue("Antonio", out List<string>? antonioBooks);
            //Console.WriteLine(antonioBooks![1]);

            List<string>? results = books.GetValueOrDefault("Antonio");
            Console.WriteLine(results);

            KeyValuePair<string, List<string>> bookkvp = new("Joe", ["Harry Potter", "Another Book"]);

            string booklist = string.Join(',', bookkvp.Value);
            Console.WriteLine($"{bookkvp.Key} | {booklist}");

            var array = booklist.Split(',');

            Console.WriteLine(books.ContainsKey("Mario"));
        }
    }
}
