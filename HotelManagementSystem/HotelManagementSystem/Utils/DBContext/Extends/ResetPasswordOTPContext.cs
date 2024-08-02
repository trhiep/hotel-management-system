using HotelManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Utils.DBContext.Extends
{
    public class ResetPasswordOTPContext : HMS_DBContext
    {
        public ResetPasswordOTPContext(DbContextOptions<HMS_DBContext> options) : base(options) { }
        public DbSet<ResetPasswordOtp> ResetPasswordOtps { get; set; } = null!;

        public void AddNewOTP(ResetPasswordOtp OTP)
        {
            List<ResetPasswordOtp> oldOTPs = ResetPasswordOtps.Where(x => x.AccountId == OTP.AccountId).ToList();
            foreach (var item in oldOTPs)
            {
                item.IsUsed = true;
                ResetPasswordOtps.Update(item);
            }
            ResetPasswordOtps.Add(OTP);
        }

        public bool IsValidOTP (int accountId, string enteredOtp)
        {
            ResetPasswordOtp generatedOtp = ResetPasswordOtps.FirstOrDefault(x => x.AccountId == accountId && x.IsUsed == false);
            return generatedOtp.Otpstring.Equals(enteredOtp);
        }
    }
}
