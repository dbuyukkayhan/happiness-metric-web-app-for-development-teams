using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository());
        public IActionResult Index()
        {
            var values = userManager.GetList();
            return View(values);
        }
    }
}
