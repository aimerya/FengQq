using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    public class SimpleCrawler
    {
        public event Action<SimpleCrawler> CrawlerStopped;
        public event Action<SimpleCrawler, string, string> PageDownloaded;
        private Hashtable urls = new Hashtable();
        //数目
        private int count = 0;        
        //等待队列
        private Queue<string> wait = new Queue<string>();
        private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
        public static readonly string urlParseRegex = @"^(?<location>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; }        
        public string FileFilter { get; set; }        
        public int MaxPage { get; set; }              
        public string StartURL { get; set; }         

        private void Crawl()
        {
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {                                                
                    if ((bool)urls[url])
                    {                       
                        continue; 
                    }                
                    current = url;
                }
                if ( count > 10 ||current == null)
                {
                    break;
                }
                Console.WriteLine("正在爬行" + current );
                string html = DownLoad(current);            
                //改变状态
                urls[current] = true;                             
                count++;
                Parse(html, (string)urls[current]);                                
                Console.WriteLine("Over");
            }
        }
        public SimpleCrawler()
        {
            MaxPage = 20;
        }

        public void Start()
        {
            urls.Clear();        
            wait.Clear();    
            wait.Enqueue(StartURL); 
            List<Task> tasks = new List<Task>();
            while (wait.Count > 0&& count < MaxPage )
            {
                string url = wait.Dequeue(); 
                try
                {
                    string html = DownLoad(url);
                    urls[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url);
                }
                catch (Exception e)
                {
                    PageDownloaded(this, url, "Error:" + e.Message);
                }

                Task task = Task.Run(() => DownloadAndParse(url));
                count++;
            }
            Task.WaitAll(tasks.ToArray());
            CrawlerStopped(this);
        }
        //获取网址的内容
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string h = webClient.DownloadString(url);
                string file = count.ToString();
                File.WriteAllText(file, h, Encoding.UTF8);
                return h;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public void DownloadAndParse(string url)
        {
            try
            {
                string html = DownLoad(url);
                urls[url] = true;
                Parse(html, url);
                PageDownloaded(this, url, "success");
            }
            catch (Exception e)
            {
                PageDownloaded(this, url, "Error:" + e.Message);
            }
        }

        private void Parse(string h,string pageurl)
        {
            var matches = new Regex(urlDetectRegex).Matches(h);  
            foreach (Match match in matches)    
            {
                string link = match.Groups["url"].Value;        
                if (link == null || link == "")
                {
                    continue; 
                }
                link = PathChange(link, pageurl);  
                Match uMatch = Regex.Match(link, urlParseRegex);
                string host = uMatch.Groups["host"].Value;       
                string file = uMatch.Groups["file"].Value;     
                if (file == "")
                {
                    file = "index.html";
                }
                if (!urls.Contains(link) && Regex.IsMatch(file, FileFilter) &&Regex.IsMatch(host, HostFilter) )        //如果过滤成功且link不在urls中
                {
                    wait.Enqueue(link);       
                    urls[link] = false;      
                }
            }
        }

        static private string PathChange(string url, string baseUrl)
        {
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(baseUrl, urlParseRegex);
                String location = urlMatch.Groups["location"].Value;
                return location.EndsWith("/") ? location + url.Substring(1) : location + url;
            }

            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }

            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("./"))
            {
                return PathChange(url.Substring(2), baseUrl);
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int a = baseUrl.LastIndexOf('/');
                return PathChange(url, baseUrl.Substring(0, a));
            }

            int end = baseUrl.LastIndexOf("/");
            return baseUrl.Substring(0, end) + "/" + url;
        }
        
        static void Main(string[] args)
        {
            SimpleCrawler SC = new SimpleCrawler();
            string start = Console.WriteLine() ;
            if (args.Length >= 1)
                {
                start = args[0];
            }
            SC.urls.Add(start, false);        
            //开始爬行
            new Thread(SC.Crawl).Start();        
        }

    }
}

