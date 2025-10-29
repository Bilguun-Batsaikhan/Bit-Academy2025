namespace Polymorphism.Classes
{
    public class Cat : Animal
    {
        public Cat() : base(nameof(Cat))
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("The cat says: Meow!");
        }
    }
}
