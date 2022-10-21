using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectEmlakOfisiUI.Controllers
{
    public class AgentUIController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        List<SelectListItem> categoryValues = new List<SelectListItem>();

        public void valuesDef()
        {
            categoryValues.Add(new SelectListItem { Text = "", Value = "" });
            foreach (var x in cm.GetListAll())
            {
                categoryValues.Add(new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() });
            }

            ViewBag.cv = categoryValues;

            List<SelectListItem> saleTypes = new List<SelectListItem>();
            saleTypes.Add(new SelectListItem { Text = "", Value = "" });
            saleTypes.Add(new SelectListItem { Text = "Satılık", Value = "Satılık" });
            saleTypes.Add(new SelectListItem { Text = "Kiralık", Value = "Kiralık" });
            ViewBag.st = saleTypes;
        }
        public IActionResult Index()
        {
            valuesDef();
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            Context c = new Context();
            var datavalue = c.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "AgentUI");
            }
            else
            {
                return View();
            }
        }
        public PartialViewResult AgentNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AgentFooterPartial()
        {
            return PartialView();
        }
    }
}
