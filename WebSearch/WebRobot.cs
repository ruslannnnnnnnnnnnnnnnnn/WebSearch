using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Text.RegularExpressions;
using System.IO;

using System.Collections;
using System.Threading;
using System.Xml.Serialization;

namespace WebSearch
{
    class WebRobot
    {
        IDictionary dHrefs;

        string host;

        public int SecondsPause;
        public bool ValuePause, TruePause;

        WebClient webClient;

        Queue<string> queueHrefs;

        int pages;

        int count;

        string filePath;

        string fileSerialeze;


        public WebRobot(string Host, int Pause, string file, int Pages = 0, int Count = -1)
        {
            webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            host = @"https://" + Host;

            filePath =  file;

            webClient.Encoding = Encoding.UTF8;

            SecondsPause = Pause * 1000 + 550;

            count = Count;

            dHrefs = new Hashtable();
            dHrefs.Add("", true);

            queueHrefs = new Queue<string>();
            queueHrefs.Enqueue("");

            pages = Pages;

            fileSerialeze = filePath + @"\serialeze";
        }
        
        public WebRobot(string file, int Pause)
        {
            filePath = file;

            if (File.Exists((fileSerialeze = filePath + @"\serialeze") + @"\text.txt"))
            {
                Deserialize();

                webClient = new WebClient();
                webClient.Credentials = CredentialCache.DefaultCredentials;             

                webClient.Encoding = Encoding.UTF8;

                SecondsPause = Pause * 1000 + 550;
            }
            else throw new Exception();
        }

        public void BeginSite()
        {
            while (queueHrefs.Count != 0 && count != pages)
            {
                string Href = queueHrefs.Dequeue();
                try
                {
                    var hrefs = ParsePage(Href, actionHref: (href) =>
                    {
                        queueHrefs.Enqueue(href);
                        dHrefs.Add(href, true);
                    });
                }
                catch
                {
                    if (Connection())
                    {
                        File.AppendAllText(filePath + @"/erros.txt", Href + Environment.NewLine);
                        Thread.Sleep(50);
                        continue;
                    }
                    else
                    {
                        while (!Connection()) Pause();
                    }
                }

                Pause();
            }
        }
         
        public IEnumerable<string> ParsePage(string href, Action<string> actionText = null, Action<string> actionHref = null)
        {
            string hostHref = host + href;

            WebPage page = new WebPage(webClient.DownloadString(hostHref));

            string text = page.Text(actionText, PredicateText);
            IEnumerable<string> hrefs = page.Hrefs(actionHref, PredicateHref);

            ActionWithTexts(text, hostHref);
            //ActionWithHrefs(hrefs);

            pages++;

            return hrefs;
        }

        public void Pause()
        {
            Thread.Sleep(SecondsPause);

            while (TruePause = ValuePause)
            {
                Thread.Sleep(SecondsPause);
            }
        }
        
        public static bool Connection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(@"https://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void ActionWithTexts(string text, string href)
        {
            using (StreamWriter wrt = File.CreateText(string.Format(@"{0}\text{1}.txt", filePath, pages)))
            {
                wrt.WriteLine(href);
                wrt.WriteLine(text);
                wrt.Close();
            }
        }

        public void ActionWithHrefs(IEnumerable<string> hrefs)
        {         
            using (StreamWriter wrt = File.CreateText(string.Format(@"{0}\hrefs{1}.txt", filePath, pages)))
            {
                foreach (var href in hrefs) wrt.WriteLine(href);
                wrt.Close();
            }
        }

        public bool PredicateText(string text)
        {
            return true;
        }

        public string PredicateHref(string href)
        {
            if (href == null || href == "" || Regex.IsMatch(href, @"[#&?]")) return null;           

            if (Regex.IsMatch(href, string.Format(@"^(http(s)?:)?\/\/{0}", host)))
            {
                Match match = Regex.Match(href, string.Format(@"(?<=(http(s)?:)?\/\/{0})\/.+", host));
                if (match.Success && !dHrefs.Contains(match.Value)) return match.Value;
            }
            else if (!Regex.IsMatch(href, @"^(http(s)?:)?\/\/"))
            {
                if (href[0] != '/') href = '/' + href;
                if (!dHrefs.Contains(href)) return href;
            }

            return null;
        }

        public void Serialize()
        {
            var serH = new XmlSerializer(typeof(string[]));
            var serQ = new XmlSerializer(typeof(string[]));

            using (var writer = new StreamWriter(fileSerialeze + @"\hrefs.xml"))
            {
                var keys = dHrefs.Keys;
                string[] hrefs = new string[keys.Count];

                int i = 0;

                foreach (var key in keys) hrefs[i++] = (string)key;

                serH.Serialize(writer, hrefs);              
            }

            using (var writer = new StreamWriter(fileSerialeze + @"\queue.xml"))
            {
                serQ.Serialize(writer, queueHrefs.ToArray());
            }

            using (var writer = new StreamWriter(fileSerialeze + @"\text.txt"))
            {
                writer.WriteLine(host);
                writer.WriteLine(pages);
                writer.WriteLine(count);
            }
        }

        public void Deserialize()
        {
            var dser = new XmlSerializer(typeof(string[]));
            var dserQ = new XmlSerializer(typeof(string[]));

            using (var reader = new StreamReader(fileSerialeze + @"\hrefs.xml"))
            {
                var keys = (string[])dser.Deserialize(reader);
                dHrefs = new Hashtable();
                foreach (var key in keys) dHrefs.Add(key, true);
            }

            using (var reader = new StreamReader(fileSerialeze + @"\queue.xml"))
            {
                 queueHrefs =  new Queue<string>((string[])dserQ.Deserialize(reader));
            }

            using (var reader = new StreamReader(fileSerialeze + @"\text.txt"))
            {
                host = reader.ReadLine();
                pages = int.Parse(reader.ReadLine());
                count = int.Parse(reader.ReadLine());
            }
        }
    }
}
