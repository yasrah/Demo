﻿using Demo.Core.Models;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            report.SentToApproval = true;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            return ctx.SaveChanges();
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