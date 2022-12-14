using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    public class ClassicAccount : BankAccount
    {
        
        public ClassicAccount(string firstName, string lastName, string address, decimal initialBalance, string accountType) : base(firstName, lastName, address, initialBalance, accountType)
        {
             
        }

        public override decimal OverdraftLimit()
        {
            decimal overdraft = -250m;
            return overdraft;
        }


        public override bool OverdraftLimitReached(BankAccount bankAccount)
        {
            bool overdraftReached = false;
            //decimal overdraft = OverdraftLimit();
            if (bankAccount.Balance <0)
            {
                overdraftReached = true;
            }
            return overdraftReached;
        }
        public override void PayableIntrest()
        {

        }



    }
}
