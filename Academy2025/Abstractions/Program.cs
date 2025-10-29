namespace Abstractions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Sleep();

            var car = new Car() { Manufacturer = "BMW", HorsePower = "120CV" };
            Console.WriteLine(car.Manufacturer);
        }
    }
}
