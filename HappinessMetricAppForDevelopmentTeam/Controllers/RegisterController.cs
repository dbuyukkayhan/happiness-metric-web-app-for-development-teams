using BusinessLogic.Concrete;
using BusinessLogic.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HappinessMetricAppForDevelopmentTeam.Controllers
{
    public class RegisterController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository(), new EFRoleRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User p, string confirmPassword) 
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(p);

            if(results.IsValid)
            {
                if (p.UserPassword != confirmPassword)
                {
                    ModelState.AddModelError("confirmPassword", "Passwords do not match.");
                    return RedirectToAction("Index");
                }
                p.IsActive = true;

                userManager.AddUser(p);

                return RedirectToAction("Index", "Team");
            } 
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
