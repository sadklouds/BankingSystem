using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Users;


namespace BankingSystem
{
    public class BankingLogic
    {
         List<Admin> admins = new List<Admin>();
         List<BankAccount> accounts = new List<BankAccount>();

        public void LoadBankData()
        {
            var admin1 = new Admin("Reece", "Lewis", "Nonya 22 Lane", "19116884", "111", true);
            admins.Add(admin1);
            var admin2 = new Admin("God", "Grid", "Who knows", "111", "111", true);
            admins.Add(admin2);

            var account1 = new BankAccount("Ps1", "Haggrid", "Nonya",  7800, AccountType.Classic);
            accounts.Add(account1);
            
        }

        public void LoginMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the Lucky 38 Bank System");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Admin Login");
            Console.WriteLine("2: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            bool exit = false;
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AdminLogin();
                        break;

                    case "2":
                        Console.WriteLine("Exiting Bank");
                        exit = true;
                        break;
                }

            } while (exit != true);

        }


        public void AdminLogin()
        {
            bool login = false;
            do
            {
                Console.WriteLine("Please enter admin username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter admin password: ");
                string password = Console.ReadLine();
                //object adminFname = null;
                SearchAdminByUserName(username);

                Admin foundAdmin = SearchAdminByUserName(username);
                if (foundAdmin != null)
                {
                    if (foundAdmin.Password == password)
                    {
                        Console.WriteLine($"\nlogin successful\n");
                        login = true;
                        AdminOptions(username);
                    }
                    if (foundAdmin.Password != password)
                    {
                        Console.WriteLine("\nLogin Failed\n");
                        LoginMenu();
                    }
                }
            } while (login != true);
             
        }

        public Admin SearchAdminByUserName(string username)
        {
            var foundAdmin = admins.Find(oAdmin => oAdmin.UserName == (username));
            if (foundAdmin == null)
            {
                Console.WriteLine($"\nAdmin username '{username}' cannot be found\n");
            }
            return foundAdmin;
        }

        public BankAccount SearchBankAccountByAccountNo(string accountNo)
        {
            BankAccount foundAccount = accounts.Find(oAccount => oAccount.AccountNo == (accountNo));
            if (foundAccount == null)
            {
                Console.WriteLine($"\nBank Account number '{accountNo}' cannot be found\n");
            }
            return foundAccount;
        }



        public void AdminOptions(string username)
        {
            var foundAdmin = (Admin)SearchAdminByUserName(username);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Welcome Admin '{foundAdmin.FirstName} {foundAdmin.LastName}' here are your options");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Customer Account Operations");
            Console.WriteLine("2: Display all customer account details");
            Console.WriteLine("3: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //string input = Console.ReadLine();
            bool exit = false;
            do
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Please enter a customer account number");
                    string accountNo = Console.ReadLine();
                    var bankAccount = SearchBankAccountByAccountNo(accountNo);
                    if (bankAccount != null)
                        bankAccount.customerOperationsMenu( accountNo, foundAdmin, bankAccount);
                    else
                    {
                        AdminOptions( username);
                    }
                }
                else if (input == "2")
                {
                    string accountNo = "1234567890";
                    var bankAccount = SearchBankAccountByAccountNo(accountNo);
                    AllBankAccountDetails(bankAccount);


                    AdminOptions(username);
                }
                else if (input == "3")
                {

                    exit = true;
                    Console.WriteLine("Exiting Banking System");
                    //break;

                }
            } while (exit != true);
        }



        public void AllBankAccountDetails(BankAccount bankAccount)
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Customer Accounts");
            foreach (BankAccount accounts in accounts)
                Console.WriteLine($"\nFirst name: \t{bankAccount.FirstName} \nLast name: \t{bankAccount.LastName}\nAddress: \t{bankAccount.Address}\nAccountNo: \t{bankAccount.AccountNo}\nBalance: \t{bankAccount.Balance}\nAccountType: \t{bankAccount.AccountType}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }


        public void DisplayAdminDetails()
        {
            foreach (Admin admin in admins)
               admin.DisplayAdminDetails();
        }



    }
}
