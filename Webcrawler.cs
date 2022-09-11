using System;
using System.Collections.Generic;
using System.Text;

namespace Webdownloader
{
    class Webcrawler
    {
        private string[] args;
        private bool targetExists;

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
                targetExists = CheckTargetUrl(args[0]);

                if(!targetExists)
                {
                    Console.WriteLine("Zieladresse ungültig.");
                    return;
                }
            } else
            {
                Console.WriteLine("Zieladresse ungültig.");
                return;
            }

            // Target Path
            if (args.Length > 1)
            {
                targetExists = CheckTargetPath(args[1]);

                if (!targetExists)
                {
                    Console.WriteLine("Zielpfad ungültig.");
                    return;
                }
            } else
            {
                Console.WriteLine("Zielpfad ungültig.");
                return;
            }
        }

        private bool CheckTargetUrl(string arg)
        {
            Console.WriteLine(arg);
            return true;
        }

        private bool CheckTargetPath(string arg)
        {
            Console.WriteLine(arg);
            return true;
        }
    }
}
