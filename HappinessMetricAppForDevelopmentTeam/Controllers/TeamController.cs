using BusinessLogic.Abstract;
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
using Microsoft.EntityFrameworkCore;
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
        RatingManager ratingManager = new RatingManager(new EFRatingRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

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

            var categories = categoryManager.GetAllCategories();
            ViewBag.Categories = categories;

            Dictionary<int, Rating> ratings = new Dictionary<int, Rating>();

            foreach (var category in categories)
            {
                var rating = ratingManager.GetRatingByCategoryId(category.CategoryId); // Bu metodu kendi veritabanı çağrınıza göre değiştirmelisiniz
                if (rating != null)
                {
                    ratings.Add(category.CategoryId, rating);
                }
            }

            ViewBag.Ratings = ratings;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userTeamManager.IsUserMemberOfTeam(int.Parse(userId), id))
            {
                ViewBag.Id = id;
                var values = teamManager.GetTeamById(id);

                var activeSprint = sprintManager.GetActiveSprintByTeamId(id);
                ViewBag.ActiveSprint = activeSprint;
                
                if(activeSprint != null)
                {
                    ViewBag.NumberOfUsersRated = ratingManager.GetNumberOfUsersRated(id, activeSprint.SprintId);
                    int userIdParsed = int.Parse(userId);

                    var hasUserRatedThisSprint = ratingManager.HasUserRatedSprint(userIdParsed, activeSprint.SprintId);
                    ViewBag.HasUserRatedThisSprint = hasUserRatedThisSprint;
                } else
                {
                    ViewBag.NumberOfUsersRated = 0;
                    ViewBag.HasUserRatedThisSprint = false;
                }
                
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

        [HttpPost]
        public IActionResult CreateSprint(Sprint p)
        {
            return View();
        }


        [HttpPost]
        public IActionResult RateSprint(List<Rating> modelList, int teamId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);

            foreach (var model in modelList)
            {
                model.UserId = userIdParsed;
                model.IsActive = true;
                ratingManager.AddRating(model);
            }

            return RedirectToAction("TeamDetails", "Team", new { id = teamId });
        }


        public IActionResult Results(int id) // id is the TeamId
        {
            var sprints = sprintManager.GetSprintsByTeamId(id).OrderByDescending(s => s.SprintEnd);
            var categories = categoryManager.GetAllCategories();

            var model = new Dictionary<string, List<KeyValuePair<string, double>>>();

            foreach (var sprint in sprints)
            {
                var sprintRatings = ratingManager.GetRatingsBySprintId(sprint.SprintId);

                var categoryAverages = categories.Select(c =>
                {
                    var categoryRatings = sprintRatings.Where(r => r.CategoryId == c.CategoryId);
                    double averageScore = 0;

                    if (categoryRatings.Any())
                    {
                        averageScore = categoryRatings.Average(r => r.RatingScore);
                    }

                    return new KeyValuePair<string, double>(c.CategoryName, averageScore);
                }).ToList();

                model.Add(sprint.SprintName, categoryAverages);
            }

            return View(model); // pass the model to the view
        }

        [HttpPost]
        public IActionResult AddPost(Post post, int teamId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userIdParsed = Int32.Parse(userId);
            post.UserId = userIdParsed;
            post.TeamId = teamId;
            post.PostTime = DateTime.Now;

            postManager.AddPost(post);
            return RedirectToAction("TeamDetails", "Team", new { id = teamId });
        }

    }
}
