using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class UserTeamManager
    {
        IUserTeamDal _userTeamDal;

        public void AddUserTeam(UserTeam userTeam)
        {
            _userTeamDal.Insert(userTeam);
        }
        public UserTeamManager(IUserTeamDal userTeamDal)
        {
            _userTeamDal = userTeamDal;
        }

        public UserTeam GetUserTeamById(int userId, int teamId, int roleId)
        {
            return _userTeamDal.GetUserTeamById(userId, teamId, roleId);
        }

        public void UpdateUserTeam(UserTeam userTeam)
        {
            _userTeamDal.Update(userTeam);
        }

        public List<UserTeam> GetActiveUserTeams(int userId)
        {
            return _userTeamDal.GetListAll().Where(ut => ut.UserId == userId && ut.IsActive).ToList();
        }

        public bool IsUserMemberOfTeam(int userId, int teamId)
        {
            return _userTeamDal.IsUserMemberOfTeam(userId, teamId);
        }
    }
}
