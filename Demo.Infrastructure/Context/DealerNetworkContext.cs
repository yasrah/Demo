using Demo.Core.Models;
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

        public DbSet<ComplaintReport> ComplaintReports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ComplaintReportPart> ComplaintReportParts { get; set; }

        ////public DbSet<Dealer> Dealers { get; set; }
        //public DbSet<Dealer> Dealers { get; set; }
        //public DbSet<ComplaintPart> ComplaintParts { get; set; }
        //public DbSet<ComplaintExpense> ComplaintExpenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ComplaintReport>()
            //    .HasMany(p => p.Parts)
            //    .WithMany(c => c.ComplaintReports)
            //    .Map(m =>
            //    {
            //        m.ToTable("ComplaintReportParts");
            //        m.MapLeftKey("ComplaintReportId");
            //        m.MapRightKey("PartId");
            //    });

            base.OnModelCreating(modelBuilder);
        }

    }
}
