using Bogus;

namespace DictRefValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker<TestObj>()
                .RuleFor(o => o.Index, setter => setter.Random.Number(100))
                .RuleFor(o => o.Value, setter => setter.Random.Number(9999));

            var dict = new Dictionary<string, List<TestObj>> { ["mykey"] = faker.Generate(2) };
            dict["mykey"].Add(new() { Index = 3, Value = 100 });

            Console.WriteLine(string.Join(", ", dict["mykey"]));
        }
    }

    class TestObj
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Index}-{Value}";
        }
    }
}
