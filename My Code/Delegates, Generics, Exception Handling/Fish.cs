using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates__Generics__Exception_Handling
{
    internal struct Fish
    {
        public string? Name {  get; set; }
        public void SayHello() { Console.WriteLine("Hello I'm " + Name); }
    }
}
