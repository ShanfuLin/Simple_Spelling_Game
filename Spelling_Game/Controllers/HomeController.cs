using Microsoft.AspNetCore.Mvc;
using Spelling_Game.Models;
using System.Diagnostics;

namespace Spelling_Game.Controllers
{
    public class HomeController : Controller
    {
        private DB db;


        public HomeController(IConfiguration cfg)
        {
            db = new DB(cfg.GetConnectionString("db_conn"));
        }

        public IActionResult Index()
        {   
            List<Word> gamewords = db.GetGameWords();
            ViewData["words"] = gamewords;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}