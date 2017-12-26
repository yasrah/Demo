using Demo.Core.Models;
using Demo.Infrastructure;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using Demo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
                var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Where(E => !E.ErrorMessage.IsNullOrWhiteSpace()).Select(c => c.ErrorMessage)
                    .ToList();
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Join(",", validationErrors.Select(e => e)))
                };
            }

            //Get ProductModel
            //var productModels = ctx.ProductModels.Where(pm => model.ProductModels.Contains(pm.ProductModelId)).ToList();

            // Customer
            var newCustomer = new Customer()
            {
                Name = model.Customer.Name,
                Address = model.Customer.Address,
                CustomerType = model.Customer.CustomerType
            };
            var newCreatedCustomer = ctx.Customers.Add(newCustomer);
            ctx.SaveChanges();

            // Report
            var newReport = new ComplaintReport()
            {
                MachineNo1 = model.MachineNo1,
                MachineNo2 = model.MachineNo2,

                //Forhandler/Member
                MemberId = memberRepo.GetCurrentMemberId(),

                //Kunde
                CustomerId = newCreatedCustomer.CustomerId,

                ProductModelId = (int)model.ProductModel,
                EngineNo = model.EngineNo,

                TimeAmount = (int)model.TimeAmount,
                SaleDate = (DateTime)model.SaleDate,
                DamageDate = (DateTime)model.DamageDate,
                RepairDate = (DateTime)model.RepairDate,

                Error = model.Error,
                ReasonForError = model.ReasonForError,
                PartsMarked = model.PartsMarked,
                PartsReturned = model.PartsReturned,
                CreateEmail = model.CreateEmail,
                Status = Status.Draft,
                //Closed = model.Closed,

                CreatedByDealerDate = DateTime.Now,
                LastEditedByDealerId = memberRepo.GetCurrentMemberId(),

            };

            //var id = model.Parts.First().PartId;
            //var reportPart = new ComplaintReportPart
            //{
            //    ComplaintReport = newReport,
            //    Part = ctx.Parts.SingleOrDefault(p => p.PartId == id),
            //    Amount = model.Parts.First().Amount
            //};

            var partsToAdd = model.Parts.Select(p => new ComplaintReportPart
            {
                ComplaintReport = newReport,
                Part = ctx.Parts.SingleOrDefault(pa => pa.PartId == p.PartId),
                Amount = p.Amount
            });


            ctx.ComplaintReportParts.AddRange(partsToAdd);
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
            //var report = complaintReportRepo.GetComplaintReportById(reportId, memberRepo.IsCurrentMemberAdmin());

            //if (report == null)
            //{

            //}
            return complaintReportRepo.GetComplaintReportById(reportId, memberRepo.IsCurrentMemberAdmin());
        }

        [HttpGet]
        public HttpResponseMessage SendToApproval(int reportId)
        {
            if (string.IsNullOrEmpty(reportId.ToString()))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }
            var updateResult = complaintReportRepo.SendComplaintReportToApproval(reportId);
            if (updateResult == -1)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Problme updating report") };
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Sent to approval") };
        }

        [HttpGet]
        public HttpResponseMessage Approve(int reportId)
        {
            if (string.IsNullOrEmpty(reportId.ToString()))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }

            if (!memberRepo.IsCurrentMemberAdmin())
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Du har ikke lov å godkjenne") };
            }
            var updateResult = complaintReportRepo.Approve(reportId);
            if (updateResult == -1)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Problme updating report") };
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Sent to approval") };
        }

        [HttpGet]
        public HttpResponseMessage SendToDraft(int reportId)
        {
            if (string.IsNullOrEmpty(reportId.ToString()))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }
            if (!memberRepo.IsCurrentMemberAdmin())
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Du har ikke lov å sende report til draft") };
            }
            var updateResult = complaintReportRepo.SendToDraft(reportId);
            if (updateResult == -1)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Problme updating report") };
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Sent to approval") };
        }
        [HttpGet]
        public HttpResponseMessage Deny(int reportId)
        {
            if (string.IsNullOrEmpty(reportId.ToString()))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }
            if (!memberRepo.IsCurrentMemberAdmin())
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Du har ikke lov å avslå") };
            }
            var updateResult = complaintReportRepo.Deny(reportId);
            if (updateResult == -1)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Problme updating report") };
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Sent to approval") };
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
                .SingleOrDefault(r => r.ComplaintReportId == model.ComplaintReportId);

            if (!memberRepo.IsCurrentMemberAdmin() && report.Status != Status.Draft)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Du har ikke lov til dette!") };

            }
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

            var partsToAdd = model.Parts.Select(p =>
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
            report.Status = model.Status;
            report.Closed = model.Closed;
            report.LastEditedByDealerId = memberRepo.GetCurrentMemberId();

            // Update Customer
            report.Customer.Name = model.Customer.Name;
            report.Customer.Address = model.Customer.Address;
            report.Customer.CustomerType = model.Customer.CustomerType;

            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            ctx.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(updatedReport.ComplaintReportId.ToString()) };
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public ComplaintReportWrapper GetMyComplaintReport(DataTableViewModel data)
        {
            var re = Request
                    .GetQueryNameValuePairs()
                    .ToDictionary(x => x.Key, x => x.Value);

            int page = (data.start / data.length) + 1;
            int toSkip = (page - 1) * data.length;
            int tot = 0;
            int filteredTot = 0;

            var reports = ctx.ComplaintReports
                .Join(ctx.ProductModels, r => r.ProductModelId, pm => pm.ProductModelId, (r, pm) => r)
                .Include(cr => cr.Customer)
                .Include(cr => cr.ProductModel)
                .Include(n => n.ProductModel.Product)
                .Include(n => n.ComplaintReportParts.Select(crp => crp.Part));
            //.Join(
            //    members,
            //    cr => cr.MemberId,
            //    m => m.DealerId,
            //    (cr, m) => new { Reports = cr, Member = m }
            //);

            if (!memberRepo.IsCurrentMemberAdmin())
            {
                var id = memberRepo.GetCurrentMemberId();
                reports = reports.Where(r => r.MemberId == id);
            }


            var list = new List<ComplaintReport>();
            IEnumerable<ExistingComplaintReportViewModel> reportsViewMOdel = null;
            if (data.search != null & data.search.value != null & data.search.value != "")
            {

                string search = data.search.value.ToLower();

                var members = memberRepo.GetAllMembers();
                //var members2 = members.Select(m => new MyPageViewModel(m));
                var memberIds = members.Where(m => new MyPageViewModel(m).Name.ToLower().Contains(search)).Select(m => m.Id.ToString());

                reports = reports
                    .Where(r => r.ComplaintReportId.ToString().Contains(search) ||
                    memberIds.Contains(r.MemberId.ToString()) ||
                    r.Customer.Name.ToLower().Contains(search) ||
                    r.Customer.CustomerType.ToLower().Contains(search) ||
                    r.ProductModel.Name.ToLower().Contains(search) ||
                    r.ProductModel.Product.Name.ToLower().Contains(search) ||
                    r.Customer.Address.ToLower().Contains(search));

                DateTime parsedDate;
                if (DateTime.TryParseExact(search, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    reports = reports.Where(
                        r => DbFunctions.TruncateTime(r.SaleDate) == DbFunctions.TruncateTime(parsedDate) ||
                        DbFunctions.TruncateTime(r.DamageDate) == parsedDate.Date ||
                        DbFunctions.TruncateTime(r.RepairDate) == parsedDate.Date);
                }
            }
            tot = reports.Count();
            filteredTot = reports.Count();
            if (toSkip > 0)
            {
                reportsViewMOdel = reports.AsEnumerable().Skip(toSkip).Take(data.length).Select(c => new ExistingComplaintReportViewModel(c));
            }
            else
            {
                if (data.length == -1)
                {
                    reportsViewMOdel = reports.AsEnumerable().Select(c => new ExistingComplaintReportViewModel(c));
                }
                else
                {
                    reportsViewMOdel = reports.AsEnumerable().Take(data.length).Select(c => new ExistingComplaintReportViewModel(c));
                }
            }

            //order7
            var dir = data.order.First().dir.ToString();
            var col = data.order.First().column.ToString();

            switch (col)
            {
                case "0":
                    if (dir.Equals("asc"))
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderBy(r => r.ComplaintReportId);
                    }
                    else
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderByDescending(r => r.ComplaintReportId);
                    }
                    break;
                case "1":
                    if (dir.Equals("asc"))
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderBy(r => r.Dealer.Name);
                    }
                    else
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderByDescending(r => r.Dealer.Name);
                    }
                    break;
                case "2":
                    if (dir.Equals("asc"))
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderBy(r => r.Customer.Name);
                    }
                    else
                    {
                        reportsViewMOdel = reportsViewMOdel.OrderByDescending(r => r.Customer.Name);
                    }
                    break;

                default:
                    break;
            }
            return new ComplaintReportWrapper { data = reportsViewMOdel, recordsTotal = tot, recordsFiltered = filteredTot };

        }


        public ComplaintReportsDashboardData GetComplaintReportsDashboardData()
        {
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

        public List<ComplaintReportsDashboardDonutVM> GetComplaintReportsDashboardDataForDonutChart()
        {
            //var data = new ComplaintReportsDashboardDonutVM()
            //{
            //    DraftReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Kladd")),
            //    SentToApprovalTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Sendt til godkjenning")),
            //    ApprovedReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Godkjent")),
            //    DeclinedReportsTotal = ctx.ComplaintReports.Count(cr => cr.Status.Equals("Avslått")),
            //};
            //data.TotalReports = data.DraftReportsTotal + data.SentToApprovalTotal + data.ApprovedReportsTotal + data.DeclinedReportsTotal;
            //return data;
            return new List<ComplaintReportsDashboardDonutVM>()
            {
                new ComplaintReportsDashboardDonutVM()
                {
                    Label = "Til godkjenning",
                    Value = 10
                },
                new ComplaintReportsDashboardDonutVM()
                {
                    Label = "Godkjent",
                    Value = 11
                },
                new ComplaintReportsDashboardDonutVM()
                {
                    Label = "Avslått",
                    Value = 12
                }
            };
        }

        public List<ChartViewModel> GetComplaintReportsDashboardChart()
        {
            var res = ctx.ComplaintReports.GroupBy(cr => DbFunctions.TruncateTime(cr.CreatedByDealerDate)).ToList().Select(a => new ChartViewModel()
            {
                Period = ((DateTime)a.Key).ToString("dd.MM.yyyy"),
                Count = a.Count()
            });

            return res.ToList();
            //return new List<ChartViewModel>(){
            //    new ChartViewModel() { Period = "2011.11.11", Itouch = 2100, Ipad = 2510, Iphone= 3100},
            //    new ChartViewModel() { Period = "2012.12.02", Itouch = 2200, Ipad = 1000, Iphone= 3200},
            //    new ChartViewModel() { Period = "2013.06.03", Itouch = 2300, Ipad = 2530, Iphone= 3300},
            //    new ChartViewModel() { Period = "2014.09.04", Itouch = 2400, Ipad = 3000, Iphone= 3400},
            //    new ChartViewModel() { Period = "2015.04.05", Itouch = 2500, Ipad = 1500, Iphone= 3500}'
            //};
        }
    }
}
