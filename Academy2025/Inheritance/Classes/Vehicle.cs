namespace Inheritance.Classes
{
    public class Vehicle
    {
        public string? Manufacturer { get; set; }

        protected string? _color;

        public void Drive()
        {
            Console.WriteLine("The car is moving...");
        }
    }
}
