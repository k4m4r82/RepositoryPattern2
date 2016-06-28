
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Northwind.Model;
using Northwind.Repository.Api;
using System.Data.Entity;

namespace Northwind.Repository.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository()
        {
        }

        public Category GetByID(int categoryId)
        {
            Category category = null;

            try
            {
                using (IEFContext context = new EFContext())
                {
                    category = context.Categories.Where(f => f.CategoryID == categoryId)
                                      .SingleOrDefault();
                }                
            }
            catch
            {
            }

            return category;
        }

        public IList<Category> GetByName(string categoryName)
        {
            IList<Category> listOfCategory = new List<Category>();

            try
            {
                using (IEFContext context = new EFContext())
                {
                    listOfCategory = context.Categories
                                            .Where(f => f.CategoryName.ToLower().Contains(categoryName.ToLower()))
                                            .OrderBy(f => f.CategoryName)
                                            .ToList();
                }                
            }
            catch
            {
            }

            return listOfCategory;
        }

        public IList<Category> GetAll()
        {
            IList<Category> listOfCategory = new List<Category>();

            try
            {
                using (IEFContext context = new EFContext())
                {
                    listOfCategory = context.Categories
                                            .OrderBy(f => f.CategoryName)
                                            .ToList();
                }                
            }
            catch
            {
            }

            return listOfCategory;
        }

        public int Save(Category obj)
        {
            var result = 0;            

            try
            {
                using (IEFContext context = new EFContext())
                {
                    context.Entry(obj).State = EntityState.Added;
                    context.SaveChanges();
                }                

                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public int Update(Category obj)
        {
            var result = 0;

            try
            {
                using (IEFContext context = new EFContext())
                {
                    context.Entry(obj).State = EntityState.Modified;
                    context.SaveChanges();
                }                

                result = 1;
            }
            catch
            {
            }

            return result;
        }

        public int Delete(Category obj)
        {
            var result = 0;            

            try
            {
                using (IEFContext context = new EFContext())
                {
                    context.Entry(obj).State = EntityState.Deleted;
                    context.SaveChanges();
                }                

                result = 1;
            }
            catch
            {
            }

            return result;
        }        
    }
}
