using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectEmlakOfisiUI.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEmlakOfisiUI.Controllers
{
    public class UserController : Controller
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
            var signedUserID = userManager.GetUserByIdentityName(User.Identity.Name).UserID;
            var userInformations = userManager.GetById(signedUserID);
            return View(userInformations);
        }

        [HttpGet]
        public IActionResult EditUserProfile(int id)
        {
            valuesDef();
            var userInformations = userManager.GetById(id);
            return View(userInformations);

        }
        [HttpPost]
        public IActionResult EditUserProfile(User user)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(user);
            if (results.IsValid)
            {
                userManager.Update(user);
                return RedirectToAction("Index", "User");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}
