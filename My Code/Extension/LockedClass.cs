using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public sealed class LockedClass
    {
        public void SayHello(string Name)
        {
            Console.WriteLine($"Hello {Name}");
        }
    }
}
