using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    public class Admin
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool AdminRights { get; private set; }

        

        public Admin(string firstName, string lastName, string address, string userName, string password, bool adminRights)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            UserName = userName;
            Password = password;
            AdminRights = adminRights;
        }

        BankingLogic bankingLogic = new BankingLogic();

        
        public void EditAdminDetails(Admin foundAdmin)
        {
                Console.Write("Please enter new First Name: ");
                foundAdmin.FirstName = Console.ReadLine();
                Console.Write("Please enter new Last Name: ");
                foundAdmin.LastName = Console.ReadLine();
                Console.Write("Please enter new Address: ");
                foundAdmin.Address = Console.ReadLine();
        }


        
    }

}
