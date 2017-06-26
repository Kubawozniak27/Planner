using Planner.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace Planner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }



        public ActionResult Index()
        {

            var commingEvents = _context.Events
                .Where(g => g.DateTime > DateTime.Now).ToList();
                    

            return View(commingEvents);
        }


    }
}