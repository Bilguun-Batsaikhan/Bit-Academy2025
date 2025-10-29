using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal static class Extension
    {
        public static bool isValidEmail(this string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
