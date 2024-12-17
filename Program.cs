// See https://aka.ms/new-console-template for more information
using P3C8;

Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");

BankMenu bankMenu = new BankMenu();

if (Console.ReadKey().Key == ConsoleKey.Enter) 
{

    bankMenu.MenuAction();


}