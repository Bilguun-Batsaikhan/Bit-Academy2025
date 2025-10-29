using System.Text.Json;

namespace LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Vehicle>()
            {
                new() { Manufacturer = "BMW", Date = DateTime.Now },
                new() { Manufacturer = "BMW", Date = DateTime.Now },
                new() { Manufacturer = "Audi", Date = new DateTime(2000,1,1) },
                new() { Manufacturer = "Fiat", Date = new DateTime(1990, 12, 1) },
                new() { Manufacturer = "Audi", Date = DateTime.Now }
            }; 

            var manList = list.Select(i => i.Manufacturer).Distinct();

            var filteredList = list.Where(vehicle => vehicle.Date < new DateTime(2025, 1, 1) && manList.Contains(vehicle.Manufacturer!));
            var filteredList2 = FilterVehicles(list, "BMW");

            Console.WriteLine(JsonSerializer.Serialize(filteredList));
            Console.WriteLine(JsonSerializer.Serialize(filteredList2));

            var firstVehicle = list.OrderByDescending(v => v.Date).FirstOrDefault(v => v.Manufacturer == "Audi");
            Console.WriteLine(firstVehicle);
        }

        static IEnumerable<Vehicle> FilterVehicles(List<Vehicle> vehicles, string manufacturer)
        {
            var results = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Manufacturer == manufacturer)
                    results.Add(vehicle);
            }

            return results;
        }
    }

    //record Vehicle(string? Manufacturer, DateTime Date);

    record Vehicle
    {
        public string? Manufacturer { get; init; }
        public DateTime Date { get; init; }
    }
}
