using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Webdownloader
{
    class Webpage
    {
        string url;
        List<Webpage> webpages;
        List<Content> contents;

        public bool CheckURL(string url)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            if (!rgx.IsMatch(url))
            {
                Console.WriteLine("URL is not valid. It should look be like this: http://urlname.ch");
                return false;
            }

            return true;
        }

        public void Download()
        {

        }
    }
}
