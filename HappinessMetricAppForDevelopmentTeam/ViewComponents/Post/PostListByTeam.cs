using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.ViewComponents.Post
{
	public class PostListByTeam : ViewComponent
	{
		PostManager postManager = new PostManager(new EFPostRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = postManager.GetPostsWithUser().Where(x => x.TeamId == id).OrderByDescending(s => s.PostTime);
            //var values = postManager.GetList(id);
			return View(values);
		}
	}
}
