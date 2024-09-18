namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currency = "kr";

            var accounts = PopulatedAccounts();

            ATM ATM = new ATM(accounts, currency);

            ATM.Run();
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
