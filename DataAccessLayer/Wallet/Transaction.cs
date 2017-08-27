namespace DataAccessLayer.Wallet
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public bool IsIncome { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public virtual Account Account { get; set; }
    }
}
