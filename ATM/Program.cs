using System.Security.Principal;

namespace ATM
{
    internal class Program
    {
        private static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code
        private static bool IsRunning { get; set; } = true;
        private static Account[] Accounts { get; set; } = PopulatedAccounts();
        private static string Currency { get; } = "kr";
        static void Main(string[] args)
        {
            string ? input;

            while (IsRunning)
            {
                Console.Write(ClearConsole +
                    "0: Make a deposit\n" +
                    "1: Make a withdrawal\n" +
                    "2: See balance\n" +
                    "3: See all accounts\n" +
                    "4: Exit\n");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0": Deposit(); break;

                    case "1": Withdraw(); break;

                    case "2": PrintBalance(); break;

                    case "3": PrintAccounts(); break;

                    case "4": IsRunning = false; break;
                }
            }

            Console.Write(ClearConsole);
        }

        private static void Deposit()
        {
            try
            {
                var account = GetAccount();

                double amount = double.Parse(GetAmount());

                account.Deposit(amount);

                Console.WriteLine(ClearConsole +
                    "Deposit succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Deposit unsuccesfull");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private static void Withdraw()
        {
            try
            {
                var account = GetAccount();

                double amount = double.Parse(GetAmount());

                if (amount > account.Balance)
                {
                    throw new ArgumentException("Invalid Amount");
                }

                account.Withdraw(amount);

                Console.WriteLine(ClearConsole +
                    "Withdrawal succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Withdrawal unsuccesfull");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private static void PrintBalance()
        {
            try
            {
                var account = GetAccount();

                Console.WriteLine(ClearConsole +
                    $"Balance for account {account.AccountNumber}\n" +
                    $": {account.Balance}{Currency}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine(ClearConsole +
                    "Could not find account");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private static void PrintAccounts()
        {
            Console.Write(ClearConsole);

            for ( int i = 0; i < Accounts.Length; i++ )
            {
                Console.WriteLine(Accounts[i].ToString() + Currency);
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private static Account GetAccount()
        {
            string? accountNmr = GetAccountNumber();

            return Accounts.FirstOrDefault(account => account.AccountNumber == accountNmr);
        }
        private static string GetAccountNumber()
        {
            Console.Write(ClearConsole +
                "Enter account number\n" +
                ": ");

            return Console.ReadLine();
        }
        private static string GetAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            return Console.ReadLine();
        }
        private static Account[] PopulatedAccounts()
        {
            Account[] accounts = new Account[10];

            for ( int i = 0; i < 10; i++)
            {
                string str = $"{i}{i}{i}";
                accounts[i] = new Account($"{str}-{str}");
                accounts[i].Deposit(i * 1000);
            }

            return accounts;
        }
    }
}
