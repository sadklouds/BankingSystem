using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    public class StudentAccount : BankAccount
    {
        
        private static TypeOfAccount accountType = TypeOfAccount.Classic;
        public StudentAccount(string firstName, string lastName, string address, decimal initialBalance) : base(firstName, lastName, address, initialBalance)
        {
           
        }

        public override string AccountType()
        {
            string accountType = "Student";
            return accountType;
        }
        public override decimal OverdraftLimit()
        {
            decimal overdraft = -200m;
            return overdraft;
        }

        public override void PayableIntrest()
        {

        }


    }
}
