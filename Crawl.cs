using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Crawl
    {
        public readonly string url;
        private string webPage;
        public List<string> parsedURLs;

        public Crawl(string url)
        {
            this.url = url;
            webPage = null;
            parsedURLs = new List<string>();
        }

        public async Task Start()
        {
            await GetWebPage();

            if (!string.IsNullOrWhiteSpace(webPage))
            {
                //ParseContent();
                ParsedURLs();
            }
        }

        public async Task GetWebPage()
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(60);

            string responseBody = await httpClient.GetStringAsync(url);

            if (!string.IsNullOrWhiteSpace(responseBody))
                webPage = responseBody;
        }

        private void ParsedURLs()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(webPage);

            foreach(HtmlNode link in htmlDocument.DocumentNode.SelectNodes("//a[@href]"))
            {
                string hrefValue = link.GetAttributeValue("href", string.Empty);

                if (hrefValue.StartsWith("http"))
                    parsedURLs.Add(hrefValue);
            }
        }

        private void ParseContent()
        {
            throw new NotImplementedException();
        }
    }
}
