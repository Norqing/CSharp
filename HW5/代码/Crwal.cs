using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace WebCrawler
{
    public partial class Crawl : Form
    {
        private static readonly HttpClient client = new HttpClient() { Timeout = Timeout.InfiniteTimeSpan }; // ���� HttpClient ʵ�����Ƴ�Ĭ�ϳ�ʱ����

        public Crawl()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordInput.Text;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("������ؼ���");
                return;
            }

            // �ж��û�ѡ�����������
            string searchEngine = GetSelectedSearchEngine();
            if (searchEngine == null)
            {
                MessageBox.Show("��ѡ����������");
                return;
            }

            // ����ϴ��������
            lstUrls.Items.Clear();

            try
            {
                progressBar.Value = 0;
                // �����첽�������
                var results = await CrawlAsync(keyword, searchEngine);

                // ��ʾ��ȡ��URL�����Ӧ�ĵ绰����
                foreach (var result in results)
                {
                    lstUrls.Items.Add($"URL: {result.Item1}, �绰����: {result.Item2}");
                }

                MessageBox.Show("������ɣ�");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���������г��ִ���: {ex.Message}");
            }
        }

        // ��ȡѡ�е���������
        private string GetSelectedSearchEngine()
        {
            if (radioBaidu.Checked)
                return "baidu";
            if (radioBing.Checked)
                return "bing";
            if (radioGoogle.Checked)
                return "google";
            return null;
        }

        // �첽���淽��
        private async Task<List<Tuple<string, string>>> CrawlAsync(string keyword, string searchEngine)
        {
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();

            // �����������������URL
            string searchUrl = GetSearchUrl(keyword, searchEngine);
            if (string.IsNullOrWhiteSpace(searchUrl))
                return results;

            try
            {
                // �������󲢻�ȡ��Ӧ
                var response = await client.GetStringAsync(searchUrl);
                progressBar.Value = 20;
                lstUrls.Items.Add($"��ʼ������");

                // ��ȡ��ҳ�е�URL
                var urls = ExtractUrls(response);
                progressBar.Value = 40;
                lstUrls.Items.Add($"������ȡURL��");
                // ʹ�ò���������ȡÿ��URL�ĵ绰����
                var tasks = urls.Select(async url =>
                {
                    try
                    {
                        var pageContent = await client.GetStringAsync(url);
                        var phoneNumbers = ExtractPhoneNumbers(pageContent);
                        return phoneNumbers.Select(phone => Tuple.Create(url, phone));
                    }
                    catch (HttpRequestException)
                    {
                        // ���������쳣��������������URL
                        return Enumerable.Empty<Tuple<string, string>>();
                    }
                });

                var phoneResults = await Task.WhenAll(tasks);
                results = phoneResults.SelectMany(r => r).ToList();
                progressBar.Value = 80;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"������������ʱ����: {ex.Message}");
            }

            progressBar.Value = 100;
            return results;
        }

        // �����û�ѡ����������湹������URL
        private string GetSearchUrl(string keyword, string searchEngine)
        {
            switch (searchEngine)
            {
                case "baidu":
                    return $"https://www.baidu.com/s?wd={keyword}";
                case "bing":
                    return $"https://www.bing.com/search?q={keyword}";
                case "google":
                    return $"https://www.google.com/search?q={keyword}";
                default:
                    return null;
            }
        }

        // ��ȡURL�ķ���
        private List<string> ExtractUrls(string html)
        {
            List<string> urls = new List<string>();

            // ������ʽ��ȡURL
            string pattern = @"http[s]?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            MatchCollection matches = Regex.Matches(html, pattern);

            foreach (Match match in matches)
            {
                urls.Add(match.Value);
            }

            return urls.Distinct().ToList();
        }

        // ��ȡ�绰����ķ���
        private List<string> ExtractPhoneNumbers(string html)
        {
            List<string> phoneNumbers = new List<string>();

            // ������ʽ��ȡ�绰����
            string pattern = @"\b\d{3}[-.]?\d{3}[-.]?\d{4}\b"; // �����������ĸ�ʽ���ɸ����������
            MatchCollection matches = Regex.Matches(html, pattern);

            foreach (Match match in matches)
            {
                phoneNumbers.Add(match.Value);
            }

            return phoneNumbers.Distinct().Take(100).ToList();
        }

     }
}
