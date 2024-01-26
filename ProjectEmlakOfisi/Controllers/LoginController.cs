using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectEmlakOfisiUI.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);

            if (userValues == null)
            {
                User user = new User();
                user.Email = "1alilacin@gmail.com";
                return View(user);

            }
            else if (userValues.AccountType == "Admin")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            }
            return RedirectToAction("Index", "AgentUI");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User p, string CustomData)
        {
            Context c = new Context();
            var datavalue = c.Users.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password && x.AccountType == p.AccountType);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                if (datavalue.AccountType == "Admin")
                {
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "AgentUI");
                }
            }
            else
            {
                if (p.AccountType == "Admin")
                {
                    ViewBag.LoginErrorAdmin = "Kullanıcı adı ya da şifre hatalı!";
                    ViewBag.AccountType = "Admin";
                    ViewBag.UsernameAdmin = p.UserName;
                    ViewBag.CustomData = CustomData;
                    return View();
                }
                else
                {
                    ViewBag.LoginErrorUser = "Kullanıcı adı ya da şifre hatalı!";
                    ViewBag.AccountType = "User";
                    ViewBag.UsernameUser = p.UserName;
                    ViewBag.CustomData = CustomData;
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

        public IActionResult NoAuthorize()
        {
            return View();
        }
    }
}
