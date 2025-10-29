namespace DapperExample.Entities
{
    public record Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
    }
}
