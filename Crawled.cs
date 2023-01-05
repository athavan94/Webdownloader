using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Crawled
    {
        private readonly string path;

        public Crawled(string path)
        {
            this.path = path;
            File.Create(path).Close();
        }

        public bool HasBeenCrawled(string url) => File.ReadAllLines(path).Any(c => c == url);

        public async Task Add(string url)
        {
            using StreamWriter streamWriter = new StreamWriter(path, append: true);

            await streamWriter.WriteLineAsync(url.Trim().ToLower());
        }
    }
}
