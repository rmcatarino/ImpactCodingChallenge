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

        public string URL { get; set; }

        public string CurrentSort { get; set; }

        public IEnumerable<FeedItemViewModel> Feeds { get; set; }

    }
}