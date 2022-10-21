using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ProjectEmlakOfisiUI.Models;
using System;
using System.IO;

namespace ProjectEmlakOfisiUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());

        public IActionResult Index(string Search = null)
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType == "Admin")
            {

                if (Search != null)
                {
                    var searchValue = userManager.GetUserBySearch(Search);
                    return View(searchValue);
                }
                var value = userManager.GetListAll();
                return View(value);
            }
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });
        }
        [HttpGet]
        public IActionResult UserAdd()
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType == "Admin")
            {
                return View();
            }
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });
        }
        [HttpPost]
        public IActionResult UserAdd(AddProfileImage userProfile)
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType == "Admin")
            {
                User user = new User();
                user.Password = "123456";
                user.UserStatus = true;
                user.UserName = userProfile.UserName;
                user.Email = userProfile.Email;
                user.CompanyName = userProfile.CompanyName;
                user.Name = userProfile.Name;
                user.Surname = userProfile.Surname;
                user.AccountType = userProfile.AccountType;
                if (userProfile.Image != null)
                {
                    var extension = Path.GetExtension(userProfile.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Users/Images/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    userProfile.Image.CopyTo(stream);
                    user.Image = newImageName;
                }
                UserValidatorForAdmin uv = new UserValidatorForAdmin();
                ValidationResult results = uv.Validate(user);
                if (results.IsValid)
                {
                    userManager.Add(user); return RedirectToAction("Index", "User");
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
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });

        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType == "Admin")
            {
                AddProfileImage addProfileImage = new AddProfileImage();
                var userInformations = userManager.GetById(id);
                addProfileImage.UserID = userInformations.UserID;
                addProfileImage.UserName = userInformations.UserName;
                addProfileImage.Password = userInformations.Password;
                addProfileImage.Name = userInformations.Name;
                addProfileImage.Surname = userInformations.Surname;
                addProfileImage.Email = userInformations.Email;
                addProfileImage.UserStatus = userInformations.UserStatus;
                addProfileImage.AccountType = userInformations.AccountType;
                addProfileImage.CompanyName = userInformations.CompanyName;
                addProfileImage.ImageName = userInformations.Image;
                return View(addProfileImage);
            }
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });

        }

        [HttpPost]
        public IActionResult UserEdit(AddProfileImage userProfile)
        {
            var userValues = userManager.GetUserByIdentityName(User.Identity.Name);
            if (userValues.AccountType == "Admin")
            {
                User user = new User();
                user.UserID = userProfile.UserID;
                user.UserName = userProfile.UserName;
                user.Password = "123456";
                user.CompanyName = userProfile.CompanyName;
                user.Email = userProfile.Email;
                user.Name = userProfile.Name;
                user.Surname = userProfile.Surname;
                user.AccountType = userProfile.AccountType;
                user.UserStatus = userProfile.UserStatus;
                if (userProfile.Image != null)
                {
                    var extension = Path.GetExtension(userProfile.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Users/Images/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    userProfile.Image.CopyTo(stream);
                    user.Image = newImageName;
                }
                else
                {
                    user.Image = userProfile.ImageName;
                }
                UserValidatorForAdmin userValidator = new UserValidatorForAdmin();
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
                return View(userProfile);
            }
            return RedirectToAction("NoAuthorize", "Login", new { area = "" });
        }

        public IActionResult UserDelete(int id)
        {
            var signedUserID = userManager.GetUserByIdentityName(User.Identity.Name).UserID;
            User deleteUser = userManager.GetById(id);
            if (signedUserID != id)
            {
                userManager.Remove(deleteUser);
            }
            else
            {
                return RedirectToAction("Index", "User", "dontdelete");
            }
            return RedirectToAction("Index", "User");
        }
    }
}