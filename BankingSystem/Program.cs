// See https://aka.ms/new-console-template for more information

using BankingSystem.Users;
using BankingSystem;


//List<Admin> admins = new List<Admin>();

BankingLogic bankingLogic = new BankingLogic();
//Admin admin1 = new Admin("Reece", "Lewis", "Nonya 22 Lane", "19116884", "123", true);

bankingLogic.LoadBankData();

bankingLogic.LoginMenu();







