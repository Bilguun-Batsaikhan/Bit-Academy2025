using MethodsAndClasses.Classes;

namespace MethodsAndClasses.Utils
{
    public class Helpers
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void PrintCar(object? obj)
        {
            if (obj is Car)
            {
                Console.WriteLine(obj.ToString());
            }
            else
            {
                Console.WriteLine("The object is not of type Car");
            }
        }
    }
}
