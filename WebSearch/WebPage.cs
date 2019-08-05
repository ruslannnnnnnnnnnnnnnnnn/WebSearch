using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors;
using System.Text.RegularExpressions;
using System.IO;

namespace WebSearch
{
    class WebPage
    {
        long length;

        public int Length {
            get
            {
                if (length > int.MaxValue) return int.MaxValue;
                return (int)length;
            }
        }

        HtmlDocument html;

        public WebPage(string page)
        {
            length = page.Length;

            html = new HtmlDocument();
            html.LoadHtml(page);
        }

        public WebPage(Stream stream)
        {
            length = stream.Length / 2;

            html = new HtmlDocument();
            html.Load(stream);
        }

        public string Text(Action<string> action = null, Predicate<string> predicate = null)
        {
            if (action == null) action = (s) => { };
            if (predicate == null) predicate = (s) => { return true; };

            var texts = html.DocumentNode.SelectNodes("//*[not(self::script or self::style)]/text()");
            StringBuilder resStr = new StringBuilder(Length);

            foreach (var text in texts)
            {
                string str = text.InnerText;
                if (predicate(str))
                {
                    action(str);
                    resStr.Append(" ").Append(str);
                }
            }

            return resStr.ToString();
        }

        public IEnumerable<string> Hrefs(Action<string> action = null, Func<string, string> predicate = null)
        {
            if (action == null) action = (s) => { };
            if (predicate == null) predicate = (s) => { return ""; };

            var hrefs = html.DocumentNode.SelectNodes("//a[@href]");
            var res = new LinkedList<string>();
       
            foreach (var a in hrefs)
            {
                string href = predicate(a.Attributes["href"].Value);
                if (href != null)
                {
                    action(href);
                    res.AddLast(href);
                }
            }

            return res;
        }
    }
}
