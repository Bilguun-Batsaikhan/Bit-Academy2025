using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMakerV2
{
    internal static class CustomExtension
    {
        public static bool StringToBool(this string str)
        {
            bool.TryParse(str, out bool result);
            return result;
        }
    }
}
