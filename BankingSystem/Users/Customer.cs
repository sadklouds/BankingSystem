using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem.Users
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int AccountNo { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }

        BankingLogic bankingLogic = new BankingLogic();

        public Customer(string firstName, string lastName, string address, int accountNo, double balance, AccountType accountType)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            AccountNo = accountNo;
            Balance = balance;
            AccountType = accountType;
        }

          public double Deposit(double amount)
        {
            return Balance+= amount;
        }

        double getBalance()
        {
            return Balance;
        }
        //public void CustomerOperationsMenu(object adminFname, object adminLname,int accountno)
        //{
        //    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //    Console.WriteLine($"Admin '{adminFname} {adminLname}' Customer Operations menu");
        //    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //    Console.WriteLine("1: Deposit Money");
        //    Console.WriteLine("2: Withdrwa Money");
        //    Console.WriteLine("3: Check Balance");
        //    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //    var customerAccount = (Customer)bankingLogic.SearchCustomerByAccountNo(accountno);
        //    var exit = false;
        //    do
        //    {
        //        string input = Console.ReadLine();
        //        if (input == "1")
        //        {
                    
        //            Console.WriteLine("Please input desired amount");
        //            double amount = Convert.ToDouble(Console.ReadLine());
        //            customerAccount.Deposit(amount);
        //            //Deposit(amount);
        //            CustomerOperationsMenu(adminFname, adminLname, accountno);
        //        }
        //        else if (input == "2")
        //        {
                    
        //        }
        //        else if (input == "3")
        //        {
        //            customerAccount.getBalance();
        //            CustomerOperationsMenu(adminFname, adminLname, accountno);
        //        }
        //        else if (input == "4")
        //        {
        //            exit = true;
                    
        //        }
        //    } while (exit != true);
            


        //}


    }


   
  
}
