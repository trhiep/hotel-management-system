using HotelManagementSystem.Errors;
using HotelManagementSystem.Models.DTOs;
using HotelManagementSystem.Utils.DBContext.Extends;
using HotelManagementSystem.Utils;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Runtime.CompilerServices;
using HotelManagementSystem.Models.Entities;
using HotelManagementSystem.Logs;

namespace HotelManagementSystem.Controllers.Account
{
    public class ForgotPasswordController : PageModel
    {
        private AccountContext _accountContext;
        private ResetPasswordOTPContext _resetPasswordOTPContext;
        private static readonly ILog log = LogManager.GetLogger(typeof(ForgotPasswordController));

        public ForgotPasswordController(AccountContext accountContext, ResetPasswordOTPContext resetPasswordOTPContext)
        {
            _accountContext = accountContext;
            _resetPasswordOTPContext = resetPasswordOTPContext;
            LoggerConfig.Configure();
        }

        public IActionResult OnGet()
        {
            var LogedInAccountJson = HttpContext.Session.GetString("LogedInAccount");

            if (LogedInAccountJson != null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostFindAccount()
        {
            string enteredEmail = Request.Form["email"];
            HotelManagementSystem.Models.Entities.Account foundAccount = _accountContext.FindAccountByEmail(enteredEmail);
            if (foundAccount != null)
            {
                string generatedOTP = OTPHelper.GenerateOTP();
                ResetPasswordOtp newResetPasswordOtp = new ResetPasswordOtp()
                {
                    Otpid = 0,
                    AccountId = foundAccount.AccountId,
                    Otpstring = generatedOTP,
                    GeneratedTime = DateTime.Now,
                    IsUsed = false
                };
                _resetPasswordOTPContext.AddNewOTP(newResetPasswordOtp);
                _resetPasswordOTPContext.SaveChanges();

                Thread t = new Thread(() => EmailSender.SendEmailMultiThread(generatedOTP, foundAccount.Email));
                t.Start();

                SessionHelper.SaveSession(foundAccount, HttpContext, "RequestingAccount");

                log.Info("Generate for account " + foundAccount.Username + " successfully.");
                ViewData["Step"] = "VerifyOTP";
            }
            else
            {
                ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.WrongAccountEmail);
                ViewData["Email"] = enteredEmail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostVerifyOTP()
        {
            string enteredOTP = Request.Form["otp"];
            HotelManagementSystem.Models.Entities.Account RequestingAccount = SessionHelper.GetAccountFromSession(HttpContext, "RequestingAccount");
            if (RequestingAccount != null){

                if (_resetPasswordOTPContext.IsValidOTP(RequestingAccount.AccountId, enteredOTP))
                {
                        ViewData["Step"] = "ChangePassword";
                }
                else
                {
                    ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.WrongOTP);
                    ViewData["Step"] = "VerifyOTP";
                    log.Info("Account " + RequestingAccount.Username + " enter wrong OTP.");
                }

            }
            else
            {
                ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.Timeout);
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostChangePassword()
        {
            string newPassword = Request.Form["password"];
            string confirmPassword = Request.Form["confirmPassword"];

            if (newPassword.Equals(confirmPassword))
            {
                if (RegexHelper.IsValidPasswordFormat(newPassword))
                {
                    HotelManagementSystem.Models.Entities.Account RequestingAccount = SessionHelper.GetAccountFromSession(HttpContext, "RequestingAccount");
                    if (RequestingAccount != null)
                    {
                        RequestingAccount.Password = HMSEncryptor.GetHashedPassword(newPassword);
                        _accountContext.UpdateAccount(RequestingAccount);
                        _accountContext.SaveChanges();

                        log.Info("Account " + RequestingAccount.Username + " set new password successfully.");
                        return RedirectToPage("/Accounts/Login");
                    }
                    else
                    {
                        ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.Timeout);
                    }

                }
                else
                {
                    ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.InvalidPasswordFormat);
                }

            }
            else
            {
                ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.ConfirmPasswordDoesNotMatches);
            }

            ViewData["Step"] = "ChangePassword";
            return Page();
        }


    }
}
