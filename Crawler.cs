using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private List<string> htmlStr;
        private List<string> urlListTmp;
        private List<string> imgList;

        private List<string> _ulrList;
        public List<string> urlList
        {
            get
            {
                return _ulrList;
            }
            set
            {
                _ulrList = value;
            }
        }


        public Crawler(string url)
        {
            this.url = url;
            htmlStr = new List<string>();
            urlList = new List<string>();
            urlListTmp = new List<string>();
            imgList = new List<string>();
        }

        public List<string> Start()
        {
            GetHtmlResponseString(url);
            urlList.Clear();

            urlListTmp.Add(url);
            GetUrlList();
            GetImgList();

            htmlStr.Clear();

            foreach (string url in urlListTmp)
            {
                if (url != "")
                {
                    GetHtmlResponseString(url);
                }
            }

            return htmlStr;
        }

        private void GetHtmlResponseString(string url)
        {
            string response = string.Empty;

            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Proxy = null;

                WebResponse webResponse = webRequest.GetResponse();

                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                response = streamReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                return;
            }

            urlList.Add(url);
            htmlStr.Add(response);
        }

        private void GetUrlList()
        {
            string linkedUrl;

            Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

            foreach (var match in regexLink.Matches(htmlStr[0]))
            {
                if (!urlListTmp.Contains(match.ToString()))
                {
                    linkedUrl = GetLinkedUrl(match.ToString());
                    linkedUrl = CleanURL(linkedUrl);
                    urlListTmp.Add(linkedUrl);
                }
            }
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

        private string CleanURL(string url)
        {
            if (url.Contains("mailto"))
            {
                return "";
            }

            return Regex.Replace(url, this.url, "");
        }

        private void GetImgList()
        {
            string linkedImg;

            Regex regexImg = new Regex("<img .*?>");

            foreach (var match in regexImg.Matches(htmlStr[0]))
            {
                imgList.Add(match.ToString());
            }
        }
    }
}
