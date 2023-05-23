using BusinessLogic.Abstract;
using DataAccess.Abstract;
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

		public TeamManager(ITeamDal teamDal)
		{
			_teamDal = teamDal;
		}

		public void AddTeam(Team team)
		{
			throw new NotImplementedException();
		}

		public void DeleteTeam(Team team)
		{
			throw new NotImplementedException();
		}

		public Team GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Team> GetList()
		{
			return _teamDal.GetListAll();
		}

		public void UpdateTeam(Team team)
		{
			throw new NotImplementedException();
		}
	}
}
