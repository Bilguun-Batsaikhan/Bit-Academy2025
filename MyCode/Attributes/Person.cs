using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Person
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        [StringLength(10)]
        public string? Description { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
