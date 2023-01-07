using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class FileWriter
    {
        private string path;
        private readonly List<string> htmlStr;
        private List<string> urlList;

        public FileWriter(List<string> htmlStr, List<string> urlList)
        {
            this.htmlStr = htmlStr;
            this.urlList = urlList;

            ReplaceUrl();
        }

        //public void CreateFile()
        //{
           
        //    path = Directory.GetCurrentDirectory() + "\\Webcrawler";

        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    string newPath = Path.Combine(path, url + ".txt");

        //    using StreamWriter streamWriter = File.CreateText(newPath);

        //    streamWriter.WriteLine(htmlStr);
        //}

        //public void CreateUrlListFile()
        //{
        //    path = Directory.GetCurrentDirectory() + "\\Webcrawler";

        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    string newPath = Path.Combine(path, url + ".list.txt");

        //    using StreamWriter streamWriter = File.CreateText(newPath);

        //    foreach (string urlL in urlList)
        //    {
        //        streamWriter.WriteLine(urlL);
        //    }
        //}

        private void ReplaceUrl()
        {
            List<string> urlListNew = new List<string>();
            foreach (string url in urlList)
            {
                if (url != "")
                {
                    string pattern = @"^https?://([^/]*)";

                    Match match = Regex.Match(url, pattern);

                    if (match.Success)
                    {
                        urlListNew.Add(match.Groups[1].Value);
                    }
                }
            }

            urlList = urlListNew;
        }
    }
}
