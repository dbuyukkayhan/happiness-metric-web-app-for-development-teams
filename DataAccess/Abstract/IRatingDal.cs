﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRatingDal : IGenericDal<Rating>
    {
        double GetAverageRatingByTeam(int teamId);
        bool HasUserRatedSprint(int userId, int sprintId);
        int GetNumberOfUsersRated(int teamId, int sprintId);
        Rating GetRatingByCategoryId(int categoryId);
        List<Rating> GetRatingsBySprintId(int sprintId);
    }
}
