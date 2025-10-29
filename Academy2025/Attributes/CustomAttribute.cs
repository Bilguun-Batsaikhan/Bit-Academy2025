namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class CustomAttribute(string name) : Attribute
    {
        private readonly string _name = name;
        public string? Version { get; set; }
    }
}
