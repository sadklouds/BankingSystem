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
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }
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
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            AccountType = accountType;
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            try
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                var deposit = new Transaction(amount, date, note);
                allTransactions.Add(deposit);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\nException caught trying to deposit negative funds, must be positive");
                //Console.WriteLine(e.ToString());
            }
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }
                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                }
                var withdrawal = new Transaction(-amount, date, note);
                allTransactions.Add(withdrawal);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("\nException caught trying to overdraw (insufficient funds)");
                //Console.WriteLine(e.ToString());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\nException caught trying to draw negative funds, amount must be positive");
                //Console.WriteLine(e.ToString());
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public void BankAccountDetails(BankAccount bankAccount)
        {
            Console.WriteLine("\nBank Accounts Details");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"First name: \t{FirstName} \nLast name: \t{LastName}\nAddress: \t{Address}\nAccountNo: \t{AccountNo}\nBalance: \t{Balance}\nAccountType: \t{AccountType}");
            
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
            Console.WriteLine("5: View Bank Account Transactions");
            Console.WriteLine("6: Exit");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            
            var exit = false;
            do
            {
                Console.Write("\nplease choose an option: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("please input desired amount to be deposited: ");
                    string checkAmount = Console.ReadLine();
                    decimal amount;
                    var date = DateTime.Now;
                    if (Decimal.TryParse(checkAmount, out amount))
                    {
                        Console.Write("Leave a note for transaction: ");
                        string note = Console.ReadLine();
                        bankAccount.MakeDeposit(amount, date, note);
                    }
                    else
                        Console.WriteLine("\nAmount inputted was not a number convertable to decimal", amount);
                    
                }
                else if (input == "2")
                {
                    
                        Console.Write("please input desired amount to be withdrawn: ");
                        string checkAmount = Console.ReadLine();
                        decimal amount;
                        var date = DateTime.Now;
                        if (Decimal.TryParse(checkAmount, out amount))
                        {

                            Console.Write("Leave a note for transaction: ");
                            string note = Console.ReadLine();
                            bankAccount.MakeWithdrawal(amount, date, note);
                        }
                        else
                            Console.WriteLine("\nAmount inputted was not a number convertable to decimal", amount);
                    
                }
                else if (input == "3")
                {
                    Console.WriteLine($"\nCheck Account Balance");
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
                    Console.WriteLine("\nAccount Transactions");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine(bankAccount.GetAccountHistory());
                    customerOperationsMenu(accountNo, foundAdmin, bankAccount);
                }
                else if (input == "6")
                {
                    exit = true;

                }
            } while (exit != true);



        }


    }




}
