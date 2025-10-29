namespace Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lockedClass = new LockedClass();
            string message = lockedClass.GetCustomMessage("ciao!");
            Console.WriteLine(message);

            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine($"Is Valid email result: {email?.IsValidEmailv2()}");
        }
    }
}
