namespace Generics
{
    public interface IMyInterface { }

    public class MyDictionary<TKey, TVal>
        where TKey : IComparable<TKey>
        where TVal : IMyInterface
    {
        public void Add(TKey key, TVal value)
        {
            
        }
    }
}
