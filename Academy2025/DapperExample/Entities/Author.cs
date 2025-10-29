namespace DapperExample.Entities
{
    public record Author
    {
        public int AuthorId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
