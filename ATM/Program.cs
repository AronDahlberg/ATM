namespace ATM
{
    internal class Program
    {
        private static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code
        private static bool IsRunning { get; set; } = true;
        static void Main(string[] args)
        {
            string currency = "kr";

            var accounts = PopulatedAccounts();

            Bank bank = new Bank(accounts, currency);

            string? input;

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
                    case "0": bank.Deposit(); break;

                    case "1": bank.Withdraw(); break;

                    case "2": bank.PrintBalance(); break;

                    case "3": bank.PrintAccounts(); break;

                    case "4": IsRunning = false; break;
                }
            }

            Console.Write(ClearConsole);
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
