using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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