using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdownloader
{
    class Queue
    {
        private readonly string path;

        public string Top
        {
            get => File.ReadAllLines(path).First();
        }

        public string[] All
        {
            get => File.ReadAllLines(path);
        }

        public bool HasURLs
        {
            get => File.ReadAllLines(path).Length > 0;
        }

        public Queue(string path, string[] seedURLs)
        {
            this.path = path;

            using StreamWriter streamWriter = File.CreateText(path);

            foreach (string url in seedURLs)
                streamWriter.WriteLine(url.Trim().ToLower());
        }

        public async Task Add(string url)
        {
            using StreamWriter streamWriter = new StreamWriter(path, append: true);

            await streamWriter.WriteLineAsync(url.Trim().ToLower());
        }

        public async Task Remove(string url)
        {
            IEnumerable<string> filteredURLs = All.Where(u => u != url);

            await File.WriteAllLinesAsync(path, filteredURLs);
        }

        public bool IsInQueue(string url) => All.Where(u => u == url).Any();
    }
}
