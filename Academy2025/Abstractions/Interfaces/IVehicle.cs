namespace Abstractions.Interfaces
{
    public interface IVehicle
    {
        string? Manufacturer { get; set; }
        void Drive();
        void Honk();
    }
}
