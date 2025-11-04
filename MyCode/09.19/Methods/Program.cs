class Program
{
    static void Main(string[] args)
    {
        // Passing an array to a method by copy of reference
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original array: " + string.Join(", ", numbers));
        SquareArray(numbers);
        Console.WriteLine("Array after method call: " + string.Join(", ", numbers));
        // Passing an array to a method by reference
        int[] moreNumbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original array: " + string.Join(", ", moreNumbers));
        SquareArray(ref moreNumbers);
        Console.WriteLine("Array after method call: " + string.Join(", ", moreNumbers));

    }

    static void SquareArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i] * arr[i];
        }
        int[] newArr = { 10, 20, 30 };
        arr = newArr; // This change won't affect the original array reference, because arr is a copy of the reference
    }

    static void SquareArray(ref int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i] * arr[i];
        }
        int[] newArr = { 10, 20, 30 };
        arr = newArr; // This change will affect the original array reference, because arr is passed by reference
    }
}
