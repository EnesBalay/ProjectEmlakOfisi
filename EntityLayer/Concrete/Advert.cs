using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Advert
    {
        [Key]
        public int AdvertID { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public DateTime AdvertCreateDate { get; set; }
        public decimal AdvertPrice { get; set; }
        public string AdvertThumbnail { get; set; }
        public string AdvertImage1 { get; set; }
        public string AdvertImage2 { get; set; }
        public string AdvertImage3 { get; set; }
        public string AdvertImage4 { get; set; }
        public string AdvertImage5 { get; set; }
        public int HousingAge { get; set; }
        public int HousingRoomQuantity { get; set; }
        public int HousingHallQuantity { get; set; }
        public int HousingSquareMeters { get; set; }
        public string AdvertSaleType { get; set; }
        public bool AdvertStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
