using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IRoleDal _roleDal;
        public UserManager(IUserDal userDal, IRoleDal roleDal)
        {
            _userDal = userDal;
            _roleDal = roleDal;
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll();
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }

        public Dictionary<Team, Role> GetUserTeamsWithRoles(int userId)
        {
            Context c = new Context();

            var userTeams = c.UserTeams.Where(ut => ut.UserId == userId && ut.IsActive == true).ToList();

            Dictionary<Team, Role> teamAndRoles = new Dictionary<Team, Role>();

            foreach (var userTeam in userTeams)
            {
                var team = c.Teams.FirstOrDefault(t => t.TeamId == userTeam.TeamId);
                var role = _roleDal.GetById(userTeam.RoleId);
                teamAndRoles.Add(team, role);
            }

            return teamAndRoles;
        }
    }
}
