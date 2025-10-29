using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Career
{
    internal class Profession
    {
        public string Name { get; set; }
        protected readonly int Pay;
        public Profession(string name = "Profession", int Pay = 0)
        {
            Name = name;
            this.Pay = Pay;
        }
        public virtual void StartWork()
        {
            Console.WriteLine("Working");
        }
    }
}
