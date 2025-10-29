namespace ErrorHandling
{
    public static class Extensions
    {
        public static int Division(this int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
