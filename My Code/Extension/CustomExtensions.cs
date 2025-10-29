using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extension
{
    // Extensions needs to be inside a static class, they are feature that lets you "add" new methods to existing types without modifying their source code or creating a new derived type. 
    public static class CustomExtensions
    {
        // The first parameter specifies the type the method operates on, and is preceded by the this keyword.
        // When called, they appear as if they are instance methods of the extended type.
        public static bool IsValidEmail(this string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }
        // The keyword "this" is a reference to the current object that is being extended. In this case LockedClass instance.
        public static void SayBye(this LockedClass lockedClass, string name)
        {
            Console.WriteLine($"Bye {name}");
        }
        public static int CountEven(this List<int> nums)
        {
            return nums.Count(x => x % 2 == 0);
        }
    }
}
