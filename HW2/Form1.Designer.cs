partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtAmount;
    private System.Windows.Forms.Button btnDeposit;
    private System.Windows.Forms.Button btnWithdraw;
    private System.Windows.Forms.Button btnCheckBalance;
    private System.Windows.Forms.Button btnShowDepositHistory;
    private System.Windows.Forms.Button btnLogout;

    private void InitializeComponent()
    {
        txtAmount = new TextBox();
        btnDeposit = new Button();
        btnWithdraw = new Button();
        btnCheckBalance = new Button();
        btnShowDepositHistory = new Button();
        btnLogout = new Button();
        label1 = new Label();
        SuspendLayout();
        // 
        // txtAmount
        // 
        txtAmount.Location = new Point(93, 21);
        txtAmount.Name = "txtAmount";
        txtAmount.Size = new Size(176, 23);
        txtAmount.TabIndex = 0;
        // 
        // btnDeposit
        // 
        btnDeposit.Location = new Point(64, 68);
        btnDeposit.Name = "btnDeposit";
        btnDeposit.Size = new Size(88, 32);
        btnDeposit.TabIndex = 1;
        btnDeposit.Text = "存款";
        btnDeposit.UseVisualStyleBackColor = true;
        btnDeposit.Click += btnDeposit_Click;
        // 
        // btnWithdraw
        // 
        btnWithdraw.Location = new Point(219, 68);
        btnWithdraw.Name = "btnWithdraw";
        btnWithdraw.Size = new Size(88, 32);
        btnWithdraw.TabIndex = 2;
        btnWithdraw.Text = "取款";
        btnWithdraw.UseVisualStyleBackColor = true;
        btnWithdraw.Click += btnWithdraw_Click;
        // 
        // btnCheckBalance
        // 
        btnCheckBalance.Location = new Point(64, 111);
        btnCheckBalance.Name = "btnCheckBalance";
        btnCheckBalance.Size = new Size(88, 32);
        btnCheckBalance.TabIndex = 3;
        btnCheckBalance.Text = "查询余额";
        btnCheckBalance.UseVisualStyleBackColor = true;
        btnCheckBalance.Click += btnCheckBalance_Click;
        // 
        // btnShowDepositHistory
        // 
        btnShowDepositHistory.Location = new Point(219, 111);
        btnShowDepositHistory.Name = "btnShowDepositHistory";
        btnShowDepositHistory.Size = new Size(88, 32);
        btnShowDepositHistory.TabIndex = 4;
        btnShowDepositHistory.Text = "存款记录";
        btnShowDepositHistory.UseVisualStyleBackColor = true;
        btnShowDepositHistory.Click += btnShowDepositHistory_Click;
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(94, 168);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(175, 32);
        btnLogout.TabIndex = 5;
        btnLogout.Text = "退出登录";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(32, 24);
        label1.Name = "label1";
        label1.Size = new Size(44, 17);
        label1.TabIndex = 6;
        label1.Text = "金额：";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(361, 234);
        Controls.Add(label1);
        Controls.Add(btnLogout);
        Controls.Add(btnShowDepositHistory);
        Controls.Add(btnCheckBalance);
        Controls.Add(btnWithdraw);
        Controls.Add(btnDeposit);
        Controls.Add(txtAmount);
        Name = "MainForm";
        Text = "账户操作界面";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label label1;
}

