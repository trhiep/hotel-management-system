using HotelManagementSystem.Models.DTOs;
using HotelManagementSystem.Models.Entities;
using HotelManagementSystem.Utils.ModelMapper;
using System.Text.Json;

namespace HotelManagementSystem.Utils
{
    public class SessionHelper
    {
        public static Account GetAccountFromSession(HttpContext httpContext, string sessionName)
        {
            var LogedInAccountJson = httpContext.Session.GetString(sessionName);

            if (LogedInAccountJson != null)
            {
                var LogedInAccountDTO = JsonSerializer.Deserialize<AccountDTO>(LogedInAccountJson);
                AccountMapper accountMapper = new AccountMapper();
                return accountMapper.ToEntity(LogedInAccountDTO);
            }
            return null;
        }

        public static void SaveSession(Account account, HttpContext httpContext, string sessionName)
        {
            AccountMapper accountMapper = new AccountMapper();
            var foundAccountDTO = accountMapper.ToDto(account);
            var LogedInAccountJson = JsonSerializer.Serialize(foundAccountDTO);
            httpContext.Session.SetString(sessionName, LogedInAccountJson);
        }

    }
}
