using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    private Bank bank; // 用于管理账户的银行对象

    public LoginForm(Bank bank)
    {
        InitializeComponent();
        this.bank = bank; // 传入银行对象用于账户管理
    }

    // 登录按钮点击事件
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string accountNumber = txtAccountNumber.Text;
        string password = txtPassword.Text;

        try
        {
            CreditAccount account = (CreditAccount)bank.GetAccount(accountNumber);

            if (account.VerifyPassword(password))
            {
                MessageBox.Show("登录成功！");
                MainForm mainForm = new MainForm(bank, account);
                mainForm.Show();
                this.Hide(); // 隐藏登录窗体
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入。");
            }
        }
        catch (KeyNotFoundException)
        {
            MessageBox.Show("账户未找到，请检查账户号。");
        }
        catch (InvalidCastException)
        {
            MessageBox.Show("该账户不是信用账户。");
        }
    }

    // 注册按钮点击事件
    private void btnRegister_Click(object sender, EventArgs e)
    {
        string accountNumber = txtAccountNumber.Text;
        string password = txtPassword.Text;

        if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("账号或密码不能为空。");
            return;
        }

        try
        {
            CreditAccount newAccount = new CreditAccount(accountNumber, password, 0m);
            bank.AddAccount(newAccount);
            MessageBox.Show("注册成功！现在可以登录了。");
        }
        catch (ArgumentException)
        {
            MessageBox.Show("该账户已存在，请选择其他账号。");
        }
    }
}
