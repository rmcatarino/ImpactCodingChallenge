using System;
using System.Collections.Generic;

namespace RSSReader.Models
{
    public class RSSReaderViewModel
    {
        public RSSReaderViewModel()
        {
            Feeds = new List<FeedItemViewModel>();
        }

        public string URL;

        public IEnumerable<FeedItemViewModel> Feeds { get; set; }

    }
}