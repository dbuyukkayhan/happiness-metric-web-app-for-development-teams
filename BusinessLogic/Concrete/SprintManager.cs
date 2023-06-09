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
    public class SprintManager : ISprintService
    {
        ISprintDal _sprintDal;
        public SprintManager(ISprintDal sprintDal)
        {
            _sprintDal = sprintDal;
        }
        public void AddSprint(Sprint sprint)
        {
            _sprintDal.Insert(sprint);
        }

        public void DeleteSprint(Sprint sprint)
        {
            throw new NotImplementedException();
        }

        public Sprint GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sprint> GetList()
        {
            throw new NotImplementedException();
        }

        public void UpdateSprint(Sprint sprint)
        {
            throw new NotImplementedException();
        }

        public Sprint GetActiveSprintByTeamId(int teamId)
        {
            return _sprintDal.GetActiveSprintByTeamId(teamId);
        }
        public List<Sprint> GetSprintsByTeamId(int teamId)
        {
            return _sprintDal.GetSprintsByTeamId(teamId);
        }

    }
}
