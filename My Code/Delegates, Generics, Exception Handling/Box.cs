using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates__Generics__Exception_Handling
{
    internal class Box<T>
    {
        private T value;
        // I don't have to put SetValue<T>, because class itself has a generic declaration.
        public void SetValue(T value)
        {
            this.value = value;
        }
        public T GetValue() => value;
    }
}
