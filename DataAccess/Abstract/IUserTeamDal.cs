using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserTeamDal : IGenericDal<UserTeam>
    {
        UserTeam GetUserTeamById(int userId, int teamId, int roleId);
        bool IsUserMemberOfTeam(int userId, int teamId);
    }
}
