using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Program
    {
        private static Crawler crawler;
        private static FileWriter fileWriter;

        static void Main(string[] args)
        {
            //StartCrawlerAsync();


            crawler = new Crawler(args[0]);
            string htmlStr = crawler.GetHtmlResponseString();

            fileWriter = new FileWriter(args[0], htmlStr);
            fileWriter.CreateFile();

            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();

            //Download one page
            //Save somewhere
            //Save url from Webpage
        }
    }
}
