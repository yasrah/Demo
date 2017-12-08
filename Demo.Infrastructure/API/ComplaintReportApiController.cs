using Demo.Core.Models;
using Demo.Infrastructure;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using Demo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace Demo.API
{
    [MemberAuthorize]
    public class ComplaintReportApiController : UmbracoApiController // UmbracoAuthorizedApiController
    {
        readonly DealerNetworkContext ctx = new DealerNetworkContext();
        readonly MyPageRepository myPageRepo = new MyPageRepository();
        readonly MemberRepository memberRepo = new MemberRepository();
        readonly ComplaintReportRepository complaintReportRepo = new ComplaintReportRepository();

        public MyPageViewModel GetMyPageData()
        {
            System.Threading.Thread.Sleep(1000);
            var currentMember = myPageRepo.GetCurrentMember();
            return new MyPageViewModel(currentMember);
        }
        public MyPageViewModel UpdateMyPageData(MyPageViewModel model)
        {
            var myPageData = myPageRepo.UpdateMyPageData(model);
            return myPageData;
        }
        public List<Product> GetProducts()
        {
            return ctx.Products.ToList();
        }

        public List<ProductModel> GetProductModels(int productId)
        {
            return ctx.ProductModels.Where(pm => pm.ProductId == productId).ToList();
        }
        public List<Customer> GetAllCustomersName(string query)
        {
            return complaintReportRepo.GetAllCustomersName(query);
        }

        public List<PartViewModel> GetPartsByQuery(string query)
        {
            return complaintReportRepo.GetPartsByQuery(query);
        }

        public HttpResponseMessage NewComplaintReport(NewComplaintReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            //Get ProductModel
            //var productModels = ctx.ProductModels.Where(pm => model.ProductModels.Contains(pm.ProductModelId)).ToList();

            var newCustomer = new Customer()
            {
                Name = model.Customer.Name,
                Address = model.Customer.Address,
                CustomerType = (CustomerType)model.Customer.CustomerType
            };

            var newCreatedCustomer = ctx.Customers.Add(newCustomer);
            ctx.SaveChanges();

            var newReport = new ComplaintReport()
            {
                MachineNo1 = model.MachineNo1,
                MachineNo2 = model.MachineNo2,

                //Forhandler
                MemberId = memberRepo.GetCurrentMemberId(),

                //Kunde
                CustomerId = newCreatedCustomer.CustomerId,

                ProductModelId = model.ProductModel,
                EngineNo = model.EngineNo,

                TimeAmount = model.TimeAmount,
                SaleDate = model.SaleDate,
                DamageDate = model.DamageDate,
                RepairDate = model.RepairDate,

                Error = model.Error,
                ReasonForError = model.ReasonForError,
                PartsMarked = model.PartsMarked,
                PartsReturned = model.PartsReturned,
                CreateEmail = model.CreateEmail,
                Status = (Status?)model.Status,
                Closed = model.Closed,


                CreatedByDealerDate = DateTime.Now,
                LastEditedByDealerId = memberRepo.GetCurrentMemberId(),
                
            };

            var id = model.Parts.First().PartId;
            var reportPart = new ComplaintReportPart
            {
                ComplaintReport = newReport,
                Part = ctx.Parts.SingleOrDefault(p => p.PartId == id),
                Amount = model.Parts.First().Amount
            };

            ctx.ComplaintReportParts.Add(reportPart); 
            //ctx.SaveChanges();

            //var selectedDealer = ctx.Dealers.SingleOrDefault(d => d.DealerId == Int32.Parse(model.DealerName));

            //newReport.Dealer = selectedDealer;
            //newReport.Dealer = selectedDealer;

            var re = ctx.ComplaintReports.Add(newReport);
            ctx.SaveChanges();

            var newCreatedReport = ctx.ComplaintReports.Include(a => a.Customer).Include(a => a.ProductModel).SingleOrDefault(d => d.ComplaintReportId == re.ComplaintReportId);

            //return new Domain.Models.NewComplaintReportViewModel(re);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(newCreatedReport.ComplaintReportId.ToString()) };
        }

        public ExistingComplaintReportViewModel GetComplaintReportById(int reportId)
        {
            return complaintReportRepo.GetComplaintReportById(reportId);
        }

        public HttpResponseMessage UpdateComplaintReport(EditComplaintReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }

            var report = ctx.ComplaintReports
                .Include(r => r.Customer)
                .Include(r => r.ComplaintReportParts.Select(crp => crp.Part))
                .SingleOrDefault( r => r.ComplaintReportId == model.ComplaintReportId);

            report.MachineNo1 = model.MachineNo1;
            report.MachineNo2 = model.MachineNo2;

            report.CustomerId = model.Customer.CustomerId;

            // Update Parts
            // First delete old ones
            var partsToBeDeleted = report.ComplaintReportParts;
            if (partsToBeDeleted != null)
            {
                ctx.ComplaintReportParts.RemoveRange(partsToBeDeleted);
                ctx.SaveChanges();
            }


            // TEST START

            var partsToAdd = model.Parts.Select( p => 
            new ComplaintReportPart
            {
                ComplaintReport = report,
                Part = ctx.Parts.SingleOrDefault(pa => pa.PartId == p.PartId),
                Amount = model.Parts.First().Amount
            });

            // TEST END


            //// Add new ones
            //var partId = model.Parts.First().PartId;
            //var reportPart = new ComplaintReportPart
            //{
            //    ComplaintReport = report,
            //    Part = ctx.Parts.SingleOrDefault(p => p.PartId == partId),
            //    Amount = model.Parts.First().Amount
            //};
            ctx.ComplaintReportParts.AddRange(partsToAdd);


            //var newProductModel = new ProductModel()
            //{
            //   ProductModelId = model.ProductModel.ProductModelId,
            //   ProductId = model.Product.ProductId,
            //   Name = model.ProductModel.Name,
            //};
            report.ProductModelId = model.ProductModel;

            report.EngineNo = model.EngineNo;
            report.TimeAmount = model.TimeAmount;
            report.SaleDate = model.SaleDate;
            report.DamageDate = model.DamageDate;
            report.RepairDate = model.RepairDate;
            report.Error = model.Error;
            report.ReasonForError = model.ReasonForError;
            report.PartsMarked = model.PartsMarked;
            report.PartsReturned = model.PartsReturned;
            report.CreateEmail = model.CreateEmail;
            report.Status = (Status?)model.Status;
            report.Closed = model.Closed;
            report.LastEditedByDealerId = memberRepo.GetCurrentMemberId();

            // Update Customer
            report.Customer.Name = model.Customer.Name;
            report.Customer.Address = model.Customer.Address;
            report.Customer.CustomerType = (CustomerType)model.Customer.CustomerType;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            ctx.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(updatedReport.ComplaintReportId.ToString()) };
        }
    }
}
