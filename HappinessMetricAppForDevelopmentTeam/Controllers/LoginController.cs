using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User p)
        {
            Context c = new Context();
            var dataValue = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail && x.UserPassword == p.UserPassword);

            if(dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserEmail),
                    new Claim(ClaimTypes.NameIdentifier, dataValue.UserId.ToString()), // Kullanıcının id'sini ekleyin.
                    new Claim("UserName", dataValue.UserName),
                    new Claim("UserId", dataValue.UserId.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}
//Context c = new Context();
//var dataValue = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail && x.UserPassword == p.UserPassword);

//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", p.UserEmail);
//    return RedirectToAction("Index", "Team");
//}
//return View();