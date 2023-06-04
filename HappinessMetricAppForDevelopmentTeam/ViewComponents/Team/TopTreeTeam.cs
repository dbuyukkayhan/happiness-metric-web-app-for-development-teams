using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.ViewComponents.Team
{
    public class TopTreeTeam : ViewComponent
    {
        TeamManager teamManager = new TeamManager(new EFTeamRepository(), new EFSprintRepository(), new EFRatingRepository());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teamScores = teamManager.GetAverageTeamScores();
            var topTeams = teamScores.OrderByDescending(ts => ts.Value).Take(3).ToList();
            var topTeamDetails = topTeams.Select(tt => teamManager.GetById(tt.Key)).ToList();
            return View(topTeamDetails);
        }
    }
}
