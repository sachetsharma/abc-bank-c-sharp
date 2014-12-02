using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            accountTitle = "Checking Account";
        }

        public override EnumAccountType AccountType
        {
	        get { return EnumAccountType.CHECKING; }
        }
}
}
