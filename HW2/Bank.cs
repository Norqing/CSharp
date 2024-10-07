using System;
using System.Collections.Generic;

public class Bank
{
    private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

    public void AddAccount(Account account)
    {
        if (!accounts.ContainsKey(account.AccountNumber))
        {
            accounts.Add(account.AccountNumber, account);
        }
        else
        {
            throw new ArgumentException("账户已存在");
        }
    }

    public Account GetAccount(string accountNumber)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            return accounts[accountNumber];
        }
        else
        {
            throw new KeyNotFoundException("账户未找到");
        }
    }

    // 索引器，用于通过账户号获取账户
    public Account this[string accountNumber]
    {
        get
        {
            return GetAccount(accountNumber);
        }
    }
}
