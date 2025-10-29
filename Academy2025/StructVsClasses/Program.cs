using System;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;
using Utils;

namespace StructVsClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClassUtils.GetName());
            Console.WriteLine(StructUtils.GetName());
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);

            var s = new StructUtils();
            var c = new ClassUtils();

            ChangeVersion(s);
            ChangeVersion(c);

            Console.WriteLine(s.Version);
            Console.WriteLine(c.Version);
        }

        //Structs are value types: Passing a StructUtils to ChangeVersion copies the struct. Changes to s.Version inside the method do not affect the original struct in Main.
        static void ChangeVersion(StructUtils s)
        {
            s.Version = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
        }
        static void ChangeVersion(ClassUtils s)
        {
            s.Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }
        // • Assembly.GetExecutingAssembly(): Gets a reference to the assembly (DLL or EXE) that contains the currently executing code.
        // • .GetName(): Gets the assembly’s metadata, including its name and version.
        // • .Version: Gets the version information (as a Version? object) from the assembly metadata.
        // • !: The null-forgiving operator, telling the compiler you are sure Version is not null.
        // • .ToString(): Converts the Version object to its string representation (e.g., "1.0.0.0").
    }
}
