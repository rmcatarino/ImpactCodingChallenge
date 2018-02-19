using RSSReader.Domain;
using System;

namespace RSSReader.Models
{
    public class FeedItemViewModel
    {
        public FeedItemViewModel(RSSItem item)
        {
            this.Title = item.Title;
            this.Link = item.Link;
            this.PublicationDate = item.PublicationDate;
        }

        public string Title { get; set; }

        public Uri Link { get; set; }

        public DateTime? PublicationDate { get; set; }
    }
}