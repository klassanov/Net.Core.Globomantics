using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Globomantics.Models;
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

        [HttpGet]
        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposal)
        {
            if (ModelState.IsValid)
            {
                await this.proposalService.Add(proposal);
                return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
            }
            else
            {
                return View(proposal);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await this.proposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}
