namespace Generics
{
    public class Box<T> where T : class, new()
    {
        private T? _value;

        public void Set(T value)
        {
            _value = value;
        }

        public T? Get()
        {
            return _value;
        }

        //public static T CreateTypeInstance()
        //{
        //    return new T();
        //}
    }
}
