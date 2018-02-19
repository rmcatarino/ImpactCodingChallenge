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
        public ActionResult Index(string url, string sort, string currentSort)
        {
            RSSReaderViewModel model = new RSSReaderViewModel();

            if (string.IsNullOrWhiteSpace(url))
            {
                ModelState.AddModelError("ns", "No URL found");
                return View(model);
            }
           
            model.URL = url;
            //get feeds from service
            var rssItems = readerSevice.Load(url);

            //map to viewmodel
            var feeds = rssItems.Select(e => new FeedItemViewModel(e));

            //sort (if in query)
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "title":
                        feeds = currentSort == "title" ? feeds.OrderByDescending(s => s.Title) : feeds.OrderBy(s => s.Title);
                        model.CurrentSort = "title";
                        break;
                    case "pubDate":
                    default:
                        feeds = currentSort == "pubDate" ? feeds.OrderByDescending(s => s.Title) : feeds.OrderBy(s => s.PublicationDate);
                        model.CurrentSort = "pubDate";
                        break;
                }
            }
            model.Feeds = feeds;

            return View(model);
        }
    }
}