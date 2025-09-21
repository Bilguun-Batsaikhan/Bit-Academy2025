namespace ControlStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array sorting

            //int[] numbers = new int[] { 101, 222, 35, 100 };
            //List<int> numberList = new List<int>() { 20, 1, 4 };
            //numberList.Sort();

            //Array.Sort(numbers);

            //char[] chars = new char[] { 'j', 'm', 'p' };
            //Array.Sort(chars);

            //Console.WriteLine((byte)chars[0]);

            #endregion

            #region If and switch statement

            //bool result = true;
            int num = default;

            //string message = num == 0 ? "Ciao!" : "Hello!";
            //Console.WriteLine(message);

            if (num == 0)
            {
                Console.WriteLine("Hello, World!");
                num = 2;
            }
            else
            {
                Console.WriteLine("Result is true!");
            }

            Console.WriteLine(num);

            switch (num)
            {
                case 0:
                    Console.WriteLine($"the value is {num}");
                    break;
                case 1:
                case 2:
                    Console.WriteLine("the value is 1 or 2");
                    break;
                case 1000:
                    Console.WriteLine("the value is 100");
                    break;
                default:
                    Console.WriteLine("no case found");
                    break;
            }

            #endregion

            #region Loops

            //bool isRunning = true;
            //while (isRunning)
            //{
            //    Console.WriteLine("loop...");
            //    isRunning = false;
            //}

            //do 
            //{
            //    Console.WriteLine("do while...");
            //    isRunning = false;
            //}
            //while (isRunning);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i + 1);
            //}

            //string[] cars = new string[] { "Fiat", "BMW", "Audi", "VW" };

            //for (int i = 0; i < cars.Length; i++)
            //{
            //    Console.WriteLine(cars[i]);
            //}

            List<string> cars = ["Fiat", "BMW", "Audi", "VW"];
            //foreach (var item in cars)
            //{
            //    Console.WriteLine(item);
            //}

            //int index = 0;
            //while (index < cars.Count)
            //{
            //    index++;
            //    if (index == 1)
            //        continue;

            //    Console.WriteLine(cars[index]);
            //}

            for (int i = 0; i < cars.Count; i++)
            {
                if (i == 0)
                    continue;

                Console.WriteLine(cars[i]);
            }

            int n = Convert.ToInt32(Console.ReadLine());

            #endregion
        }
    }
}
