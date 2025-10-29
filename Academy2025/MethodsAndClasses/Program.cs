using MethodsAndClasses.Classes;
using MethodsAndClasses.Utils;

namespace MethodsAndClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Methods

            int a = 1;
            int b = 2;
            int val1 = Sum(a, b);
            int val2 = Sum(5);

            Print(val1);
            Print(val2);
            Print(val1, "this is my string!");

            int value = 1;
            ChangeValue(ref value);
            Console.WriteLine($"my value is: {value}");

            ChangeValueOut(out int valueOut);
            Console.WriteLine($"my out value is: {valueOut}");

            int[] array = { 10, 5, 3, 1, 2 };
            Helpers.Sort(array);

            #endregion

            #region Classes

            Car fiat = new();
            fiat.ChangeName("Fiat");
            Console.WriteLine(fiat.GetName());

            Car bmw = new("BMW", "Black", 4);
            Console.WriteLine(bmw.GetColor());
            Car bmw_clone = new("BMW", "Black", 4);

            if (bmw == bmw_clone)
            {
                Console.WriteLine("the cars are equal");
            }

            Console.WriteLine(bmw);

            object obj = new { Name = "John", Surname = "Doe", Date = DateTime.Now };
            Helpers.PrintCar(obj);

            #endregion
        }

        public static int Sum(int x, int y = 10)
        {
            return x + y;
        }

        private static void Print(int value)
        {
            Console.WriteLine(value);
        }

        private static void Print(int value, string str)
        {
            Console.WriteLine($"{value}-{str}");
        }

        static void ChangeValue(ref int value)
        {
            value = 10;
        }

        static void ChangeValueOut(out int value)
        {
            value = 333;
        }
    }
}
