using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Cat : Animal
    {
        public Cat(string Name) : base(Name)
        {

        }
        public override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }
}
