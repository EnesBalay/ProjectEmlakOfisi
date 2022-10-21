using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmlakOfisiUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UserManager userManager = new UserManager(new EfUserRepository());
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType=="Admin")
            {
                return View(userValues);
            }
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });
        }

        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
    }
}
