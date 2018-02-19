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
        public ActionResult Index(string url, string sortDate, string sortTitle)
        {
            RSSReaderViewModel model = new RSSReaderViewModel();

            if (string.IsNullOrWhiteSpace(url))
            {
                ModelState.AddModelError("ns", "No URL found");
                return View(model);
            }

            model.URL = url;
            var rssItems = readerSevice.Load(url);
            model.Feeds = rssItems.Select(e => new FeedItemViewModel(e));

            return View(model);
        }
    }
}