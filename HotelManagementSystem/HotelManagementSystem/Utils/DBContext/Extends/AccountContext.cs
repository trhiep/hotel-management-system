using HotelManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotelManagementSystem.Utils.DBContext.Extends
{
    public partial class AccountContext : HMS_DBContext
    {
        public AccountContext(DbContextOptions<HMS_DBContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; } = null!;

        private Account FindAccount(Account account)
        {
            return Accounts.Where(a => a.AccountId == account.AccountId).FirstOrDefault();
        }
    }
}
