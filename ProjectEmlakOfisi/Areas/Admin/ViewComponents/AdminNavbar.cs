﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmlakOfisiUI.Areas.Admin.ViewComponents
{
    public class AdminNavbar:ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke()
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            return View(userValues);
        }
    }
}