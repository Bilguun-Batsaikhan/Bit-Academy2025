namespace Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CustomExtensions.IsValidEmail("bilguun.ing@gmail.com"));
            Console.WriteLine(CustomExtensions.IsValidEmail("not a valid email"));
            //string? email = Console.ReadLine();
            //Console.WriteLine(email?.IsValidEmail());
            LockedClass lc = new();
            lc.SayHello("Bilguun");
            lc.SayBye("Bilguun");
            List<int> numbers = new List<int>() { 1, 2 ,3 ,4};
            Console.WriteLine(numbers.CountEven());
        }
    }
}
