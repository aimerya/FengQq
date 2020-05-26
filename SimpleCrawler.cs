using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Homework9
{
    public class SimpleCrawler
    {
        public string StartUrl { get; set; }
        public Hashtable Urls { get; set; }
        public event InformEventHandler Inform;
        public int Count { get; set; }
        public SimpleCrawler()
        {
            Count = 0;
            Urls = new Hashtable();
        }

        public void Start()
        {
            try
            {
                Urls.Add(StartUrl, false);
            }
            catch (ArgumentException e)
            {
                Inform(this, new InformEventArgs() { 
                    Url = StartUrl, Message = "已存在" });
            }

            while (true)
            {
                string current = null;
                foreach (string url in Urls.Keys)
                {
                    if ((bool)Urls[url])
                    {
                        continue;
                        current = url;
                    }
                }
                if (Count > 10||current == null ) 
                    break;
                
                string html = DownLoad(current); 
                Urls[current] = true;
                Count++;

                Parse(html, current);
            }
            Inform(this, new InformEventArgs() { 
                Url = null, Message = "Over" });
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = Count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Inform(this, new InformEventArgs() 
                { 
                    Url = url, Message = ex.Message 
                });
                return "";
            }
        }

        private void Parse(string h, string u)
        {
            string Ref = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(Ref).Matches(h);
            foreach (Match match in matches)
            {
                Ref = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (Ref.Length == 0) 
                    continue;
                Uri uri = new Uri(u);
                string location = uri.Scheme + "://" + uri.Host;
                if (Regex.IsMatch(Ref, "^[//]"))
                {
                    Ref = uri.Scheme + ":" + Ref;
                }
                if (Regex.IsMatch(Ref, "^[/]"))
                {
                    Ref = location + Ref;
                }
                if (!Regex.IsMatch(Ref, "^(http|HTTP)"))
                {
                    Ref = u + "/" + Ref;
                }
                if (!Regex.IsMatch(Ref, location)) { continue; }
                if (Urls[Ref] == null) Urls[Ref] = false;
            }
        }
    }
    public delegate void InformEventHandler(object o, InformEventHandler e);
    public class InformEventArgs : EventArgs
    {
        public string Url { get; set; }
        public string Message { get; set; }
    }
}
