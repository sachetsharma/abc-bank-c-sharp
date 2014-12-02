using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public static class AccountFactory
    {
        public static Account Get(EnumAccountType accountType)
        {
            switch (accountType)
            {
                case  EnumAccountType.SAVINGS:
                    return new SavingsAccount();
                case  EnumAccountType.MAXI_SAVINGS:
                    return new MaxiSavingsAccount();
                default:
                    return new CheckingAccount();
            }
            
        }
    }
}
