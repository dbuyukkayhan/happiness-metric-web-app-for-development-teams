using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface ITeamService 
	{
        void AddTeam(Team team);
        void DeleteTeam(Team team);
        void UpdateTeam(Team team);
        List<Team> GetList();
        Team GetById(int id);
    }
}
