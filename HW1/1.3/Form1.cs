namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // 定义全局变量
        private int correctAnswer;      // 存储正确答案
        private int questionCount = 1;  // 当前题数
        private int totalQuestions = 10; // 总题数
        private int score = 0;          // 当前得分
        private int countDown = 0;      // 倒计时
        private int timeLimit = 20;     // 每题的时间上限为20秒

        public Form1()
        {
            InitializeComponent();
            InitializeQuiz();           // 初始化参数并生成第一道题
            timer1.Interval = 1000; // 设置为每秒触发一次
            timer1.Tick += new EventHandler(this.timer1_Tick); // 只绑定一次
            timer1.Start(); // 确保只启动一次
        }

        // 初始化参数并生成第一道题
        private void InitializeQuiz()
        {
            score = 0;              // 初始化得分为0
            questionCount = 1;       // 初始化题号为1
            GenerateQuestion();      // 生成第一道题
            UpdateUI();              // 更新用户界面，显示初始状态
        }

        // 生成随机数学问题
        private void GenerateQuestion()
        {
            Random rand = new Random();
            int num1 = rand.Next(1, 1001);
            int num2 = rand.Next(1, 1001);
            bool isAddition = rand.Next(0, 2) == 0; // 随机决定是加法还是减法

            if (isAddition)
            {
                Question.Text = $"{num1} + {num2} = ?";
                correctAnswer = num1 + num2;
            }
            else
            {
                Question.Text = $"{num1} - {num2} = ?";
                correctAnswer = num1 - num2;
            }

            // 更新当前题目编号
            Questionnum.Text = questionCount.ToString();
            ResetTimer(); // 重新开始计时
        }

        // 提交答案按钮事件
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            // 判断用户输入是否为有效数字
            if (int.TryParse(AnswerBox.Text, out int userAnswer))
            {
                // 检查答案是否正确
                if (userAnswer == correctAnswer)
                {
                    Feedback.Text = "回答正确！";
                    Feedback.ForeColor = Color.Green;
                    score += Math.Max(20 - countDown, 1); // 剩余时间越多，得分越高，最少1分
                }
                else
                {
                    Feedback.Text = "回答错误！";
                    Feedback.ForeColor = Color.Red;
                }
            }
            else
            {
                Feedback.Text = "请输入有效的数字";
                Feedback.ForeColor = Color.Red;
            }

            // 更新分数显示，确保分数不为负
            scoreLabel.Text = score >= 0 ? score.ToString() : "0";

            // 处理下一道题目或结束测试
            if (questionCount < totalQuestions)
            {
                questionCount++;
                GenerateQuestion(); // 生成下一道题
            }
            else
            {
                EndQuiz(); // 题目做完，结束测试
            }

            // 清空答案输入框
            AnswerBox.Text = string.Empty;
        }

        // 计时器事件，每秒触发一次
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown += 1;
            // 计算剩余时间
            int remainingTime = timeLimit - countDown;
            // 更新剩余时间显示
            if (remainingTime >= 0)
            {
                TimeLabel.Text = $"{remainingTime}s";
            }
            else
            {
                // 时间到，处理超时
                Feedback.Text = "超时！";
                Feedback.ForeColor = Color.Red;

                // 检查是否还有下一道题
                if (questionCount < totalQuestions)
                {
                    questionCount++;
                    GenerateQuestion(); // 生成下一题
                }
                else
                {
                    EndQuiz(); // 题目做完，结束测试
                }
            }
        }

        // 重置计时器
        private void ResetTimer()
        {
            countDown = 0;
            TimeLabel.Text = $"{timeLimit}s";
        }

        // 更新UI界面
        private void UpdateUI()
        {
            scoreLabel.Text = score.ToString(); // 更新分数
            Questionnum.Text = questionCount.ToString(); // 更新题号
            Feedback.Text = ""; // 清除反馈信息
            ResetTimer(); // 重置计时器
        }

        // 结束测试并显示分数
        private void EndQuiz()
        {
            timer1.Stop(); // 停止计时器
            MessageBox.Show($"测试结束！你的最终得分是：{score}");
        }

        // 终止作答按钮事件
        private void EndQuizBtn_Click(object sender, EventArgs e)
        {
            EndQuiz(); // 用户终止作答，立即结束测试
        }
    }
}
