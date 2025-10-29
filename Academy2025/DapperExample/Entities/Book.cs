namespace DapperExample.Entities
{
    public record Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Category? Category { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<Author> Authors { get; set; } = [];
    }
}
