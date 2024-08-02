using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace HotelManagementSystem.Utils
{
    public class RegexHelper
    {
        public static readonly string PasswordRegex = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public static bool IsValidPasswordFormat(string password)
        {
            return Regex.IsMatch(password, PasswordRegex);
        }
    }
}
