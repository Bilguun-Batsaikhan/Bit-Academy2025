namespace Generics
{
    public record Item : IMyInterface
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
