using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class AccountTests
    {
        [Test] //Test customer statement generation
        public void testAccounts()
        {

            Account checkingAccount = AccountFactory.Get(EnumAccountType.CHECKING);
            Account savingsAccount = AccountFactory.Get(EnumAccountType.SAVINGS);
            Account maxiSavingsAccount = AccountFactory.Get(EnumAccountType.MAXI_SAVINGS);

            Assert.AreEqual(checkingAccount.AccountType, EnumAccountType.CHECKING);
            Assert.AreEqual(savingsAccount.AccountType, EnumAccountType.SAVINGS);
            Assert.AreEqual(maxiSavingsAccount.AccountType, EnumAccountType.MAXI_SAVINGS);

            var ex = Assert.Throws<ArgumentException>(() => checkingAccount.deposit(-100));
            Assert.That(ex.Message == "amount must be greater than zero");

            ex = Assert.Throws<ArgumentException>(() => checkingAccount.withdraw(-100));
            Assert.That(ex.Message == "amount must be greater than zero");



        }

        [Test]
        public void testStatements()
        {
            Account checkingAccount = AccountFactory.Get(EnumAccountType.CHECKING);
            Account savingsAccount = AccountFactory.Get(EnumAccountType.SAVINGS);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00", checkingAccount.getStatement());
            Assert.AreEqual("Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00"
                    , savingsAccount.getStatement());
        }
    }
}
