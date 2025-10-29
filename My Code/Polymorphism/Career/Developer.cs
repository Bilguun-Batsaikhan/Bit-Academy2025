using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Career
{
    internal class Developer : Profession
    {
        public string? ProgrammingLanguage { get; set; }
        public Developer(string Name, int Pay, string programmingLanguage) : base(Name, Pay) {
            ProgrammingLanguage = programmingLanguage;
        }
        public override void StartWork()
        {
            Console.WriteLine("Fixing a bug...for five hours");
        }
    }
}
