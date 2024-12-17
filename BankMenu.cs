using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace P3C8
{
    internal class BankMenu
    {
        private CheckingAccount _checkingAccount;
        private SavingsAccount _savingsAccount;

        private const string filePath = @"c:\temp\BankAccountHistoric.txt";
        public BankMenu() {

            _checkingAccount = new CheckingAccount("jérome",600,true);
            _savingsAccount = new SavingsAccount("jérome",2500,true);
        }

        private void WaitForEnter()
        {
            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
        

        private void InitializeFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Historique des Transactions du compte bancaire :" + Environment.NewLine);
            }
        }

        public void MenuAction()
        {
            string input = "";
            InitializeFile();
            do
            {
                DisplayMenu();
                TimeCheck(filePath, "Connexion au compte bancaire ");
                input = Console.ReadLine()?.ToUpper();

                switch (input)
                {
                    case "I":
                        Console.Clear();
                        Console.WriteLine($"Titulaire du compte : {_checkingAccount.name}");
                        WaitForEnter();
                        break;

                    case "CS":
                        Console.Clear();
                        Console.WriteLine($"Solde du compte courant : {_checkingAccount.sold}€");
                        TimeCheck(filePath, "Solde du compte courant consulter ");
                        WaitForEnter();
                        
                        break;

                    case "CD":
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                        if (int.TryParse(Console.ReadLine(), out int amountDepotChecking) && _checkingAccount.AddFunds(amountDepotChecking))
                        {
                            Console.WriteLine($"Vous avez déposé {amountDepotChecking}€.");
                            TimeCheck(filePath, $"Depot compte courant de {amountDepotChecking} € ");
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide.");
                            TimeCheck(filePath, $"Echec tentative depot compte courant ");
                        }
                        WaitForEnter();
                        break;

                    case "CR":
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                        if (int.TryParse(Console.ReadLine(), out int amountWithdrawChecking) && _checkingAccount.WithdrawFunds(amountWithdrawChecking))
                        {
                            Console.WriteLine($"Vous avez retiré {amountWithdrawChecking}€.");
                            TimeCheck(filePath, $"Retrait compte courant de {amountWithdrawChecking} € ");
                        }
                        else
                        {
                            Console.WriteLine("Retrait impossible : fonds insuffisants ou montant invalide.");
                            TimeCheck(filePath, $"Echec tentative retrait compte courant ");
                        }
                        WaitForEnter();
                        break;

                    case "ES":
                        Console.Clear();
                        Console.WriteLine($"Solde du compte Epargne : {_savingsAccount.sold}€");
                        TimeCheck(filePath, "Solde du compte Epargne consulter ");
                        WaitForEnter();
                        break;

                    case "ED":
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                        if (int.TryParse(Console.ReadLine(), out int amountSavingDepot) && _savingsAccount.AddFunds(amountSavingDepot))
                        {
                            Console.WriteLine($"Vous avez déposé {amountSavingDepot}€.");
                            TimeCheck(filePath, $"Depot compte Epargne de {amountSavingDepot} € ");
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide.");
                            TimeCheck(filePath, $"Echec tentative depot compte Epargne ");
                            
                        }
                        WaitForEnter();
                        break;

                    case "ER":
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                        if (int.TryParse(Console.ReadLine(), out int amountSavingsWithdraw) && _savingsAccount.WithdrawFunds(amountSavingsWithdraw))
                        {
                            Console.WriteLine($"Vous avez retiré {amountSavingsWithdraw}€.");
                            TimeCheck(filePath, $"Retrait compte Epargne de {amountSavingsWithdraw} € ");
                        }
                        else
                        {
                            Console.WriteLine("Retrait impossible : fonds insuffisants ou montant invalide.");
                            TimeCheck(filePath, $"Echec tentative retrait compte Epargne ");
                        }
                        WaitForEnter();
                        break;

                    case "X":
                        Console.WriteLine("Merci d'avoir utilisé notre application bancaire. À bientôt !");
                        TimeCheck(filePath, "Application quitter ");
                        return;

                    default:
                        Console.WriteLine("Option invalide, veuillez réessayer.");
                        break;
                }

            } while (input != "X");
        }
        public void DisplayMenu()
        {
            Console.Clear();

            Console.WriteLine("Veuillez sélectionner une option ci-dessous :\n" +
                    "[I] Voir les informations sur le titulaire du compte\n" +
                    "[CS] Compte courant - Consulter le solde\n" +
                    "[CD] Compte courant - Déposer des fonds\n" +
                    "[CR] Compte courant - Retirer des fonds\n" +
                    "[ES] Compte épargne - Consulter le solde\n" +
                    "[ED] Compte épargne - Déposer des fonds\n" +
                    "[ER] Compte épargne - Retirer des fonds\n" +
                    "[X] Quitter");


        }
        private void TimeCheck(string path , string text)
        {
            string dateFR = DateTime.Now.ToString("G", new CultureInfo("fr-FR"));

            string appendText = $"[{DateTime.Now.ToString("G", new CultureInfo("fr-FR"))}] - {text}" + Environment.NewLine;
            

            File.AppendAllText(path, appendText);


        }
    }
}
