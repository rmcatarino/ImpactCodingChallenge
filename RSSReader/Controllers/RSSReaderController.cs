using RSSReader.Domain.Interface;
using RSSReader.Models;
using RSSReader.Service;
using System.Web.Mvc;
using System.Linq;

namespace RSSReader.Controllers
{
    public class RSSReaderController : Controller
    {
        //TODO DI
        private IRSSReaderService readerSevice = new RSSReaderService();

        // GET: RSSReader
        public ActionResult Index(string url, string sort)
        {
            RSSReaderViewModel model = new RSSReaderViewModel();

            if (string.IsNullOrWhiteSpace(url))
            {
                ModelState.AddModelError("ns", "No URL found");
                return View(model);
            }

            //get feeds from service
            var rssItems = readerSevice.Load(url);

            //map to viewmodel
            var feeds = rssItems.Select(e => new FeedItemViewModel(e));

            //sort
            //model.PubDateSortOrder = string.IsNullOrEmpty(sort) ? "pubDate_desc" : "pubDate"; //defualt pubDate_desc
            model.PubDateSortOrder = sort == "pubDate" ? "pubDate_desc" : "pubDate";
            model.TitleSortOrder = sort == "title" ? "title_desc" : "title";
            switch (sort)
            {
                case "title":
                    feeds = feeds.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    feeds = feeds.OrderByDescending(s => s.Title);
                    break;
                case "pubDate":
                    feeds = feeds.OrderBy(s => s.PublicationDate);
                    break;
                case "pubDate_desc":
                default:
                    feeds = feeds.OrderByDescending(s => s.PublicationDate);
                    break;
            }

            model.Feeds = feeds;
            model.URL = url;

            return View(model);
        }
    }
}