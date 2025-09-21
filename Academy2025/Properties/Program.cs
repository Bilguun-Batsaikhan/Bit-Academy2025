using Properties.Classes;

namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new() { Name = "Andrea", Surname = "Rossi" };
            p.Age = 10;
            p.SetMyProp(999);
            p.MyProperty = 50;
            Console.WriteLine(p.MyProperty);

            Console.WriteLine(p.Age);
        }
    }
}
