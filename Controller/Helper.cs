using System;
using System.Collections.Generic;
using System.Text;

namespace Webdownloader.Controller
{
    class Helper
    {
        string filePath;

        public void CheckFilePath()
        {

        }

        public void CreateFile()
        {

        }

        public List<Webpage> ExtractWebpage()
        {
            List<Webpage> webpages = new List<Webpage>();
            return webpages;
        }

        public List<Content> ExtractContent()
        {
            List<Content> contents = new List<Content>();
            return contents;
        }

        public void getImg()
        {
            // Create a new concurrent queue to store the URLs of the images
            var imageUrls = new ConcurrentQueue<string>();

            // Create a new web client to download data
            var client = new WebClient();

            // Download the HTML code of the website
            var html = client.DownloadString("https://www.platesmania.com/");

            // Create an HtmlAgilityPack document from the downloaded HTML
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Use XPath to find all the <img> tags on the page
            var nodes = doc.DocumentNode.SelectNodes("//img");

            // Add the URLs of all the images to the concurrent queue
            foreach (var node in nodes)
            {
                imageUrls.Enqueue(node.Attributes["src"].Value);
            }

            // Print the URLs of all the images on the page
            foreach (var url in imageUrls.Distinct())
            {
                Console.WriteLine(url);
            }
        }
    }
}
