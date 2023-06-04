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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void AddRole(Role role)
        {
            _roleDal.Insert(role);
        }

        public void DeleteRole(Role role)
        {
            _roleDal.Delete(role);
        }

        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public List<Role> GetList(int id)
        {
            return _roleDal.GetListAll();
        }

        public void UpdateRole(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
