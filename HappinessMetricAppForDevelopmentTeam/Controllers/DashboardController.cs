using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
