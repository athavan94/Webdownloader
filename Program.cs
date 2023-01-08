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
            string url = args[0];

            crawler = new Crawler(url);
            List<string> htmlStr = crawler.Start();
            List<string> urlList = crawler.urlList;

            fileWriter = new FileWriter(htmlStr, urlList);
            fileWriter.CreateFile();

            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }
    }
}
