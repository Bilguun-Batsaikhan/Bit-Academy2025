
class Car
{
    public string Brand { get; set; } = string.Empty;
    public int Year { get; set; }
}
record Point(int X, int Y);
record Student(string Name, int Age, double GPA);
abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;
record Triangle(double Base, double Height) : Shape;

class Program
{
    // Type check
    // -------------------------------------------
    // Write a method DescribeValue(object o) that:
    // Prints "int value" if o is an int
    // Prints "string value" if o is a string
    // Prints "something else" otherwise
    static string DescribeValue(object o) => o switch
    {
        int x => "int value",
        string x => "string value",
        _ => "something else"
    };
    // Constant match
    // -------------------------------------------
    // Write a method IsWeekend(string day) that:
    // Returns true if day is "Saturday" or "Sunday"
    // Returns false otherwise
    static bool IsWeekend(string day) => day switch
    {
        "Saturday" or "Sunday" => true,
        _ => false
    };
    // Relational pattern
    // Write a method CheckTemperature(int temp) that:
    // Prints "freezing" if temp < 0
    // Prints "cold" if temp between 0 and 15
    // Prints "warm" if temp between 16 and 30
    // Prints "hot" if temp > 30
    static string CheckTemperature(int temp) => temp switch
    {
        < 0 => "freezing",
        <= 15 => "cold",
        <= 30 => "warm",
        _ => "hot",
    };
    // Switch expression with types
    // Create a method GetLength(object o) that:
    // Returns length if o is a string
    // Returns array length if o is an int[]
    // Returns -1 otherwise
    static int GetLength(object o) => o switch
    {
        string x => x.Length,
        int[] x => x.Length,
        _ => -1
    };
    // Write a method ClassifyCar(Car car) that:
    // Returns "classic" if Year < 1990
    // Returns "modern" if Year >= 1990 and Brand is "Tesla"
    // Returns "other" otherwise
    static string ClassifyCar(Car car) => car switch
    {
        { Year: < 1990 } => "classic",
        { Year: >= 1990, Brand: "Tesla" } => "modern",
        _ => "other"

    };
    // Tuple pattern
    // Write a method DescribePoint((int x, int y) p) that:
    // Returns "origin" if both are 0
    // Returns "x-axis" if y == 0
    // Returns "y-axis" if x == 0
    // Returns "quadrant" otherwise
    static string DescribePoint((int x, int y) p) => (p.x, p.y) switch
    {
        (0, 0) => "origin",
        (_, 0) => "x-axis",
        (0, _) => "y-axis",
        (_, _) => "quadrant"
    };
    // Record pattern
    // Write a method WhereIs(Point p) that:
    // Returns "origin" if at (0,0)
    // Returns "on X-axis" if Y == 0 but X ≠ 0
    // Returns "on Y-axis" if X == 0 but Y ≠ 0
    // Returns "elsewhere" otherwise
    static string WhereIs(Point p) => p switch
    {
        (0, 0) => "origin",
        (_, 0) => "x-axis",
        (0, _) => "y-axis",
        (_, _) => "quadrant"
    };

    // List patterns
    // Write a method CheckList(int[] arr) that:
    // Returns "empty" if array has no elements
    // Returns "single" if array has exactly 1 element
    // Returns "starts with 1,2" if array begins with [1,2,...]
    // Returns "other" otherwise
    static string CheckList(int[] arr) => arr switch
    {
        [] => "empty",
        [_] => "single",
        [1, 2, ..] => "starts with 1,2",
        _ => "other"
    };

    // Write a method DescribeShape(Shape s) that:
    // Returns "big circle" if Circle with Radius >= 5
    // Returns "square" if Rectangle where Width == Height
    // Returns "triangle" if Triangle with Height > Base
    // Returns "unknown shape" otherwise
    static string DescribeShape(Shape s) => s switch
    {
        Circle { Radius: >= 5 } => "big circle",
        Rectangle r when r.Width == r.Height => "square",
        Triangle { Height: var h, Base: var b } when h > b => "triangle",
        _ => "unknown shape"
    };
    // Write a method ClassifyStudent(Student s) that:
    // Returns "honor student" if GPA >= 3.5 and Age < 25
    // Returns "senior student" if Age >= 25
    // Returns "average student" otherwise
    static string ClassifyStudent(Student s) => s switch
    {
        (_, < 25, >= 3.5) => "honor student",
        (_, > 24, _) => "senior student",
        _ => "average student"
    };
    static void Main(string[] args)
    {
        System.Console.WriteLine(DescribeValue("A"));
        System.Console.WriteLine(DescribeValue(1));
        System.Console.WriteLine(DescribeValue('c'));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(IsWeekend("Saturday"));
        System.Console.WriteLine(IsWeekend("Sunday"));
        System.Console.WriteLine(IsWeekend("Monday"));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(CheckTemperature(30));
        System.Console.WriteLine(CheckTemperature(31));
        System.Console.WriteLine(CheckTemperature(5));
        System.Console.WriteLine(CheckTemperature(-1));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(GetLength("Bilguun"));
        System.Console.WriteLine(GetLength(new int[] { 1, 2, 3, 4, 5 }));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(ClassifyCar(new Car() { Brand = "Toyota", Year = 1989 }));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(DescribePoint((0, 0)));
        System.Console.WriteLine(DescribePoint((1, 0)));
        System.Console.WriteLine(DescribePoint((0, 2)));
        System.Console.WriteLine(DescribePoint((1, 2)));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(WhereIs(new Point(0, 0)));
        System.Console.WriteLine(WhereIs(new Point(1, 0)));
        System.Console.WriteLine(WhereIs(new Point(0, 2)));
        System.Console.WriteLine(WhereIs(new Point(1, 2)));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(CheckList([]));
        System.Console.WriteLine(CheckList([5]));
        System.Console.WriteLine(CheckList([1, 2, 3]));
        System.Console.WriteLine(CheckList([3, 4, 5]));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(DescribeShape(new Circle(6)));
        System.Console.WriteLine(DescribeShape(new Rectangle(4, 4)));
        System.Console.WriteLine(DescribeShape(new Triangle(3, 5)));
        System.Console.WriteLine(DescribeShape(new Circle(3)));
        System.Console.WriteLine("----------------");
        System.Console.WriteLine(ClassifyStudent(new Student("Alice", 22, 3.8)));
        System.Console.WriteLine(ClassifyStudent(new Student("Bob", 26, 3.0)));
        System.Console.WriteLine(ClassifyStudent(new Student("Charlie", 24, 2.5)));

    }
}