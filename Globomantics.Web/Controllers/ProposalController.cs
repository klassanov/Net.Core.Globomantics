using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Web.Controllers
{
    public class ProposalController : Controller
    {
        private IConferenceService conferenceService;
        private IProposalService proposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            this.conferenceService = conferenceService;
            this.proposalService = proposalService;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposals for conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conference.Id;
            return View(await this.proposalService.GetAll(conferenceId));
        }
    }
}
