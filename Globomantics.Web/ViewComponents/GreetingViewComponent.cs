using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Web.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string greeting)
        {
            return View((object)greeting);
        }
    }
}
