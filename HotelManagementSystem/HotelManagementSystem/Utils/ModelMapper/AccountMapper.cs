using HotelManagementSystem.Models.DTOs;
using HotelManagementSystem.Models.Entities;

namespace HotelManagementSystem.Utils.ModelMapper
{
    public class AccountMapper : IMapper<Account, AccountDTO>
    {
        public AccountDTO ToDto(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            return new AccountDTO
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Email = account.Email,
                Address = account.Address
            };
        }

        public Account ToEntity(AccountDTO accountDto)
        {
            if (accountDto == null)
            {
                throw new ArgumentNullException(nameof(accountDto));
            }

            return new Account
            {
                AccountId = accountDto.AccountId,
                Username = accountDto.Username,
                Email = accountDto.Email,
                Address = accountDto.Address
            };
        }
    }
}
