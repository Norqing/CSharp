partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtAccountNumber;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnRegister;

    private void InitializeComponent()
    {
        txtAccountNumber = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        btnRegister = new Button();
        label1 = new Label();
        label2 = new Label();
        SuspendLayout();
        // 
        // txtAccountNumber
        // 
        txtAccountNumber.Location = new Point(91, 22);
        txtAccountNumber.Name = "txtAccountNumber";
        txtAccountNumber.Size = new Size(200, 23);
        txtAccountNumber.TabIndex = 0;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(91, 71);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(200, 23);
        txtPassword.TabIndex = 1;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(72, 116);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(100, 30);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "登录";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(218, 116);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(100, 30);
        btnRegister.TabIndex = 3;
        btnRegister.Text = "注册";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += btnRegister_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(42, 25);
        label1.Name = "label1";
        label1.Size = new Size(44, 17);
        label1.TabIndex = 4;
        label1.Text = "账号：";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(42, 71);
        label2.Name = "label2";
        label2.Size = new Size(44, 17);
        label2.TabIndex = 5;
        label2.Text = "密码：";
        // 
        // LoginForm
        // 
        ClientSize = new Size(363, 200);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnRegister);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(txtAccountNumber);
        Name = "LoginForm";
        Text = "登录";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label label1;
    private Label label2;
}
