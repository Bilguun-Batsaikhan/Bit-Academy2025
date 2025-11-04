namespace Sorting
{
    internal class Program
    {
        static void Main()
        {
            int[] randomNumbers = GenerateRandomIntArray(10, 1, 100); // 10 numbers between 1 and 100

            Console.WriteLine("Random integers:");
            foreach (int num in randomNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Sorted");
            SelectSort(randomNumbers);
            foreach (int num in randomNumbers)
            {
                Console.Write(num + " ");
            }
        }

        static int[] GenerateRandomIntArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max + 1); // max is exclusive, so add 1
            }

            return array;
        }
        static void BubbleSort(int[] array)
        {
            bool isSwapped;
            do
            {
                isSwapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        isSwapped = true;
                        Swap(i, i + 1, array);
                    }
                }
            } while (isSwapped);
        }
        static void SelectSort(int[] array)
        {
            int min;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }   
                }
                if (min != i)
                {
                    Swap(i, min, array);
                }
            }
        }
        static void Swap(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
