using Demo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Context
{
    public class DealerNetworkContext: DbContext
    {
        public DealerNetworkContext(): base("name=umbracoDbDSN")
        {
            Configuration.ProxyCreationEnabled = false;//this is line to be added
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DealerNetworkContext, Migrations.Configuration>("umbracoDbDSN"));
        }

        //public DbSet<Dealer> Dealers { get; set; }
        //public DbSet<ComplaintReport> ComplaintReports { get; set; }
        //public DbSet<ComplaintPart> ComplaintParts { get; set; }
        //public DbSet<ComplaintExpense> ComplaintExpenses { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductModel> ProductModels { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        ////public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ComplaintReport>()
            //    .HasMany(p => p.ProductModels)
            //    .WithMany( c => c.ComplaintReports)
            //    .Map(m =>
            //    {
            //        m.ToTable("ComplaintReportProductModels");
            //        m.MapLeftKey("ComplaintReportId");
            //        m.MapRightKey("ProductModelId");
            //    });
            base.OnModelCreating(modelBuilder);
        }

    }
}
