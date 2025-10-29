using Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    internal class OnlineBook : ILibraryItems
    {
        public int ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public DateTime PublishDate { get; set; }

        //Digital book properties
        public double FileSizeMB { get; set; }
        public string FileFormat { get; set; }
        public string DownloadURL { get; set; }
    }
}
