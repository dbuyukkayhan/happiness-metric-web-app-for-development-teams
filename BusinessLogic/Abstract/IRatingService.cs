using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRatingService
    {
        bool HasUserRatedSprint(int userId, int sprintId);
        void AddRating(Rating rating);
        Rating GetRatingByCategoryId(int categoryId);
        List<Rating> GetRatingsBySprintId(int sprintId);
    }
}
