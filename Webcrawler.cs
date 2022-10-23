using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class Webcrawler
    {
        private string[] args;

        public string[] Args { get => args; set => args = value; }

        public Webcrawler()
        {
            Console.WriteLine();
            Console.WriteLine("- Webcrawler -");
            Console.WriteLine();
        }

        public void Run()
        {
            // Target URL
            if(args.Length > 0)
            {
                CheckHttp(args[0]);
            } else
            {
                Console.WriteLine("First target path is missing.");
                return;
            }

            // Target Path
            if (args.Length > 1)
            {
                CheckHttp(args[1]);
            } else
            {
                Console.WriteLine("Seconde target path is missing.");
                return;
            }
        }

        private bool CheckHttp(string url)
        {
            Console.WriteLine(url);

            bool validUrl = CheckUrl(url);

            if (validUrl)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("URL not exists.");
                    return false;
                }
                else
                {
                    Console.WriteLine("URL exists.");
                    return true;
                }
            } else
            {
                Console.WriteLine("URL is not valid. It should look be like this: http://urlname.ch");
                return false;
            }
        }

        private bool CheckUrl(string url)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rgx.IsMatch(url);
        }
    }
}
