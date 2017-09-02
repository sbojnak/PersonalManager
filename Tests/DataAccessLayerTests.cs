using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
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

        [TestMethod]
        public void AddAccountAndAccountBalance()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var account = new Account
                {
                    AccountName = "Account 5465",
                    AccountType = "Test type 2",
                    Balance = -51.2,
                    CreationTime = DateTime.Now,
                    Currency = "Dollar"
                };
                var accountBalance = new AccountBalance
                {
                    Balance = -65421.74,
                    UpdateTime = DateTime.Now
                };
                account.AccountBalance.Add(accountBalance);
                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
                var storedAccount = dbContext.Accounts.Find(account.AccountId);
                var storedAccountBalance = dbContext.AccountBalances.Find(accountBalance.AccountBalanceId);
                var listOfBalances = new List<AccountBalance>(storedAccount.AccountBalance);
                dbContext.AccountBalances.Remove(storedAccountBalance);
                dbContext.Accounts.Remove(storedAccount);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareAccountBalances(storedAccountBalance, listOfBalances.First()),
                    "AccountBalance of Account has not been properly set");
            }
        }

        [TestMethod]
        public void AddAccountAndTransaction()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                var account = new Account
                {
                    AccountName = "Account 5465",
                    AccountType = "Test type 2",
                    Balance = -51.2,
                    CreationTime = DateTime.Now,
                    Currency = "Dollar"
                };
                var transaction = new Transaction()
                {
                    Amount = -530.151,
                    IsIncome = false,
                    TransactionType = "Shopping dafdsafsadfadsdv"
                };
                account.Transactions.Add(transaction);
                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
                var storedAccount = dbContext.Accounts.Find(account.AccountId);
                var storedTransaction = dbContext.Transactions.Find(transaction.TransactionId);
                var listOfTransactions = new List<Transaction>(storedAccount.Transactions);
                dbContext.Transactions.Remove(storedTransaction);
                dbContext.Accounts.Remove(storedAccount);
                dbContext.SaveChanges();
                Assert.IsTrue(CompareTransactions(storedTransaction, listOfTransactions.First()),
                    "Transaction of Account has not been properly set");
            }
        }
    }
}
