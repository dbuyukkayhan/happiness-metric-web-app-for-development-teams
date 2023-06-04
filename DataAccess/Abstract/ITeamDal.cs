using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITeamDal : IGenericDal<Team>
    {
        Dictionary<Team, int> GetTeamsWithUserCount();
        
    }
}
