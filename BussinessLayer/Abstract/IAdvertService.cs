using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAdvertService : IGenericService<Advert>
    {
        List<Advert> GetAdvertListWithCategory();
        List<Advert> GetAdvertListByUser(int id);
        List<Advert> GetAdvertsSearch(string searchValue,bool advertStatus,string saleType,int categoryID, int userID);
        List<Advert> GetAdvertsSearchWithoutStatus(string searchValue, string saleType, int categoryID, int userID);
    }
}
