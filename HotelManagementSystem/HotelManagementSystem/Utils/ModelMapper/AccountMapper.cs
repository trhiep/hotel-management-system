﻿using HotelManagementSystem.Models.DTOs;
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
                AccountId = account.AccountId.ToString(),
                Name = account.Username,
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
                AccountId = int.Parse(accountDto.AccountId),
                Username = accountDto.Name,
                Email = accountDto.Email,
                Address = accountDto.Address
            };
        }
    }
}
