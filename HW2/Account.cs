using System;

public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("余额不足");
        }
    }
}
