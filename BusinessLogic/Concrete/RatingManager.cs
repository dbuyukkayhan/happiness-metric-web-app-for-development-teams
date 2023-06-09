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
    public class RatingManager : IRatingService
    {
        IRatingDal _ratingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }

        // existing methods...

        public bool HasUserRatedSprint(int userId, int sprintId)
        {
            return _ratingDal.HasUserRatedSprint(userId, sprintId);
        }

        public int GetNumberOfUsersRated(int teamId, int sprintId)
        {
            return _ratingDal.GetNumberOfUsersRated(teamId, sprintId);
        }

        public void AddRating(Rating rating)
        {
            _ratingDal.Insert(rating);
        }
        public Rating GetRatingByCategoryId(int categoryId)
        {
            return _ratingDal.GetRatingByCategoryId(categoryId);
        }

        public List<Rating> GetRatingsBySprintId(int sprintId)
        {
            return _ratingDal.GetRatingsBySprintId(sprintId);
        }
    }
}
