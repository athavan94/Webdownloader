using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class Webpage
    {
        string url;
        List<Webpage> webpages;
        List<Content> contents;

        public bool CheckURL(string url)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            if (!rgx.IsMatch(url))
            {
                Console.WriteLine("URL is not valid. It should look like this: http://urlname.ch");
                return false;
            }

            return true;
        }

        public string GetResponseHtmlString(string url)
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
    }
}
