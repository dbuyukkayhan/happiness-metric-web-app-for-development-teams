using HappinessMetricAppForDevelopmentTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappinessMetricAppForDevelopmentTeam.ViewComponents
{
    public class PostList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var postValues = new List<UserPost>
            {
                new UserPost
                {
                    Id = 1,
                    UserName = "Mehmet"
                },
                new UserPost
                {
                    Id = 2,
                    UserName = "Ahmet"
                },
                new UserPost
                {
                    Id = 3,
                    UserName = "Mesut"
                },
            };

            return View(postValues);
        }
    }
}
