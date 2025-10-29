namespace DisposableObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection gets disposed when the using statement scope ends.
            var connection1 = new Connection("127.0.0.1");
            using (connection1)
            {
                Console.WriteLine("the connection is open...");
            }

            // Connection gets disposed when the method finishes
            using var connection2 = new Connection("127.0.0.1");
            Console.WriteLine("the connection is open...");
        }
    }
}
