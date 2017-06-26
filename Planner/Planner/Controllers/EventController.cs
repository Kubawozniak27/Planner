using Planner.Models;
using Planner.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController()
        {
            _context=new ApplicationDbContext();
        }



        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }



            var eventVar = new Event()
            {
                Name = viewModel.Name,
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Venue = viewModel.Venue
            };

            _context.Events.Add(eventVar);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");

        }





    }
}