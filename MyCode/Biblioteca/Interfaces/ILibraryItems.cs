using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Interfaces
{
    internal interface ILibraryItems
    {
        int ISBN { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool Available { get; set; }
        DateTime PublishDate { get; set; }
    }
}
