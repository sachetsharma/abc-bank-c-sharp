﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class CustomerTest
    {

        [Test] //Test customer statement generation
        public void testApp()
        {

            Account checkingAccount = AccountFactory.Get(EnumAccountType.CHECKING);
            Account savingsAccount = AccountFactory.Get(EnumAccountType.SAVINGS);

            Customer henry = new Customer("Henry").openAccount(checkingAccount).openAccount(savingsAccount);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.getStatement());

            henry.transfer(savingsAccount, checkingAccount, 500);
            Assert.AreEqual(savingsAccount.sumTransactions(), 3300);
            Assert.AreEqual(checkingAccount.sumTransactions(), 600);

            var ex = Assert.Throws<Exception>(() => henry.transfer(checkingAccount, savingsAccount, 1000));
            Assert.That(ex.Message == "Insufficient funds.");
           
        }

        [Test]
        public void testOneAccount()
        {
            Customer oscar = new Customer("Oscar").openAccount(AccountFactory.Get(EnumAccountType.SAVINGS));
            Assert.AreEqual(1, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testTwoAccount()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(AccountFactory.Get(EnumAccountType.SAVINGS));
            oscar.openAccount(AccountFactory.Get(EnumAccountType.CHECKING));
            Assert.AreEqual(2, oscar.getNumberOfAccounts());
        }

        [Ignore]
        public void testThreeAcounts()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(AccountFactory.Get(EnumAccountType.SAVINGS));
            oscar.openAccount(AccountFactory.Get(EnumAccountType.MAXI_SAVINGS));
            oscar.openAccount(AccountFactory.Get(EnumAccountType.CHECKING));
            Assert.AreEqual(3, oscar.getNumberOfAccounts());
        }
    }
}
