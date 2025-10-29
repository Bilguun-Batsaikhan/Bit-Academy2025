using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Animal
{
    internal class Cat : IAnimal
    {
        public string Name { get; set; }

        // when you're overriding an interface don't use "override"
        void IAnimal.MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }
}
