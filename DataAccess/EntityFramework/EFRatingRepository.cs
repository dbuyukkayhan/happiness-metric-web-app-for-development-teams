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

        public bool HasUserRatedSprint(int userId, int sprintId)
        {
            Context c = new Context();
            return c.Ratings.Any(r => r.UserId == userId && r.SprintId == sprintId);
        }

        public int GetNumberOfUsersRated(int teamId, int sprintId)
        {
            Context c = new Context();
            var teamUserIds = c.UserTeams.Where(ut => ut.TeamId == teamId).Select(ut => ut.UserId).ToList();

            return c.Ratings
                .Where(r => r.SprintId == sprintId && teamUserIds.Contains(r.UserId))
                .Select(r => r.UserId)
                .Distinct()
                .Count();
        }

        public Rating GetRatingByCategoryId(int categoryId)
        {
            Context c = new Context();
            return c.Ratings.FirstOrDefault(r => r.CategoryId == categoryId);
        }

        public List<Rating> GetRatingsBySprintId(int sprintId)
        {
            Context c = new Context();
            return c.Set<Rating>().Where(r => r.SprintId == sprintId).ToList();
        }
    }
}
