using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class TeamController : Controller
    {
        TeamManager teamManager = new TeamManager(new EFTeamRepository());
        public IActionResult Index()
        {
            var values = teamManager.GetList();
            return View(values);
        }
    }
}
