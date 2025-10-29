using System.Reflection;

namespace Utils
{
    public class ClassUtils
    {
        public string? Version { get; set; }

        public StructUtils GetAppInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var structUtils = new StructUtils()
            {
                Version = assembly.GetName().Version!.ToString(),
                Name = assembly.GetName().Name ?? string.Empty,
                culture = !string.IsNullOrEmpty(assembly.GetName().CultureName) ? assembly.GetName().CultureName : "undefined culture"
            };

            return structUtils;
        }

        public static string? GetName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
