using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class MaxiSavingsAccount : Account
    {
        public MaxiSavingsAccount()
        {
            accountTitle = "Maxi Savings Account";
        }

        public override EnumAccountType AccountType
        {
	        get { return EnumAccountType.MAXI_SAVINGS; }
        }

        /// <summary>
        /// Calculates interest earned
        /// </summary>
        /// <returns>Total ineterest earned</returns>
        public override double interestEarned()
        {
            double amount = sumTransactions();

            if(transactions.Exists(t => (t.amount < 0 &&  t.transactionDate.AddDays(10).Date > DateTime.Now.Date)))
               amount = amount * 0.001;
            else
               amount = amount * 0.05;
            return amount;
        }
    }
}
