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

        // 文件选择按钮点击事件
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

        // 文件分析方法
        private void AnalyzeFile(string filePath)
        {
            // 读取所有行
            var originalLines = File.ReadAllLines(filePath);

            // 统计原始行数和单词数
            int originalLineCount = originalLines.Length;
            int originalWordCount = CountWords(originalLines);

            // 显示原始统计结果
            lblOriginalLines.Text = $"原始行数: {originalLineCount}";
            lblOriginalWords.Text = $"原始单词数: {originalWordCount}";

            // 去掉空行和注释
            var formattedLines = originalLines
                .Where(line => !string.IsNullOrWhiteSpace(line)) // 删除空行
                .Where(line => !line.Trim().StartsWith("//"))    // 删除注释行
                .ToArray();

            // 统计格式化后的行数和单词数
            int formattedLineCount = formattedLines.Length;
            int formattedWordCount = CountWords(formattedLines);

            // 显示格式化后的统计结果
            lblFormattedLines.Text = $"格式化后行数: {formattedLineCount}";
            lblFormattedWords.Text = $"格式化后单词数: {formattedWordCount}";

            // 统计单词出现次数
            var wordOccurrences = CountWordOccurrences(formattedLines);

            // 显示单词出现次数列表
            lstWordOccurrences.Items.Clear();
            foreach (var word in wordOccurrences)
            {
                var listItem = new ListViewItem(new[] { word.Key, word.Value.ToString() });
                lstWordOccurrences.Items.Add(listItem);
            }
        }

        // 统计单词总数
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

        // 统计每个单词出现的次数
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
