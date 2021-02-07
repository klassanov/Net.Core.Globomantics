using Globomantics.Interfaces.Services;
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

        public string Index()
        {
            return "Hello from the Index method";
        }
    }
}
