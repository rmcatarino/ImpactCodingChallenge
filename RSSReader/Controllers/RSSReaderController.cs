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
        public ActionResult Index(string url = "https://stackoverflow.blog/feed/")
        {
            var rssItems = readerSevice.Load(url);

            RSSReaderViewModel model = new RSSReaderViewModel()
            {
                URL = url,
                Feeds = rssItems.Select(e => new FeedItemViewModel(e)) //Mapping logic
            };

            return View(model);
        }
    }
}