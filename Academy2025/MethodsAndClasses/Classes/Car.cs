namespace MethodsAndClasses.Classes
{
    public class Car
    {
        string? _name;
        string? _color;
        int? _width;

        public Car()
        {

        }

        ~Car()
        {
            _name = null;
            _color = null;
            _width = null;
        }

        public Car(string name, string color, int width)
        {
            _name = name;
            _color = color;
            _width = width;
        }

        public void ChangeColor(string color)
        {
            _color = color;
        }

        public string? GetColor()
        {
            return _color;
        }

        public void ChangeName(string name)
        {
            _name = name;
        }

        public string? GetName()
        {
            return _name;
        }

        public void ChangeWidth(int width)
        {
            _width = width;
        }

        public int? GetWidth()
        {
            return _width;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? other)
        {
            if (other == null || this.GetType() != other.GetType())
                return false;

            Car car = (Car)other;

            return _name == car.GetName() && _color == car.GetColor();
        }

        public override string ToString()
        {
            return $"{_name}-{_color}-{_width}";
        }

        public static bool operator ==(Car a, Car b)
        {
            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Car a, Car b)
        {
            return !(a == b);
        }
    }
}
