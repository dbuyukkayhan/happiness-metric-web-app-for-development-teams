using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EFRatingRepository : GenericRepository<Rating>, IRatingDal
    {
        public double GetAverageRatingByTeam(int teamId)
        {
            Context c = new Context();
            var ratings = c.Ratings.Include(r => r.Sprint).Where(r => r.Sprint.TeamId == teamId);
            if (ratings.Any())
            {
                return ratings.Average(r => r.RatingScore);
            }

            return 0;
        }
    }
}
