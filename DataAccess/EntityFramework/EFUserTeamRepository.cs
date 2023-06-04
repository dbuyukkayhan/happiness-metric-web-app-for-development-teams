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
    public class EFUserTeamRepository : GenericRepository<UserTeam>, IUserTeamDal
    {
        public UserTeam GetUserTeamById(int userId, int teamId, int roleId)
        {
            Context c = new Context();
            return c.UserTeams.FirstOrDefault(ut => ut.UserId == userId && ut.TeamId == teamId && ut.RoleId == roleId);
        }

        public bool IsUserMemberOfTeam(int userId, int teamId)
        {
            using (Context c = new Context())
            {
                var userTeam = c.UserTeams.FirstOrDefault(ut => ut.UserId == userId && ut.TeamId == teamId && ut.IsActive == true);
                if (userTeam != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    
}

