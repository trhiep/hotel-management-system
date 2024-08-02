using HotelManagementSystem.Models.Entities;
using System.Text;

namespace HotelManagementSystem.Utils
{
    public class OTPHelper
    {
        public static string GenerateOTP()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var stringBuilder = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }
        public static bool IsValidOTP(string enteredOTP, ResetPasswordOtp generatedOTP)
        {
            return enteredOTP.Equals(generatedOTP.Otpstring);
        }

    }
}
