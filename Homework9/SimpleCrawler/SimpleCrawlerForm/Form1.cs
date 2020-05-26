using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrawlerForm
{
    public partial class Form1 : Form
    {
        SimpleCrawler.SimpleCrawler simpleCrawler = new SimpleCrawler.SimpleCrawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            simpleCrawler.PageDownloaded += Crawler_PageDownloaded;
            simpleCrawler.CrawlerStopped += Crawler_CrawlerStopped;
        }


        private void Crawler_CrawlerStopped(SimpleCrawler.SimpleCrawler obj)
        {
            Action action = () => lblInfo.Text = "爬虫已停止";
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void Crawler_PageDownloaded(SimpleCrawler.SimpleCrawler crawler, string url, string info)
        {
            var pageInfo = new { Index = bdsUrls.Count + 1, URL = url, Status = info };
            Action action = () => { bdsUrls.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bdsUrls.Clear();
            simpleCrawler.StartURL = txtStartUrl.Text;

            Match match = Regex.Match(simpleCrawler.StartURL, SimpleCrawler.SimpleCrawler.urlParseRegex);
            if (match.Length == 0)
                return;
            string host = match.Groups["host"].Value;
            simpleCrawler.HostFilter = "^" + host + "$";
            simpleCrawler.FileFilter = ".html?$";

            if (thread != null)
                thread.Abort();
            thread = new Thread(simpleCrawler.Start);
            thread.Start();
            lblInfo.Text = "爬虫已启动";
        }
    }
}
