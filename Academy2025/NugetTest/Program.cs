namespace NuGetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataGenerator = new DataGenerator();
            var data = dataGenerator.Generate(10);

            //Console.WriteLine(JsonSerializer.Serialize(data));

            foreach (var item in data)
            {
                //Console.WriteLine($"{item.Id}-{item.Manufacturer}-{item.Description!.Substring(0, 10)}");
                Console.WriteLine($"{item.Id}-{item.Manufacturer}-{item.Description![..10]}");
            }
        }
    }
}
