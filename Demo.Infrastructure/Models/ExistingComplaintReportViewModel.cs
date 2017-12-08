using Demo.Core.Models;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Umbraco.Core;

namespace Demo.Infrastructure
{
    public class ExistingComplaintReportViewModel
    {
        public ExistingComplaintReportViewModel()
        {

        }
        public ExistingComplaintReportViewModel(ComplaintReport c)
        {
            ComplaintReportId = c.ComplaintReportId;
            MachineNo1 = c.MachineNo1;
            MachineNo2 = c.MachineNo2;
            DealerId = c.MemberId;
            SaleDate = c.SaleDate;
            DamageDate = c.DamageDate;
            RepairDate = c.RepairDate;
            TimeAmount = c.TimeAmount;
            EngineNo = c.EngineNo;
            Customer = new CustomerViewModel()
            {
                CustomerId = c.Customer.CustomerId,
                Name = c.Customer.Name,
                Address = c.Customer.Address,
                CustomerType = (int)c.Customer.CustomerType

            };

            var memberShipHelper = new Umbraco.Web.Security.MembershipHelper(Umbraco.Web.UmbracoContext.Current);
            var memberId = memberShipHelper.GetCurrentMemberId();
            var memberService = ApplicationContext.Current.Services.MemberService;
            var m = memberService.GetById(memberId);
            Dealer = new DealerViewModel(m);

            Product = new ProductViewModel(c.ProductModel.Product);
            ProductModel = new ProductModelViewModel(c.ProductModel);
            Status = (int?)c.Status;

            SelectedProduct = c.ProductModel.ProductId;
            SelectedProductModel = c.ProductModelId;

            Closed = c.Closed;
            Error = c.Error;
            ReasonForError = c.ReasonForError;
            PartsMarked = c.PartsMarked;
            PartsReturned = c.PartsReturned;
            CreateEmail = c.CreateEmail;

            //Parts = new List<PartViewModel>();


            //Parts.AddRange(c.ComplaintReportParts.Select(p => 
            //    new PartViewModel(){
            //        PartId = p.PartId,
            //        Description = p.Description,
            //        PartNo = p.PartNo,
            //        Price = p.Price,
            //        Shipping = p.Shipping,
            //    }));

            var parts = c.ComplaintReportParts.Select(p =>
                 new PartViewModel()
                 {
                     PartId = p.PartId,
                     Description = p.Part.Description,
                     PartNo = p.Part.PartNo,
                     Price = p.Part.Price,
                     Shipping = p.Part.Shipping,
                     Amount = p.Amount
                 });
            Parts = new List<PartViewModel>();
            Parts.AddRange(parts);
            SentToApproval = c.SentToApproval;
        }

        public int ComplaintReportId { get; set; }
        public string MachineNo1 { get; set; }
        public string MachineNo2 { get; set; }
        public int DealerId { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DamageDate { get; set; }
        public DateTime RepairDate { get; set; }
        public int TimeAmount { get; set; }
        public string EngineNo { get; set; }
        //public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public DealerViewModel Dealer { get; set; }
        public ProductViewModel Product { get; set; }
        public ProductModelViewModel ProductModel { get; set; }
        public int SelectedProduct { get; set; }
        public int SelectedProductModel { get; set; }
        public int? Status { get; set; }
        public bool Closed { get; set; }
        public string Error { get; set; }
        public string ReasonForError { get; set; }
        public bool PartsMarked { get; set; }
        public bool PartsReturned { get; set; }
        public bool CreateEmail { get; set; }

        public List<ProductViewModel> Products { get; set; }
        public List<ProductModelViewModel> ProductModels { get; set; }
        public List<PartViewModel> Parts { get; set; }
        public bool SentToApproval { get; set; }

    }
}
