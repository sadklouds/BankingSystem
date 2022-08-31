// See https://aka.ms/new-console-template for more information

using BankingSystem.Users;
using BankingSystem;




BankingLogic bankingLogic = new BankingLogic();
bankingLogic.LoadBankData();
bankingLogic.LoginMenu();







//if (admins[i].Password == password)
//{
//    string adminFirstName = admins[i].FirstName;
//    string adminLastName = admins[i].LastName;
//    Console.WriteLine($"\nlogin successful\n");
//    AdminOptions(username, adminFirstName, adminLastName);
//    //adminName = admins[i].FirstName;
//    //return foundAdmin;
//    break;
//}
//else if (admins[i].Password != password)
//{
//    Console.WriteLine("Login Failed");
//    LoginMenu();
//}

//object foundAdmin = null;
//Admin adminOBJ = null;
// for (int i = 0; i < admins.Count; i++)
// {
//     if (admins[i].UserName == username)
//     {
//         adminOBJ = admins[i];
//         Console.WriteLine(adminOBJ);
//         break;
//     }
//     if (admins[i].UserName != username)
//     {

//       Console.WriteLine($"Admin username '{username}' does not exist");
//       //break;

//     }

// }
// return adminOBJ;