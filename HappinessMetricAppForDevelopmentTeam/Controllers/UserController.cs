using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        public PartialViewResult MemberSideBarPartial()
        {

            return PartialView();
        }

        public PartialViewResult MemberFooterPartial()
        {
            return PartialView();
        }
    }
}
