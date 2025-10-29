using System.Reflection;

namespace Utils
{
    public struct StructUtils
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public string? culture;

        private readonly int _myVar;
        public readonly int MyProperty
        {
            get { return _myVar; }
        }

        public StructUtils()
        {
            _myVar = 1000;
        }

        public static string? GetName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        public override readonly string ToString()
        {
            return $"{Name}-{Version}-{culture}";
        }
    }
}
