using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Northwind.Model;
using System.Data.Entity.Infrastructure;

namespace Northwind.Repository.Api
{
    public interface IEFContext : IDisposable
    {
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }        

        int SaveChanges();
    }
}
