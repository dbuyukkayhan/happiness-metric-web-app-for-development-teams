using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class SprintController : Controller
    {
        SprintManager sprintManager = new SprintManager(new EFSprintRepository());

        [HttpGet]
        public IActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSprint(Sprint model)
        {

            model.IsActive = true;

            if(model.SprintStart < DateTime.Now)
            {
                model.SprintStart = DateTime.Now;
            }

            model.SprintEnd = model.SprintEnd.AddHours(23).AddMinutes(59);
            sprintManager.AddSprint(model);
            return RedirectToAction("TeamDetails", "Team", new { id = model.TeamId });
        }
    }
}
