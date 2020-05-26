using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    public class SimpleCrawler
    {
        public event Action<SimpleCrawler> CrawlerStopped;
        public event Action<SimpleCrawler, string, string> PageDownloaded;

        //所有已下载和待下载的URL
        private Hashtable Url = new Hashtable();
        //数目
        private int count = 0;        
        //等待队列
        private Queue<string> wait = new Queue<string>();
        //URL检测表达式，用于在HTML文本中查找URL
        private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<u>[^""'#>]+)[""']";
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<location>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; }
        public string StartURL { get; set; }
        public string FileFilter { get; set; }        
        public int MaxPage { get; set; }

        private void Crawl()
        {
            while (true)
            {
                string current = null;
                foreach (string url in Url.Keys)
                {
                    //判断是否已下载
                    if ((bool)Url[url])
                        continue;
                    current = url;
                }
                if (current == null || count > 10)
                {
                    break;
                }
                Console.WriteLine("正在爬行：" + current);
                string html = DownLoad(current);
                //修改状态
                Url[current] = true;
                count++;
                Parse(html, (string)Url[current]);
                Console.WriteLine("Over");
            }
        }
        public SimpleCrawler()
        {
            MaxPage = 20;
        }

        public void Start()
        {
            Url.Clear();        
            wait.Clear();        
            wait.Enqueue(StartURL);      
            while ( wait.Count > 0 && count < MaxPage)
            {
                string u = wait.Dequeue();
                try
                {
                    string h = DownLoad(u);
                    Url[u] = true;
                    PageDownloaded(this, u, "success");
                    Parse(h, u);
                }
                catch (Exception e)
                {
                    PageDownloaded(this, u, "Error:" + e.Message);
                }
                count++;
            }
            CrawlerStopped(this);
        }

        //下载
        public string DownLoad(string str)
        {
            try
            {
                WebClient wC = new WebClient();
                wC.Encoding = Encoding.UTF8;
                string html = wC.DownloadString(str);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
        static private string FixUrl(string u, string baseU)
        {
            if (u.StartsWith("/"))
            {
                Match m = Regex.Match(baseU, urlParseRegex);
                String location = m.Groups["location"].Value;
                return location.EndsWith("/") ? location + u.Substring(1) : location + u;
            }

            if (u.StartsWith("//"))
            {
                return "http:" + u;
            }

            if (u.Contains("://"))
            {
                return u;
            }
            if (u.StartsWith("./"))
            {
                return FixUrl(u.Substring(2), baseU);
            }
            if (u.StartsWith("../"))
            {
                u = u.Substring(3);
                int idx = baseU.LastIndexOf('/');
                return FixUrl(u, baseU.Substring(0, idx));
            }
            int end = baseU.LastIndexOf("/");
            return baseU.Substring(0, end) + "/" + u;
        }


        private void Parse(string html,string pageurl)
        {
            var matches = new Regex(urlDetectRegex).Matches(html);   
            foreach (Match match in matches)                         
            {
                string link = match.Groups["u"].Value;        
                if ( link == "" || link == null) 
                {
                    continue;
                }
                link = FixUrl(link, pageurl);        
                Match linkUrlMatch = Regex.Match(link, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;        
                string file = linkUrlMatch.Groups["file"].Value;       
                if (file == "")                                      
                    file = "index.h";
                if (!Url.Contains(link) && Regex.IsMatch(file, FileFilter) && Regex.IsMatch(host, HostFilter))        //如果过滤成功且linkUrl不在urls中
                {
                    wait.Enqueue(link);       
                    Url[link] = false;        
                }
            }
        }

        static void Main(string[] args)
        {
            SimpleCrawler craw = new SimpleCrawler();
            string startUrl = Console.ReadLine();
            if (args.Length >= 1)
            {
                startUrl = args[0];
            }
            //加入
            craw.Url.Add(startUrl, false);
            //开始
            new Thread(craw.Crawl).Start();
        }

    }
}

