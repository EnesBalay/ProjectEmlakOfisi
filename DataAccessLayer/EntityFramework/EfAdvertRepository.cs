using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAdvertRepository : GenericRepository<Advert>, IAdvertDal
    {
        public List<Advert> GetAdvertWithCategoryByFilters(string searchFilter, bool advertStatus, string saleType, int categoryID, int userID)
        {
            using (var c = new Context())
            {
                if (searchFilter != null)
                {
                    if (saleType == null)
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertStatus == advertStatus).
                                Where(x => x.AdvertName.ToLower().Contains(searchFilter.ToLower())).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertStatus == advertStatus).
                                Where(x => x.AdvertName.ToLower().Contains(searchFilter.ToLower())).ToList();
                        }
                    }
                    else
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertStatus == advertStatus).
                                Where(x => x.AdvertSaleType == saleType).
                                Where(x => x.AdvertName.ToLower().Contains(searchFilter.ToLower())).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertSaleType == saleType).
                                Where(x => x.AdvertStatus == advertStatus).
                                Where(x => x.AdvertName.ToLower().Contains(searchFilter.ToLower())).ToList();
                        }
                    }
                }
                else
                {
                    if (saleType == null)
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertStatus == advertStatus).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertStatus == advertStatus).ToList();
                        }
                    }
                    else
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertStatus == advertStatus).
                                Where(x => x.AdvertSaleType == saleType).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertSaleType == saleType).
                                Where(x => x.AdvertStatus == advertStatus).ToList();
                        }
                    }
                }
            }
        }

        public List<Advert> GetAdvertWithCategoryByFiltersWithoutStatus(string searchValue, string saleType, int categoryID, int userID)
        {
            using (var c = new Context())
            {
                if (searchValue != null)
                {
                    if (saleType == null)
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertName.ToLower().Contains(searchValue.ToLower())).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertName.ToLower().Contains(searchValue.ToLower())).ToList();
                        }
                    }
                    else
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertSaleType == saleType).
                                Where(x => x.AdvertName.ToLower().Contains(searchValue.ToLower())).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertSaleType == saleType).
                                Where(x => x.AdvertName.ToLower().Contains(searchValue.ToLower())).ToList();
                        }
                    }
                }
                else
                {
                    if (saleType == null)
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).ToList();
                        }
                    }
                    else
                    {
                        if (categoryID == 0)
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.AdvertSaleType == saleType).ToList();
                        }
                        else
                        {
                            return c.Adverts.Include(x => x.Category).ToList().
                                Where(x => x.UserID == userID).
                                Where(x => x.CategoryID == categoryID).
                                Where(x => x.AdvertSaleType == saleType).ToList();
                        }
                    }
                }
            }
        }

        public List<Advert> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Adverts.Include(x => x.Category).ToList();
            }
        }

        public List<Advert> GetListWithCategoryByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Adverts.Include(x => x.Category).Where(x => x.UserID == id).ToList();
            }
        }
    }
}
