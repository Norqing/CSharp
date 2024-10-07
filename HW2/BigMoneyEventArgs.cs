using System;

public class BigMoneyEventArgs : EventArgs
{
    public string AccountNumber { get; }
    public decimal Amount { get; }

    public BigMoneyEventArgs(string accountNumber, decimal amount)
    {
        AccountNumber = accountNumber;
        Amount = amount;
    }
}
