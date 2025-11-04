using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Animal
{
    internal interface IAnimal
    {
        string Name { get; set; }
        void MakeNoise(); 
    }
}
