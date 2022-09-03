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
            var admin1 = new Admin("Grumble", "Test", "Nonya 22 Lane", "19116884", "111", true);
            admins.Add(admin1);
            var admin2 = new Admin("God", "Grid", "Who knows", "111", "111", true);
            admins.Add(admin2);

            try
            {
                var account1 = new BankAccount("Test", "Test", "Nonya", 0, AccountType.Classic);
                accounts.Add(account1);

                var account2 = new BankAccount("Kloud", "Shepard", "Nonya", 100, AccountType.Classic);
                accounts.Add(account2);

            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\n Exception caught creating account with negative balance\n");
                Console.WriteLine(e.ToString());
                return;
            }
            
        }

        public void TransferFunds()
        {
            Console.Write("Please enter sender account no: ");
            string senderAccountNo = Console.ReadLine();
            BankAccount foundSenderAccount = SearchBankAccountSenderByAccountNo(senderAccountNo);
            if (foundSenderAccount != null)
            {
                Console.Write("please input desired amount to be Withdrawn: ");
                string checkAmount = Console.ReadLine();
                decimal amount;
                var date = DateTime.Now;
                if (Decimal.TryParse(checkAmount, out amount))
                {
                    Console.Write("Leave a note for transaction: ");
                    string note = Console.ReadLine();
                    foundSenderAccount.MakeWithdrawal(amount, date, note);

                    Console.Write("Please enter reciver account no: ");
                    string accountNo = Console.ReadLine();
                    BankAccount foundAccount = SearchBankAccountByAccountNo(accountNo);
                    if (foundAccount != null)
                    {
                        foundAccount.MakeDeposit(amount, date, note);
                    }
                }
                else
                    Console.WriteLine("\nAmount inputted was not a number convertable to decimal", amount);
            }
           
            
                //Console.Write("please input desired amount to be deposited: ");
                //string checkAmount = Console.ReadLine();
                //decimal amount;
                //var date = DateTime.Now;
                //if (Decimal.TryParse(checkAmount, out amount))
                //{
                //    Console.Write("Leave a note for transaction: ");
                //     string note = Console.ReadLine();
                //     foundAccount.MakeDeposit(amount, date, note);
                //}
                //else
                //    Console.WriteLine("\nAmount inputted was not a number convertable to decimal", amount);

                //}
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
                Console.Write("Please select and option: ");
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
                Console.Write("Please enter admin username: ");
                string username = Console.ReadLine();
                Console.Write("Please enter admin password: ");
                string password = Console.ReadLine();
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

        public BankAccount SearchBankAccountSenderByAccountNo(string senderAccountNo)
        {
            BankAccount foundSenderAccount = accounts.Find(oAccount => oAccount.AccountNo == (senderAccountNo));
            if (foundSenderAccount == null)
            {
                Console.WriteLine($"\nBank Account number '{senderAccountNo}' cannot be found\n");
            }
            return foundSenderAccount;
        }


        public void AdminOptions(string username)
        {
            var foundAdmin = (Admin)SearchAdminByUserName(username);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Welcome Admin '{foundAdmin.FirstName} {foundAdmin.LastName}' here are your options");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Customer Account Operations");
            Console.WriteLine("2: Display all customer account details");
            Console.WriteLine("3: Transfer funds between accounts");
            Console.WriteLine("4: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            bool exit = false;
            do
            {
                Console.Write("\nPlease select an option: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Please enter a customer account number: ");
                    string accountNo = Console.ReadLine();
                    var bankAccount = SearchBankAccountByAccountNo(accountNo);
                    if (bankAccount != null)
                        bankAccount.customerOperationsMenu( accountNo, foundAdmin, bankAccount);
                    else
                    {
                        AdminOptions(username);
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
                    TransferFunds();
                }
                else if (input == "4")
                {
                    exit = true;
                    Console.WriteLine("Exiting Banking System");
                }
            } while (exit != true);
        }



        public void AllBankAccountDetails(BankAccount bankAccount)
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Customer Accounts");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (BankAccount accounts in accounts)
                Console.WriteLine($"\nFirst name: \t{accounts.FirstName} \nLast name: \t{accounts.LastName}\nAddress: \t{accounts.Address}\nAccountNo: \t{accounts.AccountNo}\nBalance: \t{accounts.Balance}\nAccountType: \t{accounts.AccountType}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
       

        public void DisplayAdminDetails()
        {
            foreach (Admin admin in admins)
               admin.DisplayAdminDetails();
        }



    }
}
