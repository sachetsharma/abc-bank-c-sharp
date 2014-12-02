using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void customerSummary()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.openAccount(AccountFactory.Get(EnumAccountType.CHECKING));
            bank.addCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.customerSummary());
        }

        [Test]
        public void checkingAccount()
        {
            Bank bank = new Bank();
            Account checkingAccount = AccountFactory.Get(EnumAccountType.CHECKING);
            Customer bill = new Customer("Bill").openAccount(checkingAccount);
            bank.addCustomer(bill);

            checkingAccount.deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void savings_account()
        {
            Bank bank = new Bank();
            Account savingsAccount = AccountFactory.Get(EnumAccountType.SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(savingsAccount));

            savingsAccount.deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);

            savingsAccount.withdraw(600);

            Assert.AreEqual(0.9, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void maxi_savings_account()
        {
            Bank bank = new Bank();
            Account maxiSavingsAccount = AccountFactory.Get(EnumAccountType.MAXI_SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(maxiSavingsAccount));

            maxiSavingsAccount.deposit(3000.0);

            Assert.AreEqual(150.0, bank.totalInterestPaid(), DOUBLE_DELTA);

            maxiSavingsAccount.withdraw(100);

            Assert.AreEqual(2.9, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

    }
}
