namespace ATM
{
    internal class Account
    {
		private double _balance;

		public double Balance
		{
			get { return _balance; }
			set { _balance = value >= 0.0
					? value
					: _balance; }
		}
        public string AccountNumber { get; }
        public Account(string accountNumber)
		{
			AccountNumber = accountNumber;
		}
		public void Deposit (double amount)
		{
			if (amount < 0.0) { throw new ArgumentException("Invalid amount"); }
			Balance += amount;
		}
		public void Withdraw (double amount)
		{
            if (amount < 0.0) { throw new ArgumentException("Invalid amount"); }
            Balance -= amount;
		}
        public override string ToString()
		{
			return $"{AccountNumber}: {Balance}";
		}
    }
}
