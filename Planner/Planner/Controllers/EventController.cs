using Planner.Models;
using Planner.ViewModels;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
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

            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };



            if (viewModel.ImageUpload == null || viewModel.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }



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
                Venue = viewModel.Venue,
                ImageId = viewModel.Image

            };


            if (viewModel.ImageUpload != null && viewModel.ImageUpload.ContentLength > 0)
            {
                var uploadDir = "~/Content/Image/";
                var imagePath = Path.Combine(Server.MapPath(uploadDir), viewModel.ImageUpload.FileName);
                var imageUrl = Path.Combine(uploadDir, viewModel.ImageUpload.FileName);
                viewModel.ImageUpload.SaveAs(imagePath);

                Image imageUpload = new Image()
                {
                    ImageUrl = imageUrl
                };

                eventVar.Image = imageUpload;
            }

            _context.Events.Add(eventVar);
            _context.SaveChanges();









            return RedirectToAction("Index", "Home");

        }





    }
}