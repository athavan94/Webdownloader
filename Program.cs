using System;

namespace Webdownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string str in args)
            {
                Console.WriteLine(str);
            }
           
            Webcrawler webcrawler = new Webcrawler(args);
        }
    }
}
