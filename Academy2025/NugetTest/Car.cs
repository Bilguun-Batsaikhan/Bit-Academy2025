namespace NuGetTest
{
    public class Car
    {
        public Guid Id { get; set; }
        public required string Manufacturer { get; set; }
        public string? Description { get; set; }
    }
}
