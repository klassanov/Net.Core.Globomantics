using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Web.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conferences";
            return View(await conferenceService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel conference)
        {
            if (ModelState.IsValid)
            {
                await this.conferenceService.Add(conference);
                return RedirectToAction("Index");
            }
            else
            {
                return View(conference);
            }
        }

    }
}
