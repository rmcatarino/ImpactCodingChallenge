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
        public ActionResult Index(string url, string sort, string order)
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

            //sort (if in query)
            switch (sort)
            {
                case "title":
                    if (order == "asc")
                    {
                        feeds = feeds.OrderBy(s => s.Title);
                        model.TitleSortOrder = "desc";
                    }
                    else
                    {
                        feeds = feeds.OrderByDescending(s => s.Title);
                        model.TitleSortOrder = "asc";
                    }
                    break;

                case "pubDate":
                default:
                    if (order == "asc")
                    {
                        feeds = feeds.OrderBy(s => s.PublicationDate);
                        model.PubDateSortOrder = "desc";
                    }
                    else
                    {
                        feeds = feeds.OrderByDescending(s => s.PublicationDate);
                        model.PubDateSortOrder = "asc";
                    }
                    break;
            }

            model.Feeds = feeds;
            model.URL = url;

            return View(model);
        }
    }
}