namespace ATM
{
    internal class ATM
    {
        private static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code
        private bool IsRunning { get; set; } = true;
        private Bank Bank { get; set; }
        public ATM(Account[] accounts, string currency)
        {
            Bank = new Bank(accounts, currency);
        }
        public void Run()
        {
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
                    case "0": Bank.Deposit(); break;

                    case "1": Bank.Withdraw(); break;

                    case "2": Bank.PrintBalance(); break;

                    case "3": Bank.PrintAccounts(); break;

                    case "4": IsRunning = false; break;
                }
            }

            Console.Write(ClearConsole);
        }
    }
}
