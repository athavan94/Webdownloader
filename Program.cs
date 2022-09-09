using System;

namespace Webdownloader
{
    class Program
    {
        static void Main(string[] args)
        { 
            Webcrawler webcrawler = new Webcrawler();
            webcrawler.Args = args;
            webcrawler.Run();
        }
    }
}
