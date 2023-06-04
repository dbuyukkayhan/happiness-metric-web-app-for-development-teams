using BusinessLogic.Concrete;
using DataAccess.EntityFramework;
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

		public PartialViewResult PartialAddPost()
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
