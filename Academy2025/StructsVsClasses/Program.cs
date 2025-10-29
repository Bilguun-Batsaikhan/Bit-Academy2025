using System.Reflection;
using Utils;

namespace StructsVsClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);
            Console.WriteLine(ClassUtils.GetName());
            Console.WriteLine(StructUtils.GetName());

            var structObj = new StructUtils();
            var classObj = new ClassUtils();

            ChangeVersion(structObj);
            ChangeVersion(classObj);

            Console.WriteLine(structObj.Version);
            Console.WriteLine(classObj.Version);
            Console.WriteLine(classObj.GetAppInfo());

            var classUnion = new ClassUnion();
        }

        static void ChangeVersion(StructUtils obj)
        {
            obj.Version = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
        }

        static void ChangeVersion(ClassUtils obj)
        {
            obj.Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }
    }
}
