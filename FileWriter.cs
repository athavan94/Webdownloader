using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class FileWriter
    {
        private string path;
        private string url;
        private readonly string htmlStr;

        public FileWriter(string url, string htmlStr)
        {
            this.url = url;
            this.htmlStr = htmlStr;

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

        private void ReplaceUrl()
        {
            string pattern = @"^(https?://)";
            string replacement = "";
            url = Regex.Replace(url, pattern, replacement);
        }
    }
}
