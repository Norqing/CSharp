namespace WebCrawler
{
    partial class Crawl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crawl));
            txtKeywordInput = new TextBox();
            btnSearch = new Button();
            lstUrls = new ListBox();
            radioBaidu = new RadioButton();
            radioBing = new RadioButton();
            radioGoogle = new RadioButton();
            label1 = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // txtKeywordInput
            // 
            txtKeywordInput.Location = new Point(311, 65);
            txtKeywordInput.Multiline = true;
            txtKeywordInput.Name = "txtKeywordInput";
            txtKeywordInput.Size = new Size(278, 47);
            txtKeywordInput.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(679, 70);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 42);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstUrls
            // 
            lstUrls.FormattingEnabled = true;
            lstUrls.Location = new Point(83, 240);
            lstUrls.Name = "lstUrls";
            lstUrls.Size = new Size(727, 164);
            lstUrls.TabIndex = 2;
            // 
            // radioBaidu
            // 
            radioBaidu.AutoSize = true;
            radioBaidu.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            radioBaidu.Location = new Point(187, 172);
            radioBaidu.Name = "radioBaidu";
            radioBaidu.Size = new Size(87, 31);
            radioBaidu.TabIndex = 3;
            radioBaidu.TabStop = true;
            radioBaidu.Text = "Baidu";
            radioBaidu.UseVisualStyleBackColor = true;
            // 
            // radioBing
            // 
            radioBing.AutoSize = true;
            radioBing.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            radioBing.Location = new Point(395, 172);
            radioBing.Name = "radioBing";
            radioBing.Size = new Size(76, 31);
            radioBing.TabIndex = 4;
            radioBing.TabStop = true;
            radioBing.Text = "Bing";
            radioBing.UseVisualStyleBackColor = true;
            // 
            // radioGoogle
            // 
            radioGoogle.AutoSize = true;
            radioGoogle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            radioGoogle.Location = new Point(585, 172);
            radioGoogle.Name = "radioGoogle";
            radioGoogle.Size = new Size(103, 31);
            radioGoogle.TabIndex = 5;
            radioGoogle.TabStop = true;
            radioGoogle.Text = "Google";
            radioGoogle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("宋体", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 75);
            label1.Name = "label1";
            label1.Size = new Size(194, 28);
            label1.TabIndex = 6;
            label1.Text = "请输入关键词:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(83, 456);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(727, 23);
            progressBar.TabIndex = 7;
            // 
            // Crawl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(929, 576);
            Controls.Add(progressBar);
            Controls.Add(label1);
            Controls.Add(radioGoogle);
            Controls.Add(radioBing);
            Controls.Add(radioBaidu);
            Controls.Add(lstUrls);
            Controls.Add(btnSearch);
            Controls.Add(txtKeywordInput);
            Name = "Crawl";
            Text = "多线程爬虫程序";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtKeywordInput;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstUrls;
        private System.Windows.Forms.RadioButton radioBaidu;
        private System.Windows.Forms.RadioButton radioBing;
        private System.Windows.Forms.RadioButton radioGoogle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
