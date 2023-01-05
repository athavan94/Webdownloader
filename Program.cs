using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Webcrawler webcrawler = new Webcrawler{Args = args};
            //webcrawler.Run();

            Console.WriteLine();
            Console.WriteLine("- Webcrawler -");
            Console.WriteLine();

            Webpage webpage = new Webpage();
            bool checkUrl = webpage.CheckURL(args[0]);
            //Download html code
            if (checkUrl)
            {
                string htmlString = webpage.GetResponseHtmlString(args[0]);
                Console.WriteLine(htmlString);
            }
        }
    }
}
