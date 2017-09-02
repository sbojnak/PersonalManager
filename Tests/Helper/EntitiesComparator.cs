using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.UserIdentity;
using DataAccessLayer.Wallet;

namespace Tests.Helper
{
    static class EntitiesComparator
    {
        public static bool CompareAccounts(Account firstAccount, Account secondAccount)
        {
            return (firstAccount.AccountId == secondAccount.AccountId) &&
                   (Math.Abs(firstAccount.Balance - secondAccount.Balance) < 0.0001) &&
                   (firstAccount.AccountName == secondAccount.AccountName) &&
                   (firstAccount.AccountType == secondAccount.AccountType) &&
                   (DateTime.Compare(firstAccount.CreationTime, secondAccount.CreationTime) == 0) &&
                   (firstAccount.Currency == secondAccount.Currency);
        }

        public static bool CompareAccountBalances(AccountBalance firstBalance, AccountBalance secondBalance)
        {
            return (firstBalance.AccountBalanceId == secondBalance.AccountBalanceId) &&
                   (Math.Abs(firstBalance.Balance - secondBalance.Balance) < 0.0001) &&
                   (DateTime.Compare(firstBalance.UpdateTime, secondBalance.UpdateTime) == 0);
        }

        public static bool CompareTransactions(Transaction firstTransaction, Transaction secondTransaction)
        {
            return (firstTransaction.TransactionId == secondTransaction.TransactionId) &&
                   (firstTransaction.IsIncome == secondTransaction.IsIncome) &&
                   (Math.Abs(firstTransaction.Amount - secondTransaction.Amount) < 0.0001) &&
                   (firstTransaction.TransactionType == secondTransaction.TransactionType);
        }

        public static bool CompareUsersIdMailPassword(User firstUser, User secondUser)
        {
            return (firstUser.Id == secondUser.Id) &&
                   (firstUser.Email == secondUser.Email) &&
                   (firstUser.PasswordHash == secondUser.PasswordHash);
        }
    }
}
