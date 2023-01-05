using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Program
    {
        private static Seed seed;
        private static Queue queue;
        private static Crawled crawled;

        static void Main(string[] args)
        {
            StartCrawlerAsync();


            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();

            //Download one page
            //Save somewhere
            //Save url from Webpage
        }

        private static async Task StartCrawlerAsync()
        {
            Initialize();

            await Crawl();
        }

        private static async Task Crawl()
        {
            do
            {
                string url = queue.Top;

                Crawl crawl = new Crawl(url);
                await crawl.Start();

                if (crawl.parsedURLs.Count > 0)
                    await ProcessURLs(crawl.parsedURLs);

                await PostCrawl(url);

            } while (queue.HasURLs);
        }

        private static void Initialize()
        {
            string path = Directory.GetCurrentDirectory() + "\\Test";

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string seedPath = Path.Combine(path, "Seed.txt");
            string queuePath = Path.Combine(path, "Queue.txt");
            string crawledPath = Path.Combine(path, "Crawled.txt");

            seed = new Seed(seedPath);
            var seedURLs = seed.Items;
            queue = new Queue(queuePath, seedURLs);
            crawled = new Crawled(crawledPath);
        }

        static async Task ProcessURLs(List<string> urls)
        {
            foreach (var url in urls)
            {
                if (!crawled.HasBeenCrawled(url) && !queue.IsInQueue(url))
                    await queue.Add(url);
            }
        }

        static async Task PostCrawl(string url)
        {
            await queue.Remove(url);

            await crawled.Add(url);
        }
    }
}
