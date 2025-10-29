using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class CustomExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidEmailv2(this string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public static string GetCustomMessage(this LockedClass locked, string message)
        {
            return $"{locked.GetMessage()}-{message}";
        }
    }
}
