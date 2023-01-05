using System;
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
            //StartCrawlerAsync();


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
            
        }

        private static void Initialize()
        {
            string path = Directory.GetCurrentDirectory();
            string seedPath = Path.Combine(path, "Seed.txt");
            string queuePath = Path.Combine(path, "Queue.txt");
            string crawledPath = Path.Combine(path, "Crawled.txt");

            seed = new Seed(seedPath);
            var seedURLs = seed.Items;
            queue = new Queue(queuePath, seedURLs);
            crawled = new Crawled(crawledPath);
        }
    }
}
