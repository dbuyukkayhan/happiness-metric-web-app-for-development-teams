using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IUserTeamService
    {
        void AddUserTeam(UserTeam userTeam);
        UserTeam GetUserTeamById(int userId, int teamId, int roleId);
        void UpdateUserTeam(UserTeam userTeam);
        List<UserTeam> GetActiveUserTeams(int userId);
    }
}
