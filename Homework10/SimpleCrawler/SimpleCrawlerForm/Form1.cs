using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleCrawlerForm
{
    public partial class Form1 : Form
    {
        SimpleCrawler.SimpleCrawler SC = new SimpleCrawler.SimpleCrawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            SC.PageDownloaded =  SC.PageDownloaded +Crawler_PageDownloaded;
            SC.CrawlerStopped = SC.CrawlerStopped +Crawler_CrawlerStopped;
        }


        private void Crawler_CrawlerStopped(SimpleCrawler.SimpleCrawler obj)
        {
            Action action = () => lblInfo.Text = "Over";
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
            SC.StartURL = txtStartUrl.Text;
            Match match = Regex.Match(SC.StartURL, SimpleCrawler.SimpleCrawler.urlParseRegex);
            if (match.Length == 0)
            {
                return;
            }
            string host = match.Groups["host"].Value;
            SC.HostFilter = "^" + host + "$";
            SC.FileFilter = ".html?$";
            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(SC.Start);
            thread.Start();
            lblInfo.Text = "Start";
        }
    }
}
