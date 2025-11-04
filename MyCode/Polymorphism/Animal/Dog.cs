using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Animal
{
    internal class Dog : IAnimal
    {
        public string Name { get; set; }

        void IAnimal.MakeNoise()
        {
            Console.WriteLine("Woof woof");
        }
    }
}
