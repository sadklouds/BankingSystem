// See https://aka.ms/new-console-template for more information

using BankingSystem.Users;
using BankingSystem;




BankingLogic bankingLogic = new BankingLogic();
bankingLogic.LoadAdminData();
bankingLogic.LoadAccountData();
bankingLogic.RunLoginMenu();







