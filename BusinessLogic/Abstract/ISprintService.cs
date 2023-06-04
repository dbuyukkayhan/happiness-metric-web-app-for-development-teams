using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISprintService
    {
        void AddSprint(Sprint sprint);
        void DeleteSprint(Sprint sprint);
        void UpdateSprint(Sprint sprint);
        List<Sprint> GetList();
        Sprint GetById(int id);
        Sprint GetActiveSprintByTeamId(int teamId);
    }
}
