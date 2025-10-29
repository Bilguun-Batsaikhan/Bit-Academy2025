using Polymorphism.Classes;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            var dog = new Dog();

            cat.MakeSound();
            dog.MakeSound();
        }
    }
}
