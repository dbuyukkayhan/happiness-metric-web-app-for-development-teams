using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRoleService
    {
        void AddRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetList(int id);
        Role GetById(int id);
    }
}
