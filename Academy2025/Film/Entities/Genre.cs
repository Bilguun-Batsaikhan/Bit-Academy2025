using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public record Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public override string ToString()
        {
            return $"{GenreId}: {GenreName}";
        }
    }
}
