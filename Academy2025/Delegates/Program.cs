namespace Delegates
{
    public delegate void PrintMessageDelegate(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMessageDelegate delegateInstance = new PrintMessageDelegate(PrintMessage);
            //PrintMessageDelegate delegateInstance2 = new PrintMessageDelegate(message => Console.WriteLine(message));
            delegateInstance("Hello!");
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
