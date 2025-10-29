using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    public static class Extensions
    {
        public static bool IsValidEmail(this string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
