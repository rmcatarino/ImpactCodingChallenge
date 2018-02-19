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
            }
            else
            { 
                model.URL = url;
                //read from service
                var rssItems = readerSevice.Load(url);

                //map to viewmodel
                var feeds = rssItems.Select(e => new FeedItemViewModel(e));

                //sort (if in query)
                if (!string.IsNullOrWhiteSpace(sort))
                {
                    switch (sort)
                    {
                        case "title":
                            feeds = feeds.OrderBy(s => s.Title);
                            break;
                        case "pubDate":
                        default:
                            feeds = feeds.OrderByDescending(s => s.PublicationDate);
                            break;

                    }
                }

                model.Feeds = feeds;
            }
            return View(model);
        }
    }
}