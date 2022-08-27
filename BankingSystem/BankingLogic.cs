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
       

        public void LoadBankData()
        {
            Admin admin1 = new Admin("Reece", "Lewis", "Nonya 22 Lane", "19116884", "123", true);
            admins.Add(admin1);
            Admin admin2 = new Admin("God", "Grid", "Who knows", "111", "111", true);
            admins.Add(admin2);
        }

        public void LoginMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the Lucky 38 Bank System");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Admin Login");
            Console.WriteLine("2: Display admins");
            Console.WriteLine("3: Quit the banking system");

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
                        Console.WriteLine("Displaying admins");
                        DisplayAdminDetails();
                        break;

                    case "3":
                        Console.WriteLine("Exiting Bank break");
                        exit = true;
                        break;

                   
                }

            } while (exit != true);

        }


        public void AdminLogin()
        {
            Console.WriteLine("Please enter admin username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter admin password: ");
            string password = Console.ReadLine();
            SearchAdminByUserName(ref username);

            string foundAdmin = SearchAdminByUserName(ref username);
            if (foundAdmin != null)
            {
                for (int i = 0; i < admins.Count; i++)
                {
                    if (admins[i].Password == password)
                    {
                        string adminFirstName = admins[i].FirstName;
                        string adminLastName = admins[i].LastName;
                        Console.WriteLine($"\nlogin successful\n");
                        AdminOptions(ref username, ref adminFirstName, ref adminLastName);
                        //adminName = admins[i].FirstName;
                        //return foundAdmin;
                        break;
                    }
                    else if (admins[i].Password != password)
                    {
                        Console.WriteLine("Login Failed");
                        LoginMenu();
                    }

                }
            }

        }

        public void AdminOptions(ref string username, ref string adminFirstName, ref string adminLastName)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Welcome Admin {adminFirstName} {adminLastName} here are your options");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Transfer Money");
            Console.WriteLine("2: Quit the banking system");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        }

        public string SearchAdminByUserName(ref string username)
        {
           string foundAdmin = null;
            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].UserName == username)
                {
                    foundAdmin = username;
                   
                    break;
                }
                if (foundAdmin == null )
                {
                  foundAdmin = null;
                  Console.WriteLine($"Admin username '{username}' does not exist");
                  break;
                    
                }
            
            }
            return foundAdmin;
        }

        public void DisplayAdminDetails()
        {
            foreach (Admin admin in admins)
               admin.DisplayAdminDetails();
        }



    }
}
