using System;

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
            webpage.CheckURL(args[0]);
        }
    }
}
