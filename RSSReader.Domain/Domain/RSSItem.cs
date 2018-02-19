using System;

namespace RSSReader.Domain
{
    public class RSSItem
    {
        public string Title { get; set; }

        public Uri Link{ get; set; }

        public DateTime? PublicationDate{ get; set; }
    }
}
