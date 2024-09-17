namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ����ȫ�ֱ���
        private int correctAnswer;      // �洢��ȷ��
        private int questionCount = 1;  // ��ǰ����
        private int totalQuestions = 10; // ������
        private int score = 0;          // ��ǰ�÷�
        private int countDown = 0;      // ����ʱ
        private int timeLimit = 20;     // ÿ���ʱ������Ϊ20��

        public Form1()
        {
            InitializeComponent();
            InitializeQuiz();           // ��ʼ�����������ɵ�һ����
            timer1.Interval = 1000; // ����Ϊÿ�봥��һ��
            timer1.Tick += new EventHandler(this.timer1_Tick); // ֻ��һ��
            timer1.Start(); // ȷ��ֻ����һ��
        }

        // ��ʼ�����������ɵ�һ����
        private void InitializeQuiz()
        {
            score = 0;              // ��ʼ���÷�Ϊ0
            questionCount = 1;       // ��ʼ�����Ϊ1
            GenerateQuestion();      // ���ɵ�һ����
            UpdateUI();              // �����û����棬��ʾ��ʼ״̬
        }

        // ���������ѧ����
        private void GenerateQuestion()
        {
            Random rand = new Random();
            int num1 = rand.Next(1, 1001);
            int num2 = rand.Next(1, 1001);
            bool isAddition = rand.Next(0, 2) == 0; // ��������Ǽӷ����Ǽ���

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

            // ���µ�ǰ��Ŀ���
            Questionnum.Text = questionCount.ToString();
            ResetTimer(); // ���¿�ʼ��ʱ
        }

        // �ύ�𰸰�ť�¼�
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            // �ж��û������Ƿ�Ϊ��Ч����
            if (int.TryParse(AnswerBox.Text, out int userAnswer))
            {
                // �����Ƿ���ȷ
                if (userAnswer == correctAnswer)
                {
                    Feedback.Text = "�ش���ȷ��";
                    Feedback.ForeColor = Color.Green;
                    score += Math.Max(20 - countDown, 1); // ʣ��ʱ��Խ�࣬�÷�Խ�ߣ�����1��
                }
                else
                {
                    Feedback.Text = "�ش����";
                    Feedback.ForeColor = Color.Red;
                }
            }
            else
            {
                Feedback.Text = "��������Ч������";
                Feedback.ForeColor = Color.Red;
            }

            // ���·�����ʾ��ȷ��������Ϊ��
            scoreLabel.Text = score >= 0 ? score.ToString() : "0";

            // ������һ����Ŀ���������
            if (questionCount < totalQuestions)
            {
                questionCount++;
                GenerateQuestion(); // ������һ����
            }
            else
            {
                EndQuiz(); // ��Ŀ���꣬��������
            }

            // ��մ������
            AnswerBox.Text = string.Empty;
        }

        // ��ʱ���¼���ÿ�봥��һ��
        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown += 1;
            // ����ʣ��ʱ��
            int remainingTime = timeLimit - countDown;
            // ����ʣ��ʱ����ʾ
            if (remainingTime >= 0)
            {
                TimeLabel.Text = $"{remainingTime}s";
            }
            else
            {
                // ʱ�䵽������ʱ
                Feedback.Text = "��ʱ��";
                Feedback.ForeColor = Color.Red;

                // ����Ƿ�����һ����
                if (questionCount < totalQuestions)
                {
                    questionCount++;
                    GenerateQuestion(); // ������һ��
                }
                else
                {
                    EndQuiz(); // ��Ŀ���꣬��������
                }
            }
        }

        // ���ü�ʱ��
        private void ResetTimer()
        {
            countDown = 0;
            TimeLabel.Text = $"{timeLimit}s";
        }

        // ����UI����
        private void UpdateUI()
        {
            scoreLabel.Text = score.ToString(); // ���·���
            Questionnum.Text = questionCount.ToString(); // �������
            Feedback.Text = ""; // ���������Ϣ
            ResetTimer(); // ���ü�ʱ��
        }

        // �������Բ���ʾ����
        private void EndQuiz()
        {
            timer1.Stop(); // ֹͣ��ʱ��
            MessageBox.Show($"���Խ�����������յ÷��ǣ�{score}");
        }

        // ��ֹ����ť�¼�
        private void EndQuizBtn_Click(object sender, EventArgs e)
        {
            EndQuiz(); // �û���ֹ����������������
        }
    }
}
