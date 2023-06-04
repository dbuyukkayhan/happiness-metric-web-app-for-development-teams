using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
	public class TeamManager : ITeamService
	{
		ITeamDal _teamDal;
		ISprintDal _sprintDal;
		IRatingDal _ratingDal;

		public TeamManager(ITeamDal teamDal, ISprintDal sprintDal, IRatingDal ratingDal)
		{
			_teamDal = teamDal;
			_sprintDal = sprintDal;
			_ratingDal = ratingDal;
		}

		public void AddTeam(Team team)
		{
			_teamDal.Insert(team);
		}

		public void DeleteTeam(Team team)
		{
			throw new NotImplementedException();
		}

		public Team GetById(int id)
		{
			return _teamDal.GetById(id);
		}

		public List<Team> GetTeamById(int id)
		{
			return _teamDal.GetListAll(x => x.TeamId == id);
		}

		public List<Team> GetList()
		{
			return _teamDal.GetListAll();
		}

        public List<KeyValuePair<int, double>> GetAverageTeamScores()
        {
            var teamScores = new List<KeyValuePair<int, double>>();
            var teams = _teamDal.GetListAll();
            foreach (var team in teams)
            {
                var averageScore = _ratingDal.GetAverageRatingByTeam(team.TeamId);
                teamScores.Add(new KeyValuePair<int, double>(team.TeamId, averageScore));
            }

            return teamScores;
        }

        public void UpdateTeam(Team team)
		{
			throw new NotImplementedException();
		}

        public Dictionary<Team, int> GetTeamsWithUserCount()
        {
            return _teamDal.GetTeamsWithUserCount();
        }

        public int GetUserCountByTeamId(int teamId)
        {
            using (var context = new Context())  // 'YourDbContext' yerine gerçek DbContext sınıfınızın adını kullanmalısınız
            {
                var userCount = context.UserTeams.Where(ut => ut.TeamId == teamId).Count();
                return userCount;
            }
        }
    }
}
