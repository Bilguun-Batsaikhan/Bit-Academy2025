namespace Inheritance.Classes
{
    public class Car : Vehicle
    {
        public string? Model { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer}-{Model}";
        }
    }
}
