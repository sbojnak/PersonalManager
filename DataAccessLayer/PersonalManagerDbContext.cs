using DataAccessLayer.Wallet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer
{
    public class PersonalManagerDbContext : IdentityDbContext<User.User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(t => t.CreationTime).HasColumnType("datetime2");
            modelBuilder.Entity<AccountBalance>().Property(t => t.UpdateTime).HasColumnType("datetime2");

            modelBuilder.Entity<UserRole>().HasKey(p => new {p.RoleId, p.UserId});
            modelBuilder.Entity<UserLogin>().HasKey(p => p.UserId);

        modelBuilder.Entity<User.User>()
                .ToTable("Users");

            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<UserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<UserLogin>()
                .ToTable("UserLogins");
        }
    }
}
