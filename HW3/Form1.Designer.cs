namespace Course3
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblOriginalLines = new System.Windows.Forms.Label();
            this.lblOriginalWords = new System.Windows.Forms.Label();
            this.lblFormattedLines = new System.Windows.Forms.Label();
            this.lblFormattedWords = new System.Windows.Forms.Label();
            this.lstWordOccurrences = new System.Windows.Forms.ListView();
            this.columnHeaderWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(100, 30);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblOriginalLines
            // 
            this.lblOriginalLines.AutoSize = true;
            this.lblOriginalLines.Location = new System.Drawing.Point(12, 60);
            this.lblOriginalLines.Name = "lblOriginalLines";
            this.lblOriginalLines.Size = new System.Drawing.Size(83, 15);
            this.lblOriginalLines.TabIndex = 1;
            this.lblOriginalLines.Text = "原始行数: 0";
            // 
            // lblOriginalWords
            // 
            this.lblOriginalWords.AutoSize = true;
            this.lblOriginalWords.Location = new System.Drawing.Point(12, 90);
            this.lblOriginalWords.Name = "lblOriginalWords";
            this.lblOriginalWords.Size = new System.Drawing.Size(98, 15);
            this.lblOriginalWords.TabIndex = 2;
            this.lblOriginalWords.Text = "原始单词数: 0";
            // 
            // lblFormattedLines
            // 
            this.lblFormattedLines.AutoSize = true;
            this.lblFormattedLines.Location = new System.Drawing.Point(12, 120);
            this.lblFormattedLines.Name = "lblFormattedLines";
            this.lblFormattedLines.Size = new System.Drawing.Size(113, 15);
            this.lblFormattedLines.TabIndex = 3;
            this.lblFormattedLines.Text = "格式化后行数: 0";
            // 
            // lblFormattedWords
            // 
            this.lblFormattedWords.AutoSize = true;
            this.lblFormattedWords.Location = new System.Drawing.Point(12, 150);
            this.lblFormattedWords.Name = "lblFormattedWords";
            this.lblFormattedWords.Size = new System.Drawing.Size(128, 15);
            this.lblFormattedWords.TabIndex = 4;
            this.lblFormattedWords.Text = "格式化后单词数: 0";
            // 
            // lstWordOccurrences
            // 
            this.lstWordOccurrences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWord,
            this.columnHeaderCount});
            this.lstWordOccurrences.HideSelection = false;
            this.lstWordOccurrences.Location = new System.Drawing.Point(12, 180);
            this.lstWordOccurrences.Name = "lstWordOccurrences";
            this.lstWordOccurrences.Size = new System.Drawing.Size(400, 200);
            this.lstWordOccurrences.TabIndex = 5;
            this.lstWordOccurrences.UseCompatibleStateImageBehavior = false;
            this.lstWordOccurrences.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderWord
            // 
            this.columnHeaderWord.Text = "单词";
            this.columnHeaderWord.Width = 200;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "次数";
            this.columnHeaderCount.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 400);
            this.Controls.Add(this.lstWordOccurrences);
            this.Controls.Add(this.lblFormattedWords);
            this.Controls.Add(this.lblFormattedLines);
            this.Controls.Add(this.lblOriginalWords);
            this.Controls.Add(this.lblOriginalLines);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "Form1";
            this.Text = "C# 源文件分析器";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblOriginalLines;
        private System.Windows.Forms.Label lblOriginalWords;
        private System.Windows.Forms.Label lblFormattedLines;
        private System.Windows.Forms.Label lblFormattedWords;
        private System.Windows.Forms.ListView lstWordOccurrences;
        private System.Windows.Forms.ColumnHeader columnHeaderWord;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
    }
}
