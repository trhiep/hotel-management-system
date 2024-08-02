using HotelManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotelManagementSystem.Utils.DBContext.Extends
{
    public partial class AccountContext : HMS_DBContext
    {
        public AccountContext(DbContextOptions<HMS_DBContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; } = null!;

        public Account FindAccountByUsername(string username)
        {
            return Accounts.Where(a => a.Username == username).FirstOrDefault();
        }

        public Account FindAccountByEmail(string email)
        {
            return Accounts.Where(a => a.Email == email).FirstOrDefault();
        }

        public void UpdateAccount(Account account)
        {
            Account oldAccountInf = Accounts.Where(x => x.AccountId == account.AccountId).First();
            if (oldAccountInf != null)
            {
                oldAccountInf.Password = account.Password;
                Accounts.Update(oldAccountInf);
            }
        }
    }
}
