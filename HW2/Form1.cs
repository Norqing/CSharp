using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private Bank bank;
    private ATM atm;
    private CreditAccount loggedInAccount;
    private bool isLoggedIn = false;

    public MainForm(Bank bank, CreditAccount account)
    {
        InitializeComponent();
        this.bank = bank;
        this.loggedInAccount = account;
        atm = new ATM(bank);
        atm.BigMoneyFetched += Atm_BigMoneyFetched;
        isLoggedIn = true;
    }

    // 事件处理函数：当取款大于10000元时触发
    private void Atm_BigMoneyFetched(object sender, BigMoneyEventArgs e)
    {
        MessageBox.Show($"警告：取款金额大于10000元！ 账户号：{e.AccountNumber}, 取款金额：{e.Amount}");
    }

    private void btnDeposit_Click(object sender, EventArgs e)
    {
        try
        {
            string accountNumber = loggedInAccount.AccountNumber;
            decimal amount = decimal.Parse(txtAmount.Text);
            atm.Deposit(accountNumber, amount);
            MessageBox.Show($"存款成功！新的余额：{atm.CheckBalance(accountNumber)}");
        }
        catch (BadCashException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnWithdraw_Click(object sender, EventArgs e)
    {
        try
        {
            string accountNumber = loggedInAccount.AccountNumber;
            decimal amount = decimal.Parse(txtAmount.Text);
            atm.Withdraw(accountNumber, amount);
            MessageBox.Show($"取款成功！新的余额：{atm.CheckBalance(accountNumber)}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnCheckBalance_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"当前余额：{atm.CheckBalance(loggedInAccount.AccountNumber)}");
    }

    private void btnShowDepositHistory_Click(object sender, EventArgs e)
    {
        if (loggedInAccount.DepositHistory.Count > 0)
        {
            string history = "存款历史：\n";
            foreach (var entry in loggedInAccount.DepositHistory)
            {
                history += $"时间: {entry.time}, 金额: {entry.amount}\n";
            }
            MessageBox.Show(history);
        }
        else
        {
            MessageBox.Show("无存款记录。");
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        MessageBox.Show("已退出登录。");
        this.Close();
        Application.Restart();
    }
}
