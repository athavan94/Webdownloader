using System;

namespace Webdownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Webcrawler webcrawler = new Webcrawler{Args = args};
            webcrawler.Run();
        }
    }
}
