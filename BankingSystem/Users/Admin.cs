using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Users
{
    internal class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AdminRights { get; set; }

        public Admin(string firstName, string lastName, string address, string userName, string Password) : this(firstName, lastName, address, userName, Password, true)
        {

        }

        public Admin(string firstName, string lastName, string address, string userName, string password, bool adminRights)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            UserName = userName;
            Password = password;
            AdminRights = adminRights;
        }

        public void DisplayManagerDetails()
        {
            Console.WriteLine($"\nFirst name: \t{FirstName} \nLast name: \t{LastName}\nAddress: \t\t{Address}\nUsername: \t{UserName}\nPassword: \t£{Password}\nAdmin rights: \t{AdminRights}");
        }
    }


}
