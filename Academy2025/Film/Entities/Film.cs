using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    namespace Entities
    {
        public record Film
        {
            public int FilmId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Type Type { get; set; }
            public Details Details { get; set; }
            public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

            public override string ToString()
            {
                var genreList = Genres != null && Genres.Any()
                ? string.Join(", ", Genres.Select(g => g.ToString()))
                : "None";
                return $@"
                FilmId: {FilmId}
                Name: {Name}
                Description: {Description}
                Type: {Type}
                Details: {Details}
                Genres: {genreList}
                ";
            }
        }
    }
}
