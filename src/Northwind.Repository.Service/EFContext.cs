using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Northwind.Model;
using Northwind.Model.Mapping;
using Northwind.Repository.Api;

namespace Northwind.Repository.Service
{
    public partial class EFContext : DbContext, IEFContext
    {
        static EFContext()
        {
            Database.SetInitializer<EFContext>(null);
        }

        public EFContext()
            : base("Name=EFContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
