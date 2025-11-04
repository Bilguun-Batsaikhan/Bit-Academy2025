using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates__Generics__Exception_Handling
{
    internal class NativeNumberException : Exception
    {
        public required string CustomMessage { get; set; }
        public NativeNumberException() { }
        public NativeNumberException(string message) : base(message) { }
        public override string Message { get { return CustomMessage; } }
    }
}
