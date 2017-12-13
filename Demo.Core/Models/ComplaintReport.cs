using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class ComplaintReport
    {
        public ComplaintReport()
        {
            ComplaintReportParts = new List<ComplaintReportPart>();
        }
        public int ComplaintReportId { get; set; }
        public string MachineNo1 { get; set; }
        public string MachineNo2 { get; set; }
        public int MemberId { get; set; }
        public DateTime CreatedByDealerDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime SaleDate { get; set; }
        public DateTime DamageDate { get; set; }
        public DateTime RepairDate { get; set; }
        public int TimeAmount{ get; set; }
        public string EngineNo { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductModelId { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public string Status { get; set; }
        public bool Closed { get; set; }
        public string Error { get; set; }
        public string ReasonForError{ get; set; }
        public int LastEditedByDealerId { get; set; }
        public string PartsMarked { get; set; }
        public string PartsReturned { get; set; }
        public string CreateEmail { get; set; }
        public bool SentToApproval { get; set; }
        public virtual ICollection<ComplaintReportPart> ComplaintReportParts { get; set; }

    }

    //public enum Status
    //{
    //    Draft = 0,
    //    SentToApproval = 1,
    //    Approved = 2,
    //    NotApproved = 3
    //}
    public static class YesNo
    {
        public const string Yes = "Ja";
        public const string No = "Nei";
    }
    public static class Status
    {
        public const string Draft = "Kladd";
        public const string SentToApproval = "Sendt til godkjenning";
        public const string Approved = "Godkjent";
        public const string NotApproved = "Avslått";
    }
}
