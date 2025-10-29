namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "John",
                Surname = "Doe",
                Description = "this is a description of the object Person",
                Email = "mail@mail.com"
            };

            Console.WriteLine(person.Email.IsValidEmail() ? "The email is valid!" : "The email is not valid!");
            //var not = person.Email.IsValidEmail() ? string.Empty : " not";
            //Console.WriteLine($"The email is{not} valid!");

            person.SetValues("", "", email: "test");
            person.SetValues("", "", "test_desc", "test_email");
        }
    }
}
