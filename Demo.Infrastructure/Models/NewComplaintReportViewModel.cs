using Demo.Core.Models;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class NewComplaintReportViewModel
    {

        public NewComplaintReportViewModel(ComplaintReport c)
        {
            //MachineNo1 = c.MachineNo1;
            //MachineNo2 = c.MachineNo2;
            //DealerId = c.DealerId;
            //SaleDate = c.SaleDate;
            //DamageDate = c.DamageDate;
            //RepairDate = c.RepairDate;
            //TimeAmount = c.TimeAmount;
            //EngineNo = c.EngineNo;
            //CustomerId = c.Customer.CustomerId;
            //ProductModel = c.ProductModel.ProductModelId;
            //Status = (int)c.Status;
            //Closed = c.Closed;
            //Error = c.Error;
            //ReasonForError = c.ReasonForError;
            //PartsMarked = c.PartsMarked;
            //PartsReturned = c.PartsReturned;
            //CreateEmail = c.CreateEmail;

        }

        public string MachineNo1 { get; set; }
        public string MachineNo2 { get; set; }
        public int DealerId { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DamageDate { get; set; }
        public DateTime RepairDate { get; set; }
        public int TimeAmount { get; set; }
        public string EngineNo { get; set; }
        public CustomerViewModel Customer { get; set; }
        public int ProductModel { get; set; }
        public int CustomerId { get; set; }
        public int? Status { get; set; }
        public bool Closed { get; set; }
        public string Error { get; set; }
        public string ReasonForError { get; set; }
        public bool PartsMarked { get; set; }
        public bool PartsReturned { get; set; }
        public bool CreateEmail { get; set; }
        public List<PartViewModel> Parts{ get; set; }
        public bool SentToApproval { get; set; }
    }
}
