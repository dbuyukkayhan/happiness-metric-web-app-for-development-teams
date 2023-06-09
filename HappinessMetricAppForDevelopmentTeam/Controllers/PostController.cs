using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
	public class PostController : Controller
	{
		PostManager postManager = new PostManager(new EFPostRepository());
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public PartialViewResult PartialAddPost(Post p)
		{

			return PartialView();
		}
		public PartialViewResult PostListByBlog(int id)
		{
			var values = postManager.GetList(id);
			return PartialView(values);
		}
	}
}
