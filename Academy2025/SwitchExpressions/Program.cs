namespace SwitchExpressions
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum Orientation
    {
        North,
        South,
        East,
        West
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToOrientation(Direction.Left));
        }

        static Orientation ToOrientation(string direction) => direction switch
        {
            "up" => Orientation.North,
            "right" => Orientation.East,
            "down" => Orientation.South,
            "left" => Orientation.West,
            _ => throw new NotImplementedException()
        };

        static Orientation ToOrientation(Direction direction) => direction switch
        {
            Direction.Up => Orientation.North,
            Direction.Right => Orientation.East,
            Direction.Down => Orientation.South,
            Direction.Left => Orientation.West,
            _ => throw new NotImplementedException()
        };
    }
}
