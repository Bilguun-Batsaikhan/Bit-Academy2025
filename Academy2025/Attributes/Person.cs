using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    public class Person
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }

        [StringLength(10)]
        [Custom("Fabio", Version = "1.0")]
        [Custom("Fabio", Version = "1.0")]
        public string? Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public void SetValues(string name, string surname, string? description = null, string? email = null)
        {

        }
    }
}
