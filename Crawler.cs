using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Webdownloader
{
    class Crawler
    {
        private readonly string url;
        private string htmlStr;

        public Crawler(string url)
        {
            this.url = url;
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
    }
}
