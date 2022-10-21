using Microsoft.AspNetCore.Http;
using System;

namespace ProjectEmlakOfisiUI.Models
{
    public class AddAdvertImage
    {
        public int AdvertID { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public DateTime AdvertCreateDate { get; set; }
        public decimal AdvertPrice { get; set; }
        public IFormFile AdvertThumbnail { get; set; }
        public IFormFile AdvertImage1 { get; set; }
        public IFormFile AdvertImage2 { get; set; }
        public IFormFile AdvertImage3 { get; set; }
        public IFormFile AdvertImage4 { get; set; }
        public IFormFile AdvertImage5 { get; set; }
        public string AdvertImage1Name { get; set; }
        public string AdvertImage2Name { get; set; }
        public string AdvertImage3Name { get; set; }
        public string AdvertImage4Name { get; set; }
        public string AdvertImage5Name { get; set; }
        public int HousingAge { get; set; }
        public int HousingRoomQuantity { get; set; }
        public int HousingHallQuantity { get; set; }
        public int HousingSquareMeters { get; set; }
        public string AdvertSaleType { get; set; }
        public bool AdvertStatus { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
    }
}
