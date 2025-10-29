namespace BoxingAndUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // boxing example
            int num = 123;
            object obj = num;

            // unboxing example
            obj = 321;
            num = (int)obj;
        }
    }
}
