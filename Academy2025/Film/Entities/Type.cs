using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public record Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public override string ToString()
        {
            return $"{TypeId}: {TypeName}";
        }
    }
}
