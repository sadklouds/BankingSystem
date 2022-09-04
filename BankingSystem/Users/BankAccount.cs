using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem;

namespace BankingSystem.Users
{
    public abstract class BankAccount
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Address { get; protected set; }
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
       

        private static int accountNumberSeed = 1234567890;

        BankingLogic bankingLogic = new BankingLogic();

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string firstName, string lastName, string address, decimal initialBalance)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            AccountNo = accountNumberSeed.ToString();
            accountNumberSeed++; ;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            
        }

        public virtual string AccountType()
        {
            string accountType = "";
            return accountType;
        }

        public virtual decimal OverdraftLimit()
        {
            
            decimal overdraft = 0m;
            return overdraft;
        }

        public virtual void PayableIntrest()
        {
            
        }

        public bool OverdraftTrue()
        {
            bool inOverDraft = Balance < 0 ? true: false;
            return inOverDraft;
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
                //if (Balance - amount < 0)
                //{
                //    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                //}
                if (Balance - amount < OverdraftLimit() )
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal exceeds overdraft limit");
                }
                if (Balance - amount > OverdraftLimit() )
                {
                    var withdrawal = new Transaction(-amount, date, note);
                    allTransactions.Add(withdrawal);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("\nNot sufficient funds for this withdrawal exceeds overdraft limit");
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
            Console.WriteLine($"First name: \t{FirstName} \nLast name: \t{LastName}\nAddress: \t{Address}\nAccountNo: \t{AccountNo}\nBalance: \t{Balance}\nAccount Type: \t{AccountType()}\nInOverdraft: \t{OverdraftTrue()}");
            
        }


        public string CustomerOperationsMenu(string accountNo, Admin foundAdmin, BankAccount bankAccount)
        {

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"admin '{foundAdmin.FirstName} {foundAdmin.LastName}' Account: '{bankAccount.AccountNo}' operations menu");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1: Deposit Money");
            Console.WriteLine("2: Withdraw Money");
            Console.WriteLine("3: Check Balance");
            Console.WriteLine("4: View Bank Account Details");
            Console.WriteLine("5: View Bank Account Transactions");
            Console.WriteLine("6: Edit Customer details");
            Console.WriteLine("7: Return ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("please choose an option: ");
            string option = Console.ReadLine();
            return option;
        }
            public void RunAccountOptions(string accountNo, Admin foundAdmin, BankAccount bankAccount)
            {
                var exit = 1;
                while (exit == 1)
                {
                    string option = CustomerOperationsMenu(accountNo, foundAdmin, bankAccount);
                    if (option == "1")
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
                    else if (option == "2")
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
                    else if (option == "3")
                    {
                        Console.WriteLine($"\nCheck Account Balance");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine($"Account: {bankAccount.FirstName} {bankAccount.LastName}\nBalance: £{bankAccount.Balance}");
                    }
                    else if (option == "4")
                    {
                        BankAccountDetails(bankAccount);
                    }
                    else if (option == "5")
                    {
                        Console.WriteLine("\nAccount Transactions");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine(bankAccount.GetAccountHistory());
                    }
                    else if (option == "6")
                    {
                        Console.Write("Please enter new First Name: ");
                        bankAccount.FirstName = Console.ReadLine();
                        Console.Write("Please enter new Last Name: ");
                        bankAccount.LastName = Console.ReadLine();
                        Console.Write("Please enter new Address: ");
                        bankAccount.Address = Console.ReadLine();

                }
                    else if (option == "7")
                    {
                        exit = 0;

                    }

                }


            }
        }

    }
