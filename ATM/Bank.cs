namespace ATM
{
    class Bank
    {
        private static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code
        private Account[] Accounts { get; set; }
        private string Currency { get; set; }
        public Bank(Account[] accounts, string currency)
        {
            Accounts = accounts;
            Currency = currency;
        }
        public void Deposit()
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
        public void Withdraw()
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
        public void PrintBalance()
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
        public void PrintAccounts()
        {
            Console.Write(ClearConsole);

            for (int i = 0; i < Accounts.Length; i++)
            {
                Console.WriteLine(Accounts[i].ToString() + Currency);
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private Account GetAccount()
        {
            string? accountNmr = GetAccountNumber();

            return Accounts.FirstOrDefault(account => account.AccountNumber == accountNmr);
        }
        private string GetAccountNumber()
        {
            Console.Write(ClearConsole +
                "Enter account number\n" +
                ": ");

            return Console.ReadLine();
        }
        private string GetAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            return Console.ReadLine();
        }
    }
}