using RSSReader.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSReader.Domain;
using System.Xml.Linq;

namespace RSSReader.Service
{
    public class RSSReaderService : IRSSReaderService
    {
        public IList<RSSItem> Load(string url)
        {
            XDocument feedRSS = XDocument.Load(url);

            return feedRSS.Descendants("item")
                .Select(feed => new RSSItem()
                {
                    Title = feed.Element("title").Value,
                    PublicationDate = DateTime.Parse(feed.Element("pubDate")?.Value),
                    Link = new Uri(feed.Element("link").Value)
                })
                .ToArray();
            
        }
    }
}
