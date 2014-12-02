using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            accountTitle = "Savings Account";
        }

        public override EnumAccountType AccountType
        {
	        get { return EnumAccountType.SAVINGS; }
        }

        /// <summary>
        /// Calculates interest earned
        /// </summary>
        /// <returns>Total ineterest earned</returns>
        public override double interestEarned()
        {
            double amount = sumTransactions();

            if (amount <= 1000)
                amount = amount * 0.001;
            else
                amount = 1 + (amount - 1000) * 0.002;

            return amount;
        }
    }
}
