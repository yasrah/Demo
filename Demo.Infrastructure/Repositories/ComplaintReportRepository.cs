using Demo.Core.Models;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Umbraco.Core.Logging;

namespace Demo.Infrastructure.Repositories
{
    public class ComplaintReportRepository
    {
        readonly DealerNetworkContext ctx = new DealerNetworkContext();
        public List<Customer> GetAllCustomersName(string query)
        {
            return ctx.Customers.Where(c => c.Name.Contains(query)).ToList();
        }

        public List<PartViewModel> GetPartsByQuery(string query)
        {
            return ctx.Parts.Where(c => c.Description.Contains(query) || c.PartNo.ToString().Contains(query))
                .Select(p => new PartViewModel
                {
                    PartId = p.PartId,
                    PartNo = p.PartNo,
                    Description = p.Description,
                    Price = p.Price,
                    Shipping = p.Shipping,
                    Amount = 1,
                }).ToList();
        }

        public int SendComplaintReportToApproval(int reportId)
        {
            var report = ctx.ComplaintReports.SingleOrDefault(r => r.ComplaintReportId == reportId);
            report.Status = Status.SentToApproval;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            return ctx.SaveChanges();
        }

        public int Approve(int reportId)
        {
            var report = ctx.ComplaintReports.SingleOrDefault(r => r.ComplaintReportId == reportId);
            report.Status = Status.Approved;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            return ctx.SaveChanges();
        }

        public int SendToDraft(int reportId)
        {
            var report = ctx.ComplaintReports.SingleOrDefault(r => r.ComplaintReportId == reportId);
            report.Status = Status.Draft;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            return ctx.SaveChanges();
        }

        public int Deny(int reportId)
        {
            var report = ctx.ComplaintReports.SingleOrDefault(r => r.ComplaintReportId == reportId);
            report.Status = Status.NotApproved;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            return ctx.SaveChanges();
        }

        public ComplaintReportsDashboardData GetDashboradData()
        {
            try
            {
                //var z = 0;
                //var op = 1 / z;
                var data = new ComplaintReportsDashboardData()
                {
                    DraftReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Kladd")),
                    SentToApprovalTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Sendt til godkjenning")),
                    ApprovedReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Godkjent")),
                    DeclinedReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Avslått")),
                };
                data.TotalReports = data.DraftReportsTotal + data.SentToApprovalTotal + data.ApprovedReportsTotal + data.DeclinedReportsTotal;
                return data;
            }
            catch (Exception x)
            {
                LogHelper.Error(typeof(ComplaintReportRepository), "", x);
                return null;
            }
        }

        public ExistingComplaintReportViewModel GetComplaintReportById(int reportId, bool isAdmin = false)
        {
            var report = ctx.ComplaintReports
                .Include(cr => cr.ComplaintReportParts.Select(p => p.Part))
                .Include(cr => cr.Customer)
                .Include(cr => cr.ProductModel.Product)
                .SingleOrDefault(r => r.ComplaintReportId == reportId);

            if (!isAdmin && report.SentToApproval)
            {
                return null;
            }
            var reportViewModel = new ExistingComplaintReportViewModel(report);

            var productModel = ctx.ProductModels.Where(pm => pm.ProductModelId == report.ProductModelId).First();
            var productModels = ctx.ProductModels.Where(pm => pm.ProductId == productModel.ProductId).ToList();
            var products = ctx.Products.ToList();

            reportViewModel.Products = products.Select(m => new ProductViewModel(m)).ToList();
            reportViewModel.ProductModels = productModels.Select(m => new ProductModelViewModel(m)).ToList();

            return reportViewModel;
            //return ctx.ComplaintReports.SingleOrDefault(cr => cr.ComplaintReportId == reportId);
        }
    }
}
