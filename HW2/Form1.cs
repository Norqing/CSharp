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

    // �¼�����������ȡ�����10000Ԫʱ����
    private void Atm_BigMoneyFetched(object sender, BigMoneyEventArgs e)
    {
        MessageBox.Show($"���棺ȡ�������10000Ԫ�� �˻��ţ�{e.AccountNumber}, ȡ���{e.Amount}");
    }

    private void btnDeposit_Click(object sender, EventArgs e)
    {
        try
        {
            string accountNumber = loggedInAccount.AccountNumber;
            decimal amount = decimal.Parse(txtAmount.Text);
            atm.Deposit(accountNumber, amount);
            MessageBox.Show($"���ɹ����µ���{atm.CheckBalance(accountNumber)}");
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
            MessageBox.Show($"ȡ��ɹ����µ���{atm.CheckBalance(accountNumber)}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnCheckBalance_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"��ǰ��{atm.CheckBalance(loggedInAccount.AccountNumber)}");
    }

    private void btnShowDepositHistory_Click(object sender, EventArgs e)
    {
        if (loggedInAccount.DepositHistory.Count > 0)
        {
            string history = "�����ʷ��\n";
            foreach (var entry in loggedInAccount.DepositHistory)
            {
                history += $"ʱ��: {entry.time}, ���: {entry.amount}\n";
            }
            MessageBox.Show(history);
        }
        else
        {
            MessageBox.Show("�޴���¼��");
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        MessageBox.Show("���˳���¼��");
        this.Close();
        Application.Restart();
    }
}
