using Demo.Core.Models;
using Demo.Infrastructure.Attribute;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class NewComplaintReportViewModel
    {
        public NewComplaintReportViewModel()
        {

        }
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

        [Required]
        public string MachineNo1 { get; set; }

        [Required]
        public string MachineNo2 { get; set; }

        [Required]
        public DateTime? SaleDate { get; set; }

        [Required]
        public DateTime? DamageDate { get; set; }

        [Required]
        public DateTime? RepairDate { get; set; }

        [Required]
        public int? TimeAmount { get; set; }

        [Required]
        public string EngineNo { get; set; }

        [Required]
        public CustomerViewModel Customer { get; set; }
        //public int CustomerId { get; set; }

        [Required(ErrorMessage = "ProductModel må oppgis!")]
        public int? ProductModel { get; set; }

        //public int Status { get; set; }

        //[Required]
        //public bool Closed { get; set; }

        [Required]
        public string Error { get; set; }

        [Required]
        public string ReasonForError { get; set; }

        public bool PartsMarked { get; set; }

        public bool PartsReturned { get; set; }

        public bool CreateEmail { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "Deler: Minst en del må oppgis.")]
        public List<PartViewModel> Parts { get; set; }

        //public bool SentToApproval { get; set; }
    }
}
