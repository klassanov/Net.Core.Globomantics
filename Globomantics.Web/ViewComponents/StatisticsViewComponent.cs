using System.Threading.Tasks;
using Globomantics.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Web.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService conferenceService;

        public StatisticsViewComponent(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await conferenceService.GetStatistics());
        }
    }
}
