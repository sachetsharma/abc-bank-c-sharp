using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Customer
    {
        private String name;
        private List<Account> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public String getName()
        {
            return name;
        }

        public Customer openAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }

        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Account a in accounts)
                total += a.interestEarned();
            return total;
        }

        /*******************************
         * This method gets a statement
         *********************************/
        public String getStatement()
        {
            //JIRA-123 Change by Joe Bloggs 29/7/1988 start
            String statement = null; //reset statement to null here
            //JIRA-123 Change by Joe Bloggs 29/7/1988 end
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (Account a in accounts)
            {
                statement += "\n" + a.getStatement() + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + toDollars(total);
            return statement;
        }

        private String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }

        public bool transfer(Account fromAccount, Account toAccount, double transferAmount)
        {
            double totalAccountValue = fromAccount.sumTransactions();
            if (totalAccountValue < transferAmount)
            {
                throw new Exception("Insufficient funds.");
            }

            fromAccount.withdraw(transferAmount);
            toAccount.deposit(transferAmount);

            return true;
        }
    }
}
