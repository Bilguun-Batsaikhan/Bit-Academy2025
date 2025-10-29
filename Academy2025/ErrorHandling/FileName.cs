namespace ErrorHandling
{
    public interface IFileName
    {
        void Write();
        void Write(string value);
        byte[] Read();
    }

    public class FileName : IFileName
    {
        public byte[] Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            //throw new NotImplementedException();

            //try
            //{
            //    int n = 10;
            //    int x = n.Division(0);
            //    Console.WriteLine(x);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            throw new InvalidOperationException("Ooopps! Something went wrong!");
        }

        public void Write(string value)
        {
            throw new NotImplementedException();
        }
    }
}
