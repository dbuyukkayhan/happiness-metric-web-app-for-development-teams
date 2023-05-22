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
    public class TeamRepository : ITeamDal
    {
        Context c = new Context();
        public void AddTeam(Team team)
        {
            c.Add(team);
            c.SaveChanges();
        }

        public void Delete(Team t)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Team team)
        {
            c.Remove(team);
            c.SaveChanges();
        }

        public Team GetById(int id)
        {
            return c.Teams.Find(id);
        }

        public List<Team> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Team t)
        {
            throw new NotImplementedException();
        }

        public List<Team> ListAllTeam()
        {
            return c.Teams.ToList();
        }

        public void Update(Team t)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            c.Update(team);
            c.SaveChanges();
        }
    }
}
