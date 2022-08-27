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
        

        //admins.



        public void LoadBankData()
        {
            Admin admin1 = new Admin("Reece", "Lewis", "Nonya 22 Lane", "123", "123", true);
            admins.Add(admin1);
            Admin admin2 = new Admin("God", "Grid", "Who knows", "24354", "123", true);
            admins.Add(admin2);
        }


        // admin2.LastName = "Blue";


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
                        Console.WriteLine("Please enter admin username");
                        string  a = Console.ReadLine();
                        Console.WriteLine("Please enter admin username");
                        string b = Console.ReadLine();

                        AdminOptions(ref a, ref b);
                       
                        break;
                    case "2":
                        Console.WriteLine("Exiting Bank break");
                        exit = true;
                        break;
                }

            } while (exit != true);

        }


        public void AdminOptions(ref string username, ref string password)
            {
            SearchAdminByUserName(ref username);
            
        
            }

        public void SearchAdminByUserName(ref string username)
        {
            bool foundAdmin;
            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].UserName == username)
                {
                    foundAdmin = true;
                    Console.WriteLine($"{username} ");
                    break;

                }
                if (admins[i].UserName != username )
                {
                    foundAdmin=false;
                    Console.WriteLine($"Admin username {username} does not exist");
                    break;
                    
                }
            }
        }

        public void AdminMainOptions()
        {
            Console.WriteLine($"Welcome ");
        }


    }
}
