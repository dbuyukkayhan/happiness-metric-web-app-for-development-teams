using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EFTeamRepository : GenericRepository<Team>, ITeamDal
    {
        Context c = new Context();
        public Dictionary<Team, int> GetTeamsWithUserCount()
        {
            return c.Set<Team>().Include(t => t.UserTeams).ToDictionary(t => t, t => t.UserTeams.Count);
        }
    }
}
