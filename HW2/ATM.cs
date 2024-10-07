using System;

public class ATM
{
    private Bank bank;
    private Random random = new Random();

    // 事件：当取款金额超过10000时触发
    public event EventHandler<BigMoneyEventArgs> BigMoneyFetched;

    public ATM(Bank bank)
    {
        this.bank = bank;
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        Account account = bank.GetAccount(accountNumber);

        // 模拟30%几率发生坏钞异常
        if (random.Next(1, 101) <= 30)  // 随机生成1到100的数字，小于等于30表示有坏钞
        {
            throw new BadCashException();  // 抛出坏钞异常
        }

        account.Deposit(amount);
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        Account account = bank.GetAccount(accountNumber);
        account.Withdraw(amount);

        // 如果取款金额超过10000，触发事件
        if (amount > 10000)
        {
            OnBigMoneyFetched(new BigMoneyEventArgs(accountNumber, amount));
        }
    }

    protected virtual void OnBigMoneyFetched(BigMoneyEventArgs e)
    {
        if (BigMoneyFetched != null)
        {
            BigMoneyFetched(this, e);
        }
    }

    public decimal CheckBalance(string accountNumber)
    {
        Account account = bank.GetAccount(accountNumber);
        return account.Balance;
    }
}
