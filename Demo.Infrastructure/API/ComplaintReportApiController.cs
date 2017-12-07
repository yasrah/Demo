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
            newReport.Parts = ctx.Parts.Where(p => p.PartId == id).ToList();
            //var selectedDealer = ctx.Dealers.SingleOrDefault(d => d.DealerId == Int32.Parse(model.DealerName));

            //newReport.Dealer = selectedDealer;
            //newReport.Dealer = selectedDealer;

            var re = ctx.ComplaintReports.Add(newReport);
            ctx.SaveChanges();

            var newCreatedReport = ctx.ComplaintReports.Include(a => a.Customer).Include(a => a.ProductModel).SingleOrDefault(d => d.ComplaintReportId == re.ComplaintReportId);

            //return new Domain.Models.NewComplaintReportViewModel(re);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(newCreatedReport.ComplaintReportId.ToString()) };
        }

    }
}
