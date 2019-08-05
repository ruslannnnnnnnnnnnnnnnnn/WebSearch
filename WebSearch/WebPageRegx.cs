using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Text.RegularExpressions;
using System.IO;


namespace WebSearch
{
    class WebPageRegx
    {
        WebClient webClient;
        string url;

        string page;

        public WebPageRegx(string Url)
        {
            webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            url = Url;

            page = webClient.DownloadString(url);
        }

        public List<string> Hrefs()
        {
            var matches = Regex.Matches(page, @"(?<=href=)('|"").+\1");

            List<string> list = new List<string>(matches.Count);

            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }

            return list;
        }

        public void Hrefs(Action<string> action)
        {
            Regex reg = new Regex(@"(?<=href=)('|"").+\1");

            Match match = reg.Match(page);

            for (int i = match.Index + match.Length; match.Success; i = match.Index + match.Length)
                action(match.Value);
        }

        public string Text()
        {
            StringBuilder res = new StringBuilder(page.Length);

            res.Append(Regex.Match(page, @"^.+?(?=<\w+>)?").Value);

            var matches = Regex.Matches(page, @"(?<=<\w+ \w+=>).+?(?=<\w+>)");

            foreach (Match match in matches) res.Append(" ").Append(match.Value);

            res.Append(" ").Append(Regex.Match(page, @"(?<=<\w+>)?.+?$"));

            return res.ToString();
        }


        public void Text(Action<string> action)
        {
            Match match = Regex.Match(page, @"^.+");

            int i = match.Index + match.Length;

            action(match.Value);

            Regex reg = new Regex(@"(?<=<\w+>).+(?>=<\w+>)");

            for (; match.Success; i = match.Index + match.Length)
                action((match = reg.Match(page, i)).Value);

            action(new Regex(@".+$").Match(page, i).Value);
        }

    }
}
