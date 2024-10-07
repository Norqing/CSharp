using System;
using System.Collections.Generic;

public class CreditAccount : Account
{
    public decimal CreditLimit { get; set; }
    public List<(DateTime time, decimal amount)> DepositHistory { get; set; } = new List<(DateTime, decimal)>();

    public CreditAccount(string accountNumber, string password, decimal initialBalance)
        : base(accountNumber, initialBalance)
    {
        CreditLimit = 10000; // 假设信用额度为10000
    }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        DepositHistory.Add((DateTime.Now, amount));
    }

    public bool VerifyPassword(string password)
    {
        // 简化密码验证逻辑
        return password == "123456"; // 假设密码为 "password123"
    }
}
