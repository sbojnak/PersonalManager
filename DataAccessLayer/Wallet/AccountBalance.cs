using System;

namespace DataAccessLayer.Wallet
{
    public class AccountBalance
    {
        public int AccountBalanceId { get; set; }
        public double Balance { get; set; }
        public DateTime UpdateTime { get; set; }
        public Account Account { get; set; }
    }
}
