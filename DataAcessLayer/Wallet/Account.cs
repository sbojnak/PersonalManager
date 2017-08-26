using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Wallet
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public DateTime CreationTime { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }
        public virtual List<AccountBalance> AccountBalance { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
