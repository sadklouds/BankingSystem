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
         private static string directory = @"C:\VS-Projects\BankingSystem\BankingSystem\BankAccounts\";
         private static string fileName = "Accounts.txt";



        public void CheckForExistingAccountsFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);
            if (existingFileFound)
            {
                Console.WriteLine($"{fileName} exists");
            }
            else if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Directory has been created");
                Console.ResetColor();
            }
        }
        public void LoadAdminData()
        {
            
            var admin1 = new Admin("Grumble", "Test", "Nonya 22 Lane", "19116884", "111", true);
            admins.Add(admin1);
            var admin2 = new Admin("God", "Grid", "Who knows", "111", "111", false);
            admins.Add(admin2);
        }

        public void LoadAccountData()
        {
            CheckForExistingAccountsFile();
            string path = $"{directory}{fileName}";
            try
            {


                if (File.Exists(path))
                {
                    List<string> lines = File.ReadAllLines(path).ToList();
                    foreach (string line in lines)
                    {
                        string[] entries = line.Split(',');
                        string firstName = entries[0];
                        string lastName = entries[1];
                        string address = entries[2];
                        string balanceStr = entries[3];
                        if (decimal.TryParse(balanceStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal balance))
                        {

                        }
                        else
                        {
                            Console.WriteLine($"The balance {balanceStr} could not be converted to decimal in accounts.txt");
                            Environment.Exit(0);
                        }
                        string accountType = entries[4].ToLower();

                        if (entries.Length == 5)
                        {

                            BankAccount bankAccount = null;
                            switch (accountType)
                            {
                                case "classic":
                                    accounts.Add(bankAccount = new ClassicAccount(firstName, lastName, address, balance, accountType));

                                    break;
                                case "student":
                                    accounts.Add(bankAccount = new StudentAccount(firstName, lastName, address, balance, accountType));
                                    break;
                                default:
                                    Console.WriteLine(" Invalid account type, use either Classic, Student or Savings.");
                                    break;
                            }
                        }
                        else 
                        {
                            throw new InvalidOperationException();
                        }

                        
                    }
                }
            } catch (InvalidOperationException) 
            {
                Console.WriteLine("Accounts.txt amount of entries are lower or exceeds 5 per line");
            }
        }
    
        public void SaveBankAccounts()
        {
            string path = $"{directory}{fileName}";
            StringBuilder bob = new StringBuilder();
            foreach (BankAccount accounts in accounts)
            {
                bob.Append($"{accounts.FirstName},");
                bob.Append($"{accounts.LastName},");
                bob.Append($"{accounts.Address},");
                bob.Append($"{accounts.Balance},");
                bob.Append($"{accounts.AccountType}");
                bob.Append(Environment.NewLine);
            }
            File.WriteAllText(path, bob.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved to accounts.txt succussfully");
            Console.ResetColor();
        }


        public string LoginMenu()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the Lucky 38 Bank System");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Admin Login");
            Console.WriteLine("2: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine();
            return option;
        }


        public void RunLoginMenu()
        {
            bool exit = false;
            do
            {
                //Console.Write("Please select and option: ");
                string option = LoginMenu();
                switch (option)
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
                        Console.WriteLine($"\nlogin successful");
                        login = true;
                        RunAdminOptions(username);
                    }
                    if (foundAdmin.Password != password)
                    {
                        Console.WriteLine("\nLogin Failed\n");
                        LoginMenu();
                    }
                }
            } while (login != true);

        }
        


        //user search functions 
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


        public BankAccount SearchSenderByAccountNo(string senderAccountNo)
        {
            BankAccount foundSenderAccount = accounts.Find(oAccount => oAccount.AccountNo == (senderAccountNo));
            if (foundSenderAccount == null)
            {
                Console.WriteLine($"\nBank Account number '{senderAccountNo}' cannot be found\n");
            }
            return foundSenderAccount;
        }


        public void DeleteBankAccount(Admin foundAdmin)
        {
            if (foundAdmin.AdminRights == true)
            {
                Console.Write("Enter account number of customer to delete: ");
                string accountNo = Console.ReadLine();
                var bankAccount = SearchBankAccountByAccountNo(accountNo);
                if (bankAccount != null)
                {
                    Console.WriteLine($"Bank account {bankAccount} has been deleted.");
                    accounts.Remove(bankAccount);
                }
            }
            else
            {
                Console.WriteLine(" You do not have permission");
            }

        }


        public string AdminOptions(string username)
        {
            var foundAdmin = SearchAdminByUserName(username);
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Welcome Admin '{foundAdmin.FirstName} {foundAdmin.LastName}' here are your options");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Customer Account Operations");
            Console.WriteLine("2: Display all customer account details");
            Console.WriteLine("3: View All Admins");
            Console.WriteLine("4: Edit admin own name and address");
            Console.WriteLine("5: Delete BankAccount");
            Console.WriteLine("6: Logout");
            Console.WriteLine("0: Save and Exit System");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine();
            return option;

        }


        public void RunAdminOptions(string username)
        {
            var foundAdmin = SearchAdminByUserName(username);
            var exit = 1;
            do
            {
                string option = AdminOptions(username);
                if (option == "1")
                {
                    Console.Write("Please enter a customer account number: ");
                    string accountNo = Console.ReadLine();
                    var bankAccount = SearchBankAccountByAccountNo(accountNo);
                    if (bankAccount != null)
                        bankAccount.RunAccountOptions(accountNo, foundAdmin, bankAccount);
                }
                else if (option == "2")
                {
                    AllBankAccountDetails();
                }
                
                else if (option == "3")
                {
                    AllDisplayAdminDetails();
                }
                else if (option == "4")
                {
                    foundAdmin.EditAdminDetails(foundAdmin);
                }
                else if (option == "5")
                {
                    DeleteBankAccount(foundAdmin);
                }
                else if (option == "6")
                {
                    exit = 0;
                    Console.WriteLine("\nLoging out the Banking System");
                }
                else if (option == "0")
                {
                    SaveBankAccounts();
                    Environment.Exit(0);
                }

            } while (exit == 1);
        }

        

        public void AllBankAccountDetails()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Customer Accounts");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (BankAccount accounts in accounts)
                Console.WriteLine($"\nFirst name: \t{accounts.FirstName} \nLast name: \t{accounts.LastName}\nAddress: \t{accounts.Address}\nAccountNo: \t{accounts.AccountNo}\nBalance: \t{accounts.Balance}\nAccount Type: \t{accounts.AccountType}\nIn Overdraft: \t{accounts.OverdraftTrue()}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }


        public void AllDisplayAdminDetails()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Admin Accounts");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (Admin admin in admins)
                Console.WriteLine($"\nFirst name: \t{admin.FirstName} \nLast name: \t{admin.LastName}\nAddress: \t{admin.Address}\nUsername: \t{admin.UserName}\nPassword: \t{admin.Password}\nAdmin rights: \t{admin.AdminRights}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        }

    }
}
