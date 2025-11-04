using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    internal class Book : ILibraryItems
    {
        public int ISBN {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public DateTime PublishDate { get; set; }

        //Physical book specific items
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
        public bool IsReferenceOnly { get; set; }
    }
}
