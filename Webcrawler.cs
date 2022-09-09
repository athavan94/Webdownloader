using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }
        }
    }
}
