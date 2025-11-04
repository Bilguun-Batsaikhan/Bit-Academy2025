using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace Delegates__Generics__Exception_Handling
{
    internal class Program
    {
        //Basic Delegate (1)
        //Create a delegate MathOperation that takes two integers and returns an integer.
        //Implement methods Add, Subtract, Multiply, and Divide.
        //Use the delegate to call these methods dynamically.
        public delegate int MathOperation(int x, int y);
        //-------------------------------------------------------------------------------------
        //Multicast Delegate (2)
        //Create a delegate that prints a message.
        //Subscribe multiple methods (PrintHello, PrintDate, PrintRandomNumber) to the same delegate.
        //Show how you can remove one method from invocation.
        //-------------------------------------------------------------------------------------
        public delegate void PrintMethods();
        //Anonymous Method & Lambda (3)
        //Write a delegate that checks if a string is valid (not null/empty).
        //Assign both an anonymous method and a lambda expression to it.
        //-------------------------------------------------------------------------------------
        public delegate bool IsStringValid(string str);
        //Generic Method (4)
        //Write a method Swap<T>(ref T a, ref T b) that swaps two values of any type.
        //Test with int, string, and a custom class.
        //-------------------------------------------------------------------------------------
        public static void Swapt<T>(ref T a, ref T b) where T : struct
        {
            var temp = a;
            a = b;
            b = temp;
        }
        //Generic Class (5)
        //Create a generic class Box<T> with methods:
        //SetValue(T value)
        //GetValue()
        //Show how it works with int, string, and DateTime.
        //-------------------------------------------------------------------------------------
        //Generic Constraint (6)
        //Create a generic method PrintIfComparable<T>(T a, T b) where T : IComparable<T>.
        //Print which value is greater.
        //Try it with int, double, and string.
        //-------------------------------------------------------------------------------------
        public static T PrintIfComparable<T>(T a, T b) where T : IComparable<T>
        {
            // CompareTo method returns values: (1) if a > b, (0) if a == b, (-1) otherwise.
            return a.CompareTo(b) > 0 ? a : b;
        }
        //Basic Exception (7)
        //Write a method that divides two numbers.
        //If denominator = 0, catch the exception and print a custom message.
        //-------------------------------------------------------------------------------------
        public static int DivideTwoInts(int a, int b) => a / b;
        //Custom Exception (8)
        //Create a custom exception NegativeNumberException.
        //Write a method CalculateSquareRoot(int number) that throws this exception if the number is negative.
        //Catch and handle it gracefully.
        //-------------------------------------------------------------------------------------
        public static double CalculateSquareRoot(int number)
        {
            if(number < 0) throw new NativeNumberException() { CustomMessage = "What are you? Dumb?"};
            return Math.Sqrt(number);
        }
        //Finally Block (9)
        //Simulate reading a file(use StreamReader or just fake it).
        //Ensure that in a finally block, resources are closed/disposed.
        static void Main(string[] args)
        {
            #region Basic Delegate
            MathOperation a = Add;
            MathOperation s = Substract;
            MathOperation m = Multiply;
            MathOperation d = Divide;

            List<MathOperation> mathOperations = new List<MathOperation>();
            mathOperations.Add(a);
            mathOperations.Add(s);
            mathOperations.Add(m);
            mathOperations.Add(d);

            foreach (MathOperation op in mathOperations)
            {
                Console.WriteLine($"Operation [4 | 2] {op.GetMethodInfo()}, {op(4, 2)}");
            }
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region MultiCast Delegate
            PrintMethods printMethods = PrintDate;
            printMethods += PrintHello;
            printMethods += PrintRandomNumber;
            printMethods();
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Anonymous Method & Lambda
            IsStringValid stringValid = (str) => str.Length > 0;
            Console.WriteLine(stringValid("Hello"));
            Console.WriteLine(stringValid(""));
            // Anonymous methods in C# can be defined using the delegate
            IsStringValid stringValid1 = delegate (string str) { return str != null; };
            Console.WriteLine(stringValid1("Goodbye"));
            Console.WriteLine(stringValid1(null));
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Generic Method
            // The following swaps all work, because Structs are ref type, appearently same goes for primitive types as well
            int firstInt = 1;
            int secondInt = 2;
            Swapt(ref firstInt, ref secondInt);
            Console.WriteLine($"First Int: {firstInt}, Second Int: {secondInt}");
            Fish firstFish = new Fish() { Name = "GluGlu" };
            Fish secondFish = new Fish() { Name = "Blob" };
            Swapt(ref firstFish, ref secondFish);
            firstFish.SayHello();
            secondFish.SayHello();
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Generic Class
            Box<int> box = new Box<int>();
            box.SetValue(1);
            Console.WriteLine($"Int Box value is: {box.GetValue()}");
            Box<DateTime> box2 = new Box<DateTime>();
            box2.SetValue(new DateTime());
            Console.WriteLine($"DateTime Box value is: {box2.GetValue()}");
            Box<string> box3 = new Box<string>();
            box3.SetValue("Hello");
            Console.WriteLine($"String Box value is: {box3.GetValue()}");
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Generic Constraints
            //P.S you can also pass your own custom class that implements IComparable interface
            Console.WriteLine(PrintIfComparable(1, 2)); // prints 2
            Console.WriteLine(PrintIfComparable("Apple", "Banana"));
            Console.WriteLine(PrintIfComparable(5.5, 7.2)); // prints 7.2
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Basic Exception
            try
            {
                Console.WriteLine(DivideTwoInts(1, 0));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Seriously bro?");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            } finally
            {
                Console.WriteLine("End of exception");
            }
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Custom Exception
            try
            {
                CalculateSquareRoot(-1);
            }
            catch (NativeNumberException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("-------------------------------------------------------");
            #endregion
            #region Finally Block
            // Finally is mostly used for closing resources. Because finally block is "ALWAYS" executed.
            #endregion
        }
        // (1)
        public static int Add(int x, int y) => x + y;
        public static int Substract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
        public static int Divide(int x, int y) => x / y;
        // (2)
        public static void PrintHello() => Console.WriteLine("Hello");
        public static void PrintDate() => Console.WriteLine(DateTime.Now);
        public static void PrintRandomNumber() => Console.WriteLine(RandomNumberGenerator.GetInt32(100));
    }
}
