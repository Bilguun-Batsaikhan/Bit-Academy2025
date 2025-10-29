using Polymorphism.Animal;
using Polymorphism.Career;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Profession artist = new Artist() { Name = "Artist" };
            //Profession developer = new Developer("Billy", 1500, "Backend developer");
            //Profession profession= new Profession() { Name = "Profession" };

            //artist.StartWork();
            //developer.StartWork();
            //profession.StartWork();
            //Console.WriteLine(nameof(Developer));

            IAnimal animal1 = new Cat() { Name = "Kara" };
            IAnimal animal2 = new Dog() { Name = "Puffa" };

            animal1.MakeNoise();
            Console.WriteLine("My name is: " + animal1.Name);
            animal2.MakeNoise();
            Console.WriteLine("My name is: " + animal2.Name);

        }
    }
}
