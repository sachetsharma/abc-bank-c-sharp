using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public abstract class Account
    {

        protected string accountTitle = string.Empty;

        protected List<Transaction> transactions;
        public Account()
        {
            this.transactions = new List<Transaction>();
        }

        public virtual void deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(amount));
            }
        }

        public virtual void withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(-amount));
            }
        }

        /// <summary>
        /// Calculates intereset earned
        /// </summary>
        /// <returns>Total ineterest earned</returns>
        public virtual double interestEarned()
        {
            double amount = sumTransactions();
            return amount * 0.001;
        }

        public virtual double sumTransactions()
        {
            return checkIfTransactionsExist(true);
        }

        protected virtual double checkIfTransactionsExist(bool checkAll)
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }

        public abstract EnumAccountType AccountType
        {
            get; 
        }

        public virtual string getStatement()
        {
            String s = accountTitle + "\n";

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in transactions)
            {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + toDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + toDollars(total);
            return s;
        }

        protected virtual String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }

    }
}
