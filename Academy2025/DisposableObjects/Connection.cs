namespace DisposableObjects
{
    public class Connection : IDisposable
    {
        private string? _ip;

        public Connection(string ip)
        {
            _ip = ip;
        }

        public void Dispose()
        {
            _ip = null;
            Console.WriteLine("resources freed!");
        }
    }
}
