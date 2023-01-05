using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class Crawler
    {
        private readonly string url;
        private string htmlStr;
        private List<string> urlList;

        public Crawler(string url)
        {
            this.url = url;
            urlList = new List<string>();
        }

        public string GetHtmlResponseString()
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Proxy = null;

                WebResponse webResponse = webRequest.GetResponse();

                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                htmlStr = streamReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                throw ex;
            }

            return htmlStr;
        }

        public List<String> GetUrlList()
        {
            string linkedUrl;

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

        private string GetLinkedUrl(string match)
        {
            if (!match.Contains("http://"))
            {
                if (match.IndexOf("/", 0) != -1)
                {
                    match = url + match;
                }
                else
                {
                    match = url + "/" + match;
                }

            }

            return match;
        }
    }
}
