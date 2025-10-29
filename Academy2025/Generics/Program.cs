namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<Item>();
            box.Set(new() { Id = 1, Name = "Item n. 1" });

            Console.WriteLine($"{box.Get()}");

            var myDict = new MyDictionary<string, Item>();
            myDict.Add("key", new());

            var list = new List<Item>() {
                new() { Id = 1, Name = "Item n. 1" },
                new() { Id = 2, Name = "Item n. 2" },
                new() { Id = 3, Name = "Item n. 3" },
            };

            list.FilterAndOrderDescending(i => i.Id < 100, i => i.Id).PrintValues();

            var numbers = new List<int>() { 2, 5, 78 };
            numbers.PrintValues();

            //dynamic dynamicObj = new Item();
        }
    }
}
