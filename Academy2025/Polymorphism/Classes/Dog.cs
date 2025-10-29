namespace Polymorphism.Classes
{
    public class Dog : Animal
    {
        public Dog() : base(nameof(Dog)) { }

        public override void MakeSound()
        {
            //base.MakeSound();
            Console.WriteLine("The dog says: Woof!");
        }
    }
}
