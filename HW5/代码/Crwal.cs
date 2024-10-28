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
        private static readonly HttpClient client = new HttpClient() { Timeout = Timeout.InfiniteTimeSpan }; // 单例 HttpClient 实例，移除默认超时限制

        public Crawl()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeywordInput.Text;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("请输入关键词");
                return;
            }

            // 判断用户选择的搜索引擎
            string searchEngine = GetSelectedSearchEngine();
            if (searchEngine == null)
            {
                MessageBox.Show("请选择搜索引擎");
                return;
            }

            // 清空上次搜索结果
            lstUrls.Items.Clear();

            try
            {
                progressBar.Value = 0;
                // 调用异步爬虫程序
                var results = await CrawlAsync(keyword, searchEngine);

                // 显示爬取的URL及其对应的电话号码
                foreach (var result in results)
                {
                    lstUrls.Items.Add($"URL: {result.Item1}, 电话号码: {result.Item2}");
                }

                MessageBox.Show("搜索完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"搜索过程中出现错误: {ex.Message}");
            }
        }

        // 获取选中的搜索引擎
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

        // 异步爬虫方法
        private async Task<List<Tuple<string, string>>> CrawlAsync(string keyword, string searchEngine)
        {
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();

            // 构造搜索引擎的搜索URL
            string searchUrl = GetSearchUrl(keyword, searchEngine);
            if (string.IsNullOrWhiteSpace(searchUrl))
                return results;

            try
            {
                // 发起请求并获取响应
                var response = await client.GetStringAsync(searchUrl);
                progressBar.Value = 20;
                lstUrls.Items.Add($"开始搜索！");

                // 提取网页中的URL
                var urls = ExtractUrls(response);
                progressBar.Value = 40;
                lstUrls.Items.Add($"正在提取URL！");
                // 使用并行任务爬取每个URL的电话号码
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
                        // 忽略请求异常，继续处理其他URL
                        return Enumerable.Empty<Tuple<string, string>>();
                    }
                });

                var phoneResults = await Task.WhenAll(tasks);
                results = phoneResults.SelectMany(r => r).ToList();
                progressBar.Value = 80;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"请求搜索引擎时出错: {ex.Message}");
            }

            progressBar.Value = 100;
            return results;
        }

        // 根据用户选择的搜索引擎构造搜索URL
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

        // 提取URL的方法
        private List<string> ExtractUrls(string html)
        {
            List<string> urls = new List<string>();

            // 正则表达式提取URL
            string pattern = @"http[s]?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            MatchCollection matches = Regex.Matches(html, pattern);

            foreach (Match match in matches)
            {
                urls.Add(match.Value);
            }

            return urls.Distinct().ToList();
        }

        // 提取电话号码的方法
        private List<string> ExtractPhoneNumbers(string html)
        {
            List<string> phoneNumbers = new List<string>();

            // 正则表达式提取电话号码
            string pattern = @"\b\d{3}[-.]?\d{3}[-.]?\d{4}\b"; // 适用于美国的格式，可根据需求更改
            MatchCollection matches = Regex.Matches(html, pattern);

            foreach (Match match in matches)
            {
                phoneNumbers.Add(match.Value);
            }

            return phoneNumbers.Distinct().Take(100).ToList();
        }

     }
}
