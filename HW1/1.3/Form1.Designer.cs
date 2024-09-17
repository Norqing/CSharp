namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Submitbtn = new Button();
            EndQuizBtn = new Button();
            questionnumber = new Label();
            NowTime = new Label();
            AnswerBox = new TextBox();
            scoreLabel = new Label();
            TimeLabel = new Label();
            Question = new Label();
            Questionnum = new Label();
            Feedback = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // Submitbtn
            // 
            Submitbtn.Location = new Point(284, 372);
            Submitbtn.Name = "Submitbtn";
            Submitbtn.Size = new Size(112, 54);
            Submitbtn.TabIndex = 0;
            Submitbtn.Text = "提交";
            Submitbtn.UseVisualStyleBackColor = true;
            Submitbtn.Click += Submitbtn_Click;
            // 
            // EndQuizBtn
            // 
            EndQuizBtn.Location = new Point(471, 372);
            EndQuizBtn.Name = "EndQuizBtn";
            EndQuizBtn.Size = new Size(112, 54);
            EndQuizBtn.TabIndex = 11;
            EndQuizBtn.Text = "终止作答";
            EndQuizBtn.UseVisualStyleBackColor = true;
            EndQuizBtn.Click += EndQuizBtn_Click;
            // 
            // questionnumber
            // 
            questionnumber.AutoSize = true;
            questionnumber.Location = new Point(459, 43);
            questionnumber.Name = "questionnumber";
            questionnumber.Size = new Size(100, 24);
            questionnumber.TabIndex = 1;
            questionnumber.Text = "当前题数：";
            // 
            // NowTime
            // 
            NowTime.AutoSize = true;
            NowTime.CausesValidation = false;
            NowTime.Location = new Point(459, 101);
            NowTime.Name = "NowTime";
            NowTime.Size = new Size(100, 24);
            NowTime.TabIndex = 1;
            NowTime.Text = "当题用时：";
            // 
            // AnswerBox
            // 
            AnswerBox.Location = new Point(265, 307);
            AnswerBox.Name = "AnswerBox";
            AnswerBox.Size = new Size(150, 30);
            AnswerBox.TabIndex = 5;
            // 
            // scoreLabel
            // 
            scoreLabel.Font = new Font("宋体", 24F, FontStyle.Regular, GraphicsUnit.Point);
            scoreLabel.Location = new Point(284, 61);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(149, 66);
            scoreLabel.TabIndex = 6;
            scoreLabel.Text = "0";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Location = new Point(586, 101);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(40, 24);
            TimeLabel.TabIndex = 7;
            TimeLabel.Text = "20s";
            // 
            // Question
            // 
            Question.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Question.Font = new Font("宋体", 26F, FontStyle.Regular, GraphicsUnit.Point);
            Question.Location = new Point(122, 190);
            Question.Name = "Question";
            Question.Size = new Size(377, 90);
            Question.TabIndex = 8;
            Question.Text = "1+1=";
            // 
            // Questionnum
            // 
            Questionnum.AutoSize = true;
            Questionnum.Location = new Point(605, 43);
            Questionnum.Name = "Questionnum";
            Questionnum.Size = new Size(21, 24);
            Questionnum.TabIndex = 9;
            Questionnum.Text = "1";
            // 
            // Feedback
            // 
            Feedback.AutoSize = true;
            Feedback.Font = new Font("宋体", 22F, FontStyle.Regular, GraphicsUnit.Point);
            Feedback.Location = new Point(522, 209);
            Feedback.Name = "Feedback";
            Feedback.Size = new Size(0, 44);
            Feedback.TabIndex = 10;
            // 
            // timer1
            // 
            timer1.Enabled = false;
            timer1.Interval = 1000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("宋体", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(260, 48);
            label1.TabIndex = 12;
            label1.Text = "您的得分：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 473);
            Controls.Add(label1);
            Controls.Add(Feedback);
            Controls.Add(Questionnum);
            Controls.Add(Question);
            Controls.Add(TimeLabel);
            Controls.Add(scoreLabel);
            Controls.Add(AnswerBox);
            Controls.Add(NowTime);
            Controls.Add(questionnumber);
            Controls.Add(Submitbtn);
            Controls.Add(EndQuizBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Submitbtn;
        private Button EndQuizBtn; // 添加终止按钮
        private Label questionnumber;
        private Label NowTime;
        private TextBox AnswerBox;
        private Label scoreLabel;
        private Label TimeLabel;
        private Label Question;
        private Label Questionnum;
        private Label Feedback;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
    }
}
