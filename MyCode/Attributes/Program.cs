namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() { Name = "Test", Surname = "Test1", Description = "", Email = "aa" };
            Console.WriteLine((person.Email.isValidEmail() ? "The email is valid!" : "The email is not valid"));
        }
    }
}
