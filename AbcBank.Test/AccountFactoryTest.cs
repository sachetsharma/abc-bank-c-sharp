using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class AccountFactoryTest
    {

        [Test] //Test customer statement generation
        public void testFactory()
        {

            Account checkingAccount = AccountFactory.Get(EnumAccountType.CHECKING);
            Account savingsAccount = AccountFactory.Get(EnumAccountType.SAVINGS);
            Account maxiSavingsAccount = AccountFactory.Get(EnumAccountType.MAXI_SAVINGS);

            Assert.IsInstanceOf<CheckingAccount>(checkingAccount);
            Assert.IsInstanceOf<SavingsAccount>(savingsAccount);
            Assert.IsInstanceOf<MaxiSavingsAccount>(maxiSavingsAccount);


           
           
        }

       
    }
}
