using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Career
{
    internal class Artist : Profession
    {
        public string ArtDirection { get; set; }
        public Artist(string Name = "Profession", int Pay = 0, string artDirection = "") : base(Name, Pay)
        {
            ArtDirection = artDirection;
        }

        public override void StartWork()
        {
            base.StartWork();
            Console.WriteLine("I am hungry");
        }
    }
}
