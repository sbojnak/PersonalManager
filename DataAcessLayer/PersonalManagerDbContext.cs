using DataAccessLayer.Wallet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PersonalManagerDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(t => t.CreationTime).HasColumnType("datetime2");
            modelBuilder.Entity<AccountBalance>().Property(t => t.UpdateTime).HasColumnType("datetime2");
        }
    }
}
