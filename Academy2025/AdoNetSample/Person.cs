namespace AdoNetSample
{
    public record Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }
    }
}
