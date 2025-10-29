namespace ErrorHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = new FileName();
                fileName.Write();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("App is still running...");
        }
    }
}
