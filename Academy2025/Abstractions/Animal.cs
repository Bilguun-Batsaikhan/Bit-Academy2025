namespace Abstractions
{
    public abstract class Animal
    {
        public abstract void MakeSound();

        public void Sleep()
        {
            Console.WriteLine("zzzzzzzz");
        }
    }
}
