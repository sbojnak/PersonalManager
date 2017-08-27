using System;
using DataAccessLayer;
using DataAccessLayer.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DataAccessLayerTests
    {
        public bool CompareAccounts(Account firstAccount, Account secondAccount)
        {
            return (firstAccount.AccountId == secondAccount.AccountId) &&
                   (Math.Abs(firstAccount.Balance - secondAccount.Balance) < 0.0001) &&
                   (firstAccount.AccountName == secondAccount.AccountName) &&
                   (firstAccount.AccountType == secondAccount.AccountType) &&
                   (DateTime.Compare(firstAccount.CreationTime, secondAccount.CreationTime) == 0) &&
                   (firstAccount.Currency == secondAccount.Currency);
        }

        public bool CompareAccountBalances(AccountBalance firstBalance, AccountBalance secondBalance)
        {
            return (firstBalance.AccountBalanceId == secondBalance.AccountBalanceId) &&
                   (Math.Abs(firstBalance.Balance - secondBalance.Balance) < 0.0001) &&
                   (DateTime.Compare(firstBalance.UpdateTime, secondBalance.UpdateTime) == 0);

        }

        public bool CompareTransactions(Transaction firstTransaction, Transaction secondTransaction)
        {
            return (firstTransaction.TransactionId == secondTransaction.TransactionId) &&
                   (firstTransaction.IsIncome == secondTransaction.IsIncome) &&
                   (Math.Abs(firstTransaction.Amount - secondTransaction.Amount) < 0.0001) &&
                   (firstTransaction.TransactionType == secondTransaction.TransactionType);
        }

        [TestMethod]
        public void AddAccountSetAllAttributesExceptId()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var account = new Account
                {
                    AccountName = "Test account",
                    AccountType = "Test type",
                    Balance = 25.4,
                    CreationTime = DateTime.Now,
                    Currency = "Euro"
                };
                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
                var storedAccount = dbContext.Accounts.Find(account.AccountId);
                dbContext.Accounts.Remove(storedAccount);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareAccounts(account, storedAccount), $"{account} is not the same as {storedAccount}");
            }
        }

        [TestMethod]
        public void AddAccountBalanceSetAllAttributesExceptId()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var accountBalance = new AccountBalance
                {
                    Balance = 56.74,
                    UpdateTime = DateTime.Now
                };
                dbContext.AccountBalances.Add(accountBalance);
                dbContext.SaveChanges();
                AccountBalance storedAccountBalance = dbContext.AccountBalances.Find(accountBalance.AccountBalanceId);
                dbContext.AccountBalances.Remove(storedAccountBalance);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareAccountBalances(accountBalance, storedAccountBalance),
                    $"{accountBalance} is not the same as {storedAccountBalance}");
            }
        }

        [TestMethod]
        public void AddTransactionSetAllAttributesExceptId()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var transaction = new Transaction
                {
                    Amount = 547.2,
                    IsIncome = true,
                    TransactionType = "Shopping"
                };
                dbContext.Transactions.Add(transaction);
                dbContext.SaveChanges();
                Transaction storedTransaction = dbContext.Transactions.Find(transaction.TransactionId);
                dbContext.Transactions.Remove(storedTransaction);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareTransactions(transaction, storedTransaction),
                    $"{transaction} is not the same as {storedTransaction}");
            }
        }

        [TestMethod]
        public void AddAccountSetNoAttributes()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var account = new Account();
                dbContext.Accounts.Add(account);
                Account storedAccount = dbContext.Accounts.Find(account.AccountId);
                dbContext.Accounts.Remove(storedAccount);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareAccounts(account, storedAccount), 
                    $"{account} is not the same as {storedAccount}");
            }
        }

        [TestMethod]
        public void AddAccountBalanceSetNoAttributes()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var accountBalance = new AccountBalance();
                dbContext.AccountBalances.Add(accountBalance);
                AccountBalance storedAccountBalance = dbContext.AccountBalances.Find(accountBalance.AccountBalanceId);
                dbContext.AccountBalances.Remove(storedAccountBalance);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareAccountBalances(accountBalance, storedAccountBalance),
                    $"{accountBalance} is not the same as {storedAccountBalance}");
            }
        }

        [TestMethod]
        public void AddTransactionSetNoAttributes()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var transaction = new Transaction();
                dbContext.Transactions.Add(transaction);
                Transaction storedTransaction = dbContext.Transactions.Find(transaction.TransactionId);
                dbContext.Transactions.Remove(storedTransaction);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareTransactions(transaction, storedTransaction),
                    $"{transaction} is not the same as {storedTransaction}");
            }
        }
    }
}
