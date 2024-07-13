using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelManagementSystem.Models.Entities;
using HotelManagementSystem.Utils.DBContext.Extends;
using log4net;
using HotelManagementSystem.Logs;

namespace HotelManagementSystem.Controllers.Account
{
    public class IndexModel : PageModel
    {
        private AccountContext _accountContext;
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public IndexModel (AccountContext accountContext)
        {
            _accountContext = accountContext;
            LoggerConfig.Configure();
        }

        public IActionResult OnGet()
        {
            IList<HotelManagementSystem.Models.Entities.Account> accounts = _accountContext.Accounts.ToList();
            foreach (var item in accounts)
            {
                Console.WriteLine(item.Email);
            }
            log.Info("Entered Account");
            log.Error("Entered Account");
            log.Warn("Entered Account");
            return Page();
        }
    }
}
