using Inheritance.Classes;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Manufacturer = "Audi", Model = "Model 1" };
            car.Drive();

            Console.WriteLine(car);
            //PrintInfo(car);

            //Vehicle vehicle = new Vehicle() { Manufacturer = "Fiat" };


            Vehicle myVehicle = car as Vehicle;
            PrintInfo(myVehicle);
        }

        static void PrintInfo(Vehicle vehicle)
        {
            Console.WriteLine(vehicle);
        }
    }
}
