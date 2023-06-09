using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EFSprintRepository : GenericRepository<Sprint>, ISprintDal
    {
        Context c = new Context();


        public Sprint GetActiveSprintByTeamId(int teamId)
        {
            var currentDate = DateTime.Now;
            return c.Set<Sprint>().FirstOrDefault(s => s.TeamId == teamId && s.SprintStart <= currentDate && s.SprintEnd >= currentDate);
        }

        public List<Sprint> GetSprintsByTeamId(int teamId)
        {
            return c.Set<Sprint>().Where(s => s.TeamId == teamId).ToList();
        }
    }
}
