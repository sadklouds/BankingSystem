using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem.Users
{
    public class BankAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AccountNo { get;}
        public decimal Balance { get; set; }
        public AccountType AccountType { get; private set; }

        private static int accountNumberSeed = 1234567890;

        BankingLogic bankingLogic = new BankingLogic();

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string firstName, string lastName, string address, decimal initialBalance, AccountType accountType)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            AccountNo = accountNumberSeed.ToString();
            accountNumberSeed++; ;
            Balance = initialBalance;
            AccountType = accountType;
        }

        public decimal Deposit(decimal amount)
        {
            if(amount < 0)
            {
                Console.WriteLine("\nCannot not deposit negative funds");
                return 0;
            }
            else
            {
                Console.WriteLine($"\n{amount} has been added to balance");
                return Balance += amount;
            }     
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }





        public void BankAccountDetails(BankAccount bankAccount)
        {
            Console.WriteLine($"\nFirst name: \t{FirstName} \nLast name: \t{LastName}\nAddress: \t{Address}\nAccountNo: \t{AccountNo}\nBalance: \t{Balance}\nAccountType: \t{AccountType}");
        }

        public void customerOperationsMenu(string accountNo,  Admin foundAdmin, BankAccount bankAccount)
        {
            
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"admin '{foundAdmin.FirstName} {foundAdmin.LastName}' Account: '{bankAccount.AccountNo}' operations menu");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Deposit Money");
            Console.WriteLine("2: Withdraw Money");
            Console.WriteLine("3: Check Balance");
            Console.WriteLine("4: View Bank Account Details");
            Console.WriteLine("5: Exit");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            
            var exit = false;
            do
            {
                Console.WriteLine("please choose an option");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("please input desired amount");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    bankAccount.Deposit(amount);
                    //deposit(amount);
                    customerOperationsMenu( accountNo, foundAdmin, bankAccount);
                }
                else if (input == "2")
                {

                }
                else if (input == "3")
                {
                    Console.WriteLine($"\nBank Account Details");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"Account: {bankAccount.FirstName} {bankAccount.LastName}\nBalance: £{bankAccount.Balance}");
                    customerOperationsMenu(accountNo, foundAdmin, bankAccount);
                }
                else if (input == "4")
                {
                    BankAccountDetails(bankAccount);
                    customerOperationsMenu(accountNo, foundAdmin, bankAccount);
                }
                else if (input == "5")
                {
                    exit = true;

                }
            } while (exit != true);



        }


    }




}
