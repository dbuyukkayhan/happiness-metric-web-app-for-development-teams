using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserDal
    {
        Context c = new Context();
        public void AddUser(User user)
        {
            c.Add(user);
            c.SaveChanges();
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            c.Remove(user);
            c.SaveChanges();
        }

        public User GetById(int id)
        {
            return c.Users.Find(id);
        }

        public List<User> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> ListAllUser()
        {
            return c.Users.ToList();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            c.Update(user);
            c.SaveChanges();
        }
    }
}
