using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Course3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // �ļ�ѡ��ť����¼�
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C# Source Files (*.cs)|*.cs";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                AnalyzeFile(filePath);
            }
        }

        // �ļ���������
        private void AnalyzeFile(string filePath)
        {
            // ��ȡ������
            var originalLines = File.ReadAllLines(filePath);

            // ͳ��ԭʼ�����͵�����
            int originalLineCount = originalLines.Length;
            int originalWordCount = CountWords(originalLines);

            // ��ʾԭʼͳ�ƽ��
            lblOriginalLines.Text = $"ԭʼ����: {originalLineCount}";
            lblOriginalWords.Text = $"ԭʼ������: {originalWordCount}";

            // ȥ�����к�ע��
            var formattedLines = originalLines
                .Where(line => !string.IsNullOrWhiteSpace(line)) // ɾ������
                .Where(line => !line.Trim().StartsWith("//"))    // ɾ��ע����
                .ToArray();

            // ͳ�Ƹ�ʽ����������͵�����
            int formattedLineCount = formattedLines.Length;
            int formattedWordCount = CountWords(formattedLines);

            // ��ʾ��ʽ�����ͳ�ƽ��
            lblFormattedLines.Text = $"��ʽ��������: {formattedLineCount}";
            lblFormattedWords.Text = $"��ʽ���󵥴���: {formattedWordCount}";

            // ͳ�Ƶ��ʳ��ִ���
            var wordOccurrences = CountWordOccurrences(formattedLines);

            // ��ʾ���ʳ��ִ����б�
            lstWordOccurrences.Items.Clear();
            foreach (var word in wordOccurrences)
            {
                var listItem = new ListViewItem(new[] { word.Key, word.Value.ToString() });
                lstWordOccurrences.Items.Add(listItem);
            }
        }

        // ͳ�Ƶ�������
        private int CountWords(string[] lines)
        {
            int wordCount = 0;
            foreach (var line in lines)
            {
                var words = Regex.Matches(line, @"\b\w+\b");
                wordCount += words.Count;
            }
            return wordCount;
        }

        // ͳ��ÿ�����ʳ��ֵĴ���
        private Dictionary<string, int> CountWordOccurrences(string[] lines)
        {
            var wordDictionary = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var words = Regex.Matches(line, @"\b\w+\b").Cast<Match>().Select(m => m.Value.ToLower());

                foreach (var word in words)
                {
                    if (wordDictionary.ContainsKey(word))
                    {
                        wordDictionary[word]++;
                    }
                    else
                    {
                        wordDictionary[word] = 1;
                    }
                }
            }

            return wordDictionary;
        }
    }
}
