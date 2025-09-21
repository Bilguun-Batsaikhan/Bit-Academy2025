using System.Text;

namespace FirstApp
{
    internal class Program
    {
        /// <summary>
        /// App entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region App region

            /*string? value = "Ciao, Marian!";
            char myC = 'a';
            char[] name = ['M', 'A', 'R'];
            int? num = 30;
            //num = num + 10;
            num += 10; // num = num + 10;

            // Prints "hello world" to the console
            Console.WriteLine(value);
            Console.WriteLine(num);
            Console.WriteLine(name);

            string? myVal = Console.ReadLine();
            Console.WriteLine("My value is: " + myVal);
            Console.WriteLine(new string(myVal.Concat("asdhadhak").ToArray()));
            Console.WriteLine(string.Concat(myVal, "Marian"));
            Console.WriteLine($"{myVal} Marian");

            #region StringBuilder

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Hello ");
            builder.Append("John");
            builder.Append(" Doe");
            builder.Append(Environment.NewLine);
            builder.AppendLine("Ciao!");

            Console.WriteLine(builder.ToString());

            #endregion

            var name = Console.ReadLine();
            var cognome = Console.ReadLine();
            string emailTemplate = string.Format("Hello, {0}-{1}. This is an automated message.", name, cognome);
            Console.WriteLine(emailTemplate);

            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString("yyyyMMdd"));
            Console.WriteLine(string.Format("{0:dd-MM-yyy}", dt));
            Console.WriteLine(string.Format("{0}", dt.ToString("ddMMyyyy")));*/

            int num = 299;
            double price = (int)num;
            price = double.Parse(num.ToString());
            Console.WriteLine(price);

            #endregion
        }
    }
}
