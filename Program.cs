using System;
using System.Collections.Generic;

namespace Webdownloader
{
    class Program
    {
        private static Crawler crawler;
        private static FileWriter fileWriter;

        static void Main(string[] args)
        { 
            crawler = new Crawler(args[0]);
            string htmlStr = crawler.GetHtmlResponseString();
            List<string> urlList = crawler.GetUrlList();
            
            fileWriter = new FileWriter(args[0], htmlStr, urlList);
            fileWriter.CreateFile();
            fileWriter.CreateUrlListFile();

            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }
    }
}
