using BusinessLogic.Concrete;
using BusinessLogic.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using HappinessMetricAppForDevelopmentTeam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class TeamController : Controller
    {
        TeamManager teamManager = new TeamManager(new EFTeamRepository(), new EFSprintRepository(), new EFRatingRepository());
        UserManager userManager = new UserManager(new EFUserRepository(), new EFRoleRepository());
        UserTeamManager userTeamManager = new UserTeamManager(new EFUserTeamRepository());
        SprintManager sprintManager = new SprintManager(new EFSprintRepository());
        PostManager postManager = new PostManager(new EFPostRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            //var values = teamManager.GetList();
            //var teamsWithUserCount = teamManager.GetTeamsWithUserCount();
            //return View(teamsWithUserCount);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);
            var userTeams = userManager.GetUserTeamsWithRoles(userIdParsed);

            var values = teamManager.GetList();
            var teamsWithUserCount = teamManager.GetTeamsWithUserCount();

            ViewBag.UserTeamIds = userTeams?.Select(ut => ut.Key.TeamId).ToList() ?? new List<int>();

            return View(teamsWithUserCount);
        }

        public IActionResult TeamDetails(int id)
        {

            var userCount = teamManager.GetUserCountByTeamId(id);
            var postCount = postManager.GetPostCountByTeamId(id);
            ViewBag.UserCount = userCount;
            ViewBag.PostCount = postCount;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userTeamManager.IsUserMemberOfTeam(int.Parse(userId), id))
            {
                ViewBag.Id = id;
                var values = teamManager.GetTeamById(id);

                var activeSprint = sprintManager.GetActiveSprintByTeamId(id);
                ViewBag.ActiveSprint = activeSprint;

                return View(values);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult TeamListByUser()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);
            var values = userManager.GetUserTeamsWithRoles(userIdParsed);
            return View(values);
        }

        [HttpPost]
        public IActionResult LeaveTeam(int teamId, int roleId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);
            // UserTeam veritabanındaki ilgili kaydı bul
            var userTeam = userTeamManager.GetUserTeamById(userIdParsed, teamId, roleId);
            if (userTeam != null)
            {
                // IsActive değerini false olarak güncelle
                userTeam.IsActive = false;
                userTeamManager.UpdateUserTeam(userTeam);

                return RedirectToAction("TeamListByUser","Team");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult AddTeam()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team p)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);
            TeamValidator teamValidator = new TeamValidator();
            ValidationResult results = teamValidator.Validate(p);
            
            if(results.IsValid)
            {
                p.IsActive = true;
                p.TeamCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                teamManager.AddTeam(p);

                UserTeam userTeam = new UserTeam()
                {
                    UserId = userIdParsed,  
                    TeamId = p.TeamId,
                    RoleId = 1,  
                    IsActive = true 
                };

                userTeamManager.AddUserTeam(userTeam);

                return RedirectToAction("TeamListByUser", "Team");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
