using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    public class StudentAccount : BankAccount
    {
        
       
        public StudentAccount(string firstName, string lastName, string address, decimal initialBalance, string accountType) : base(firstName, lastName, address, initialBalance, accountType)
        {
           
        }

        
        public override decimal OverdraftLimit()
        {
            decimal overdraft = -200m;
            return overdraft;
        }

        public override bool OverdraftLimitReached(BankAccount bankAccount)
        {
            bool overdraftReached = false;
            //decimal overdraft = OverdraftLimit();
            if (bankAccount.Balance < OverdraftLimit())
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
