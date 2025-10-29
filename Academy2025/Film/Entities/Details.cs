using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public record Details
    {
        public int DetailsId { get; set; }  
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return "duration: " + Duration + " ReleaseDate: " + ReleaseDate.ToString() + " Rating: " + Rating;
        }
    }
}
