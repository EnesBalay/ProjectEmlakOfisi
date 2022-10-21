using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAdvertDal : IGenericDal<Advert>
    {
        List<Advert> GetListWithCategory();
        List<Advert> GetListWithCategoryByUser(int id);
        List<Advert> GetAdvertWithCategoryByFilters(string searchFilter, bool advertStatus,string saleType,int categoryID, int userID);
        List<Advert> GetAdvertWithCategoryByFiltersWithoutStatus(string searchValue, string saleType, int categoryID, int userID);
    }
}
