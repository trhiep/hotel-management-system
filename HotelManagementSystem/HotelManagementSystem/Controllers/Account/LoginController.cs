using HotelManagementSystem.Errors;
using HotelManagementSystem.Logs;
using HotelManagementSystem.Models.DTOs;
using HotelManagementSystem.Models.Entities;
using HotelManagementSystem.Utils;
using HotelManagementSystem.Utils.DBContext.Extends;
using HotelManagementSystem.Utils.ModelMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HotelManagementSystem.Controllers.Account
{
    public class LoginController : PageModel
    {
        AccountContext _accountContext;
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginController));

        public LoginController(AccountContext accountContext)
        {
            _accountContext = accountContext;
            LoggerConfig.Configure();
        }

        public IActionResult OnGet()
        {
            var LogedInAccount = SessionHelper.GetAccountFromSession(HttpContext, "LogedInAccount");
            if (LogedInAccount != null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            AccountDTO enteredAccount = new AccountDTO()
            {
                Username = Request.Form["username"],
                Password = Request.Form["password"]
            };

            HotelManagementSystem.Models.Entities.Account foundAccount = _accountContext.FindAccountByUsername(enteredAccount.Username);
            if (foundAccount != null)
            {
                if (foundAccount.IsEnable)
                {
                    string hashedPassword = HMSEncryptor.GetHashedPassword(enteredAccount.Password);
                    if (hashedPassword.Equals(foundAccount.Password))
                    {
                        log.Info("Successfully login for account: " + foundAccount.Username);
                        SessionHelper.SaveSession(foundAccount, HttpContext, "LogedInAccount");
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.WrongPassword);
                        log.Info("Account entered wrong password: " + foundAccount.Username);
                        ViewData["Username"] = enteredAccount.Username;
                    }
                }
                else
                {
                    ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.DisabledAccount);
                    ViewData["Username"] = enteredAccount.Username;
                }
            }
            else
            {
                ViewData["ErrorMSG"] = ErrorMessages.GetMessage(ErrorCodes.WrongAccountUsername);
                ViewData["Username"] = enteredAccount.Username;
            }
            return Page();
        }     
    }
}
