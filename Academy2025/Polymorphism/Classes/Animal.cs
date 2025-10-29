namespace Polymorphism.Classes
{
    public class Animal
    {
        protected readonly string name;

        public Animal(string name = "default")
        {
            this.name = name;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }
}
