using System.IO;

namespace Webdownloader
{
    class Seed
    {
        public string[] Items
        {
            get => File.ReadAllLines(path);
        }

        private readonly string path;

        public Seed(string path)
        {
            this.path = path;

            string[] seedURLs = new string[]
            {
                "https://vskmotorss.ch/"
            };

            using StreamWriter streamWriter = File.CreateText(path);

            foreach (string url in seedURLs)
                streamWriter.WriteLine(url);
        }
    }
}
