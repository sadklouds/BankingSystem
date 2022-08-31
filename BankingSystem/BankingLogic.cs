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
        //Customer customerCall = new Customer("Blank", "Blank", "Blank", 0000, 7800, AccountType.Classic);

        List<Admin> admins = new List<Admin>();
        List<Customer> customers = new List<Customer>();


        public void LoadBankData()
        {
            var admin1 = new Admin("Reece", "Lewis", "Nonya 22 Lane", "19116884", "111", true);
            admins.Add(admin1);
            var admin2 = new Admin("God", "Grid", "Who knows", "111", "111", true);
            admins.Add(admin2);

            var customer1 = new Customer("Ps1", "Haggrid", "Nonya", 1111, 7800, AccountType.Classic);
            customers.Add(customer1);
            


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
                //Admin foundPassword = admins.Find(oPassword => oPassword.Password == (password));

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

        public Customer SearchCustomerByAccountNo(int accountno)
        {

            Customer foundCustomer = customers.Find(oCustomer => oCustomer.AccountNo == (accountno));
            if (foundCustomer != null)
            {
                foundCustomer.AccountNo = accountno;
                Console.WriteLine($"{accountno} found");
            }
            if (foundCustomer == null)
            {
                Console.WriteLine($"\nCustomer Account number '{accountno}' cannot be found\n");
            }
            return foundCustomer;
        }



        public void AdminOptions(string username)
        {
            var foundAdmin = (Admin)SearchAdminByUserName(username);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Welcome Admin '{foundAdmin.FirstName} {foundAdmin.LastName}' here are your options");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Customer Account Operations");
            Console.WriteLine("2: Display Admin details");
            Console.WriteLine("3: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //string input = Console.ReadLine();
            bool exit = false;
            do
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    int accountno = Convert.ToInt32(Console.ReadLine());
                    var customerAccount = SearchCustomerByAccountNo(accountno);
                   // if (customerAccount != null)
                        //customerCall.CustomerOperationsMenu(adminFname, adminLname, accountno);

                }
                else if (input == "2")
                {
                    //Admin foundAdmin = (Admin)SearchAdminByUserName(username);
                    Console.WriteLine($"\nFirst name: \t{foundAdmin.FirstName} \nLast name: \t{foundAdmin.LastName}\nAddress: \t{foundAdmin.Address}\nUsername: \t{foundAdmin.UserName}\nPassword: \t{foundAdmin.Password}\nAdmin rights: \t{foundAdmin.AdminRights}");

                }
                else if (input == "3")
                {

                    exit = true;
                    Console.WriteLine("Exiting Banking System");
                    //break;

                }
            } while (exit != true);
        }

        




        public void DisplayAdminDetails()
        {
            foreach (Admin admin in admins)
               admin.DisplayAdminDetails();
        }



    }
}
