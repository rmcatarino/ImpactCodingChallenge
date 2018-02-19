using RSSReader.Domain;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name ="Title")]
        public string Title { get; set; }

        [Display(Name = "Publication Date")]
        public DateTime? PublicationDate { get; set; }

        public Uri Link { get; set; }

    }
}