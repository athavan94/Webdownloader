using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class FileWriter
    {
        private string path;
        private string url;
        private readonly string htmlStr;
        private readonly List<string> urlList;

        public FileWriter(string url, string htmlStr, List<string> urlList)
        {
            this.url = url;
            this.htmlStr = htmlStr;
            this.urlList = urlList;

            ReplaceUrl();
        }

        public void CreateFile()
        {
            path = Directory.GetCurrentDirectory() + "\\Test";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string newPath = Path.Combine(path, url + ".txt");

            using StreamWriter streamWriter = File.CreateText(newPath);

            streamWriter.WriteLine(htmlStr);
        }

        public void CreateUrlListFile()
        {
            path = Directory.GetCurrentDirectory() + "\\Test";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string newPath = Path.Combine(path, url + ".list.txt");

            using StreamWriter streamWriter = File.CreateText(newPath);

            foreach (string urlL in urlList)
            {
                streamWriter.WriteLine(urlL);
            }
        }

        private void ReplaceUrl()
        {
            string pattern = @"^(https?://)";
            string replacement = "";
            url = Regex.Replace(url, pattern, replacement);
        }
    }
}
