using Microsoft.AspNetCore.Mvc;
using RssCteckaASP.NET.Models;
using System.Diagnostics;

namespace RssCteckaASP.NET.Controllers
{
    
    public class HomeController : Controller
    {

        public Db _db = new Db();
        public Api _api = new Api();

        public IActionResult Index()
        {
            ViewBag.data = _db.Select();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult addFeed() { 

            return View(new AddFeed());
        }
        [HttpPost]
        public IActionResult addFeed(AddFeed model)
        {
            if (!ModelState.IsValid)
            {
                return View(new AddFeed());
            }
            Db _db = new Db();
            _db.Insert(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> content(string url) {
            Rss x = await _api.getXml(url);
            if (x != null) {
                ViewBag.d = x;
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
