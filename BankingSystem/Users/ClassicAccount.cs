using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    public class ClassicAccount : BankAccount
    {
        
        public ClassicAccount(string firstName, string lastName, string address, decimal initialBalance) : base(firstName, lastName, address, initialBalance)
        {
             
        }

        public override decimal OverdraftLimit()
        {
            decimal overdraft = -200m;
            return overdraft;
        }

        public override string AccountType ()
        {
            string accountType = "Classic";
            return accountType;
        }

        public override void PayableIntrest()
        {

        }



    }
}
