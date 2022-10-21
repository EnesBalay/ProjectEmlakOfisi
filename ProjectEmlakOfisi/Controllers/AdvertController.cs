using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectEmlakOfisiUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEmlakOfisiUI.Controllers
{
    public class AdvertController : Controller
    {
        AdvertManager AdvertManager = new AdvertManager(new EfAdvertRepository());
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        List<SelectListItem> categoryValues = new List<SelectListItem>();

        public void valuesDef()
        {
            categoryValues.Add(new SelectListItem { Text = "Hepsi", Value = "" });
            foreach (var x in CategoryManager.GetListAll())
            {
                categoryValues.Add(new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() });
            }

            ViewBag.cv = categoryValues;

            List<SelectListItem> saleTypes = new List<SelectListItem>();
            saleTypes.Add(new SelectListItem { Text = "Hepsi", Value = "" });
            saleTypes.Add(new SelectListItem { Text = "Satılık", Value = "Satılık" });
            saleTypes.Add(new SelectListItem { Text = "Kiralık", Value = "Kiralık" });
            ViewBag.st = saleTypes;
        }


        public IActionResult Index()
        {
            return RedirectToAction("AdvertListByUser");
        }

        public IActionResult AdvertListByUser(string Search = null, string AdvertStatus = null, string SaleType = null, int AdvertCategory = 0)
        {

            var signedUserID = userManager.GetUserByIdentityName(User.Identity.Name).UserID;
            var values = AdvertManager.GetAdvertListWithCategoryByUser(signedUserID);
            valuesDef();
            ViewBag.aStatus = AdvertStatus;
            if (AdvertStatus == "All")
            {
                values = AdvertManager.GetAdvertsSearchWithoutStatus(Search, SaleType, AdvertCategory, signedUserID);
                ViewBag.Search = Search;
                return View(values);
            }
            else if (AdvertStatus == "False")
            {
                values = AdvertManager.GetAdvertsSearch(Search, false, SaleType, AdvertCategory, signedUserID);
                ViewBag.Search = Search;
                return View(values);
            }
            else if (AdvertStatus == "True")
            {
                values = AdvertManager.GetAdvertsSearch(Search, true, SaleType, AdvertCategory, signedUserID);
                ViewBag.Search = Search;
                return View(values);
            }
            return View(values);
        }

        [HttpGet]
        public IActionResult AdvertAdd()
        {
            valuesDef();
            return View();
        }
        [HttpPost]
        public IActionResult AdvertAdd(AddAdvertImage advertImage)
        {
            Advert advert = AdvertImageSync(advertImage);
            ValidationResult results;
            if (advertImage.CategoryID == 2)
            {
                AdvertValidatorForPlot av = new AdvertValidatorForPlot();
                results = av.Validate(advert);
            }
            else
            {
                AdvertValidator av = new AdvertValidator();
                results = av.Validate(advert);
            }

            var signedUserID = userManager.GetUserByIdentityName(User.Identity.Name).UserID;
            valuesDef();
            if (results.IsValid)
            {
                advert.AdvertCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                advert.UserID = signedUserID;
                advert.AdvertThumbnail = advert.AdvertImage1;
                AdvertManager.Add(advert);
                return RedirectToAction("AdvertListByUser", "Advert");
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
        public IActionResult DeleteAdvert(int id)
        {
            var advertValue = AdvertManager.GetById(id);
            AdvertManager.Remove(advertValue);
            return RedirectToAction("AdvertListByUser", "Advert");
        }

        [HttpGet]
        public IActionResult UpdateAdvert(int id)
        {
            AddAdvertImage advert = new AddAdvertImage();
            var editAdvert = AdvertManager.GetById(id);
            advert.AdvertID = editAdvert.AdvertID;
            advert.AdvertName = editAdvert.AdvertName;
            advert.AdvertPrice = editAdvert.AdvertPrice;
            advert.AdvertSaleType = editAdvert.AdvertSaleType;
            advert.AdvertImage1Name = editAdvert.AdvertImage1;
            advert.AdvertImage2Name = editAdvert.AdvertImage2;
            advert.AdvertImage3Name = editAdvert.AdvertImage3;
            advert.AdvertImage4Name = editAdvert.AdvertImage4;
            advert.AdvertImage5Name = editAdvert.AdvertImage5;
            advert.HousingAge = editAdvert.HousingAge;
            advert.HousingHallQuantity = editAdvert.HousingHallQuantity;
            advert.HousingRoomQuantity = editAdvert.HousingRoomQuantity;
            advert.HousingSquareMeters = editAdvert.HousingSquareMeters;
            advert.CategoryID = editAdvert.CategoryID;
            advert.AdvertDescription = editAdvert.AdvertDescription;
            advert.AdvertStatus = editAdvert.AdvertStatus;

            valuesDef();
            return View(advert);
        }
        [HttpPost]
        public IActionResult UpdateAdvert(AddAdvertImage advertImage)
        {
            var signedUserID = userManager.GetUserByIdentityName(User.Identity.Name).UserID;
            ViewBag.AddPrice(advertImage.AdvertPrice);
            Advert advert = AdvertImageSync(advertImage);
            advert.UserID = signedUserID;
            advert.AdvertCreateDate = DateTime.Now;
            AdvertManager.Update(advert);
            return RedirectToAction("AdvertListByUser");

        }

        public Advert AdvertImageSync(AddAdvertImage advertImage)
        {
            List<String> advertImages = new List<String>();
            Advert advert = new Advert();
            if (advertImage != null)
            {
                List<IFormFile> images = new List<IFormFile>();
                images.Add(advertImage.AdvertImage1);
                images.Add(advertImage.AdvertImage2);
                images.Add(advertImage.AdvertImage3);
                images.Add(advertImage.AdvertImage4);
                images.Add(advertImage.AdvertImage5);
                List<string> imagesNames = new List<string>();
                imagesNames.Add(advertImage.AdvertImage1Name);
                imagesNames.Add(advertImage.AdvertImage2Name);
                imagesNames.Add(advertImage.AdvertImage3Name);
                imagesNames.Add(advertImage.AdvertImage4Name);
                imagesNames.Add(advertImage.AdvertImage5Name);

                advertImages.Add(advert.AdvertImage1);
                advertImages.Add(advert.AdvertImage2);
                advertImages.Add(advert.AdvertImage3);
                advertImages.Add(advert.AdvertImage4);
                advertImages.Add(advert.AdvertImage5);
                int i = 0;
                foreach (var item in images)
                {
                    if (item != null)
                    {
                        var extension = Path.GetExtension(item.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Adverts/Images/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        item.CopyTo(stream);
                        advertImages[i] = newImageName;

                    }
                    else
                    {
                        advertImages[i] = imagesNames[i];
                    }
                    i++;
                }

            }
            advert.AdvertID = advertImage.AdvertID;
            advert.AdvertName = advertImage.AdvertName;
            advert.AdvertPrice = advertImage.AdvertPrice;
            advert.AdvertSaleType = advertImage.AdvertSaleType;
            advert.HousingAge = advertImage.HousingAge;
            advert.AdvertImage1 = advertImages[0];
            advert.AdvertImage2 = advertImages[1];
            advert.AdvertImage3 = advertImages[2];
            advert.AdvertImage4 = advertImages[3];
            advert.AdvertImage5 = advertImages[4];
            advert.HousingHallQuantity = advertImage.HousingHallQuantity;
            advert.HousingRoomQuantity = advertImage.HousingRoomQuantity;
            advert.HousingSquareMeters = advertImage.HousingSquareMeters;
            advert.CategoryID = advertImage.CategoryID;
            advert.AdvertDescription = advertImage.AdvertDescription;
            advert.AdvertStatus = advertImage.AdvertStatus;
            return advert;
        }
    }
}
