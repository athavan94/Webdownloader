using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class Webcrawler
    {
        private string[] args;
        private string resHtmlStr;
        private List<string> urlList;

        public string[] Args { get => args; set => args = value; }

        public Webcrawler()
        {
            Console.WriteLine();
            Console.WriteLine("- Webcrawler -");
            Console.WriteLine();
        }

        public void Run()
        {
            // Target URL
            if(args.Length > 0)
            {
                if(CheckHttp(args[0]))
                {
                    resHtmlStr = GetResponseHtmlString(args[0]);
                    urlList = GetUrlList(resHtmlStr);
                }
            } else
            {
                Console.WriteLine("URL to web page is missing.");
                return;
            }

            // Target Path
            if (args.Length > 1)
            {
                CheckTargetPath(args[1]);
            } else
            {
                Console.WriteLine("Target path is missing.");
                return;
            }
        }

        private bool CheckHttp(string url)
        {
            Console.WriteLine(url);

            bool validUrl = CheckUrl(url);

            if (validUrl)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("URL not exists.");
                    return false;
                }
                else
                {
                    Console.WriteLine("URL exists.");
                    return true;
                }
            } else
            {
                Console.WriteLine("URL is not valid. It should look be like this: http://urlname.ch");
                return false;
            }
        }

        private bool CheckUrl(string url)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rgx.IsMatch(url);
        }

        private bool CheckTargetPath(string path)
        {
            return true;
        }

        private string GetResponseHtmlString(string url)
        {
            string htmlStr = "";

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                WebRequest webRequest = (WebRequest)httpWebRequest;
                webRequest.Proxy = null;
                WebResponse webResponse = webRequest.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                htmlStr = sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                throw ex;
            }

            return htmlStr;
        }

        private List<string> GetUrlList(string htmlStr)
        {
            string linkedUrl;
            List<string> urlList = new List<string>();

            Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

            foreach (var match in regexLink.Matches(htmlStr))
            {
                if (!urlList.Contains(match.ToString()))
                {
                    linkedUrl = GetLinkedUrl(match.ToString());
                    urlList.Add(linkedUrl);
                }
            }

            return urlList;
        }

        private string GetLinkedUrl(string url)
        {
            if (!url.Contains("http://"))
            {
                if (url.IndexOf("/", 0) != -1)
                {
                    url = args[0] + url;
                }
                else
                {
                    url = args[0] + "/" + url;
                }

            }

            return url;
        }
    }
}
