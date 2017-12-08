using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class EditComplaintReportViewModel
    {

        public EditComplaintReportViewModel(ComplaintReport c)
        {
        }


        public int ComplaintReportId{ get; set; }
        public string MachineNo1 { get; set; }
        public string MachineNo2 { get; set; }
        public int DealerId { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DamageDate { get; set; }
        public DateTime RepairDate { get; set; }
        public int TimeAmount { get; set; }
        public string EngineNo { get; set; }
        public CustomerViewModel Customer { get; set; }
        public int CustomerId { get; set; }
        public int ProductModel { get; set; }
        public int? Status { get; set; }
        public bool Closed { get; set; }
        public string Error { get; set; }
        public string ReasonForError { get; set; }
        public bool PartsMarked { get; set; }
        public bool PartsReturned { get; set; }
        public bool CreateEmail { get; set; }
        public List<PartViewModel> Parts { get; set; }

    }
}
