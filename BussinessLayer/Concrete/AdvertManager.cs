using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AdvertManager : IAdvertService
    {
        IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public List<Advert> GetAdvertListWithCategory()
        {
            return _advertDal.GetListWithCategory();
        }

        public List<Advert> GetAdvertListWithCategoryByUser(int id)
        {
            return _advertDal.GetListWithCategoryByUser(id);
        }

        public List<Advert> GetAdvertByID(int id)
        {
            return _advertDal.GetAll(X => X.AdvertID == id);
        }

        public List<Advert> GetAdvertListByUser(int id)
        {
            return _advertDal.GetAll(x => x.UserID == id);
        }

        public void Add(Advert t)
        {
            _advertDal.Add(t);
        }

        public void Remove(Advert t)
        {
            _advertDal.Delete(t);
        }

        public void Update(Advert t)
        {
            _advertDal.Update(t);
        }

        public List<Advert> GetListAll()
        {
            return _advertDal.GetAll();
        }

        public Advert GetById(int id)
        {
            return _advertDal.GetByID(id);
        }

        public List<Advert> GetAdvertsSearch(string searchValue, bool advertStatus, string saleType, int categoryID, int userID)
        {
            return _advertDal.GetAdvertWithCategoryByFilters(searchValue, advertStatus,saleType,categoryID, userID);
        }

        public List<Advert> GetAdvertsSearchWithoutStatus(string searchValue, string saleType, int categoryID, int userID)
        {
            return _advertDal.GetAdvertWithCategoryByFiltersWithoutStatus(searchValue, saleType, categoryID, userID);
        }
    }
}
