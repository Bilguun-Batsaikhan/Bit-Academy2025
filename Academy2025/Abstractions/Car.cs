using Abstractions.Interfaces;

namespace Abstractions
{
    public class Car : IVehicle, IEngine
    {
        public string? Manufacturer { get; set; }
        public string? HorsePower { get; set; }

        public void Drive()
        {
            Console.WriteLine("the car is moving");
        }

        public void Honk()
        {
            Console.WriteLine("Honk!");
        }
    }
}
