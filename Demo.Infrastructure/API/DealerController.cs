using Domain.Context;
using SmartHus4.Models;
using SmartHus4.Repositories;
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
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Web.WebApi;

namespace SmartHus4.API
{
    [Umbraco.Web.WebApi.MemberAuthorize]
    public class DealerController : UmbracoApiController // UmbracoAuthorizedApiController
    {
        readonly DealerNetworkContext ctx = new DealerNetworkContext();
        public IEnumerable<string> GetAllDealers()
        {
            //var t = GetCurrentUserId();
            return new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };
        }

        public int GetCurrentUserId()
        {
            var memberService = ApplicationContext.Services.MemberService;
            var memberHelper = new Umbraco.Web.Security.MembershipHelper(UmbracoContext);
            IPublishedContent member = memberHelper.GetCurrentMember();
            var id = member.Id;
            return id;
        }

        public MyPageViewModel GetMyPageData()
        {
            return new MyPageViewModel();
        }

        public List<Domain.Models.Product> GetProducts()
        {
            return ctx.Products.ToList();
        }

        public List<string> GetAllCustomersName()
        {
            return ctx.Customers.Select(c => c.Name).ToList();
        }

        public List<Domain.Models.ProductModel> GetProductModels(int productId)
        {
            return ctx.ProductModels.Where(pm => pm.ProductId == productId).ToList();
        }

        public MyPageViewModel UpdateMyPageData(MyPageViewModel model)
        {

            var memberService = Services.MemberService;
            var member = memberService.GetById(model.Id);

            if (member == null)
            {
                // TODO something wrong!
            }
            member.Name = model.Name;
            member.SetValue("firstname", model.FirstName);
            member.SetValue("lastname", model.LastName);
            memberService.Save(member);


            return new MyPageViewModel();

        }

        public HttpResponseMessage UpdateComplaintReport(Domain.Models.EditComplaintReportViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return null;
            //}
            ////var report = ctx.ComplaintReports.SingleOrDefault(r => r.ComplaintReportId == model.ComplaintReportId);
            ////report.Name = model.Name;

            //var result = ctx.SaveChanges();

            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Rett opp feilene!") };
            }

            //Get ProductModel
            //var productModels = ctx.ProductModels.Where(pm => model.ProductModels.Contains(pm.ProductModelId)).ToList();

            var report = ctx.ComplaintReports.Find(model.ComplaintReportId);


            report.MachineNo1 = model.MachineNo1;
            report.MachineNo2 = model.MachineNo2;
            //report.DealerId = 1;
            report.CustomerId = 1;
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
            report.Status = (Domain.Models.Status?)model.Status;
            report.Closed = model.Closed;
            report.CreatedByDealerDate = DateTime.Now;
            report.LastEditedByDealerId = GetCurrentUserId();


            var updatedReport = ctx.ComplaintReports.Attach(report);
            ctx.Entry(report).State = EntityState.Modified;
            ctx.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(updatedReport.ComplaintReportId.ToString()) };
        }

        public HttpResponseMessage NewComplaintReport(Domain.Models.NewComplaintReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            //Get ProductModel
            //var productModels = ctx.ProductModels.Where(pm => model.ProductModels.Contains(pm.ProductModelId)).ToList();

            var newReport = new Domain.Models.ComplaintReport()
            {
                MachineNo1 = model.MachineNo1,
                MachineNo2 = model.MachineNo2,

                //Forhandler
                MemberId = GetCurrentUserId(),

                //Kunde
                CustomerId = 1,

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
                Status = (Domain.Models.Status?)model.Status,
                Closed = model.Closed,


                CreatedByDealerDate = DateTime.Now,
                LastEditedByDealerId = GetCurrentUserId()
            };
            //var selectedDealer = ctx.Dealers.SingleOrDefault(d => d.DealerId == Int32.Parse(model.DealerName));

            //newReport.Dealer = selectedDealer;
            //newReport.Dealer = selectedDealer;

            var report = ctx.ComplaintReports.Add(newReport);

            var result = ctx.SaveChanges();
            var re = ctx.ComplaintReports.Include(a => a.Customer).Include(a => a.ProductModel).SingleOrDefault(d => d.ComplaintReportId == report.ComplaintReportId);

            //return new Domain.Models.NewComplaintReportViewModel(re);
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(re.ComplaintReportId.ToString()) };
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage DeleteComplaintReport(int complaintReportId)
        {

            var report = ctx.ComplaintReports.SingleOrDefault(d => d.ComplaintReportId == complaintReportId);
            if (report == null)
            {

            }
            var res = ctx.ComplaintReports.Remove(report);
            var result = ctx.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("ComplaintReport is removed!")
            };
        }


        public HttpResponseMessage UpdateMyPageData2(MyPageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Kontaktskjema er ikke utfylt riktig!")
                };
            }

            //System.Threading.Thread.Sleep(2000);
            //var isEmailSent = Helpers.Helper.SendEmail(form);
            if (4 == 4)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Noe gikk galt! Vennligst prøv igjen! Nettside-administrator er informert om feilen.")
                };
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Takk for din kontakt!")
            };
        }



        // GET: /AdminDashboardNotificationsApi/
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Dealer> Dealers()
        {

            // If admin is logged in
            if (true)//GetCurrentUserId() != 0)
            {
                //Connect to custom table DB
                var db = ApplicationContext.DatabaseContext.Database;

                //Get list of notifications to iterate over
                var notifications = db.Query<Dealer>("SELECT * FROM dbo.Dealer").ToList();

                return notifications;
            }
            else
            {
                // Not logged in so forbid
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Reclamation> DealerComplaintReportsOld(int dealerId)
        {

            // If admin is logged in
            if (true)//GetCurrentUserId() != 0)
            {
                //Connect to custom table DB
                var db = ApplicationContext.DatabaseContext.Database;

                //Get list of notifications to iterate over
                var notifications = db.Query<Reclamation>("SELECT * FROM dbo.Reclamation WHERE DealerId =@0", dealerId).ToList();

                return notifications;
            }
            else
            {
                // Not logged in so forbid
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
        public JsonResult<List<ComplaintReport>> GetMyComplaintReportOrg()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;

            var query = new Sql().Select("*").From("ComplaintReport").Where<ComplaintReport>(x => x.DealerId == 1);
            var data = db.Fetch<ComplaintReport, Dealer>(query);
            return Json(data);
        }

        public async Task<JsonResult<ICollection<ComplaintReportViewModel>>> GetMyComplaintReportok()
        {
            //UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;

            //var sql = Sql.Builder
            //    .Select("*")
            //    .From("ComplaintReport c")
            //    .InnerJoin("Dealer d").On("c.DealerId = d.Id");

            //var res = db.Fetch<ComplaintReport>(sql);
            //return Json(res);


            //Student stud = new Student() { StudentName = "New Student" };
            //ctx.Students.Add(stud);
            //ctx.SaveChanges();

            var reports = (await ctx.ComplaintReports.Where(c => c.MemberId == 1).ToListAsync()).Select(
                 c => new ComplaintReportViewModel(c)).ToList();
            //c => new ComplaintReportViewModel {
            //    DealerName = c.Dealer.Name,
            //    ComplaintReportId = c.ComplaintReportId,
            //    Name = c.Name,
            //    Dealer = c.Dealer,
            //    ComplaintReport = c
            //}).ToList();
            return Json<ICollection<ComplaintReportViewModel>>(reports);

        }
        public int GetUnprocessedCompalintReportsCount()
        {
            var reports = ctx.ComplaintReports.Where(r => r.ComplaintReportId < 500);

            return reports.Count();
        }

        public int GetUnderProcessCompalintReportsCount()
        {
            var reports = ctx.ComplaintReports.Where(r => r.ComplaintReportId >= 500 && r.ComplaintReportId < 700);

            return reports.Count();
        }

        [Umbraco.Web.WebApi.MemberAuthorize(AllowGroup = "Forhandlernett Admin")]
        public int GetProcessedCompalintReportsCount()
        {
            var reports = ctx.ComplaintReports.Where(r => r.ComplaintReportId >= 700);

            return reports.Count();
        }

        public Domain.Models.ComplaintReportViewModel GetComplaintReport(int id)
        {
            var report = ctx.ComplaintReports.Include(cr => cr.Customer).Include(cr => cr.ProductModel.Product).SingleOrDefault(r => r.ComplaintReportId == id);
            var reportViewModel = new Domain.Models.ComplaintReportViewModel(report);

            var productModel = ctx.ProductModels.Where(pm => pm.ProductModelId == report.ProductModelId).First();
            var productModels = ctx.ProductModels.Where(pm => pm.ProductId == productModel.ProductId).ToList();
            var products = ctx.Products.ToList();


            reportViewModel.Products = products.Select(m => new Domain.Models.ProductViewModel(m)).ToList();
            reportViewModel.ProductModels = productModels.Select(m => new Domain.Models.ProductModelViewModel(m)).ToList();
            return reportViewModel;
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public ComplaintReportWrapper GetMyComplaintReport(DataTableViewModel data)
        {
            var re = Request
                    .GetQueryNameValuePairs()
                    .ToDictionary(x => x.Key, x => x.Value);
            //string search = Request.QueryString["search[value]"];
            //UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;

            //var sql = Sql.Builder
            //    .Select("*")
            //    .From("ComplaintReport c")
            //    .InnerJoin("Dealer d").On("c.DealerId = d.Id");

            //var res = db.Fetch<ComplaintReport>(sql);
            //return Json(res);


            //Student stud = new Student() { StudentName = "New Student" };
            //ctx.Students.Add(stud);
            //ctx.SaveChanges();
            int page = (data.start / data.length) + 1;
            int toSkip = (page - 1) * data.length;
            int tot = 0;
            int filteredTot = 0;

            var reports = ctx.ComplaintReports
                .Include(cr => cr.Customer)
                .Include(cr => cr.ProductModel)
                .Include(n => n.ProductModel.Product);

            if (!new MembershipRepository().isDealerAdmin())
            {
                reports = reports.Where(r => r.MemberId == GetCurrentUserId());
            }

            IEnumerable<Domain.Models.ComplaintReportViewModel> reportsViewMOdel = null;
            if (data.search != null & data.search.value != null & data.search.value != "")
            {
                string search = data.search.value;

                reports = reports.Where(
                    r => r.ComplaintReportId.ToString().Contains(search) ||
                    r.Customer.Name.Contains(search));
            }
            tot = reports.Count();
            filteredTot = reports.Count();
            if (toSkip > 0)
            {
                reportsViewMOdel = reports.AsEnumerable().Skip(toSkip).Take(data.length).Select(c => new Domain.Models.ComplaintReportViewModel(c));
            }
            else
            {
                if (data.length == -1)
                {
                    reportsViewMOdel = reports.AsEnumerable().Select(c => new Domain.Models.ComplaintReportViewModel(c));
                }
                else
                {
                    reportsViewMOdel = reports.AsEnumerable().Take(data.length).Select(c => new Domain.Models.ComplaintReportViewModel(c));
                }
            }
            return new ComplaintReportWrapper { data = reportsViewMOdel, recordsTotal = tot, recordsFiltered = filteredTot };

        }
        public List<ChartViewModel> GetChart1()
        {

            return new List<ChartViewModel>(){
                new ChartViewModel() { Period = "2011.11.11", Itouch = 2100, Ipad = 2510, Iphone= 3100},
                new ChartViewModel() { Period = "2012.12.02", Itouch = 2200, Ipad = 1000, Iphone= 3200},
                new ChartViewModel() { Period = "2013.06.03", Itouch = 2300, Ipad = 2530, Iphone= 3300},
                new ChartViewModel() { Period = "2014.09.04", Itouch = 2400, Ipad = 3000, Iphone= 3400},
                new ChartViewModel() { Period = "2015.04.05", Itouch = 2500, Ipad = 1500, Iphone= 3500}};
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<ComplaintReport> GetMyComplaintReportsOld2()
        {

            // If admin is logged in
            if (true)//GetCurrentUserId() != 0)
            {
                //Connect to custom table DB
                var db = ApplicationContext.DatabaseContext.Database;
                var currentDealerId = 1; // GetCurrentUserId();
                //Get list of notifications to iterate over
                //var reports = db.Query<ComplaintReport>("SELECT * FROM dbo.ComplaintReport WHERE DealerId =@0", currentDealerId);
                var reports = db.Fetch<ComplaintReport>(new Sql().Select("*").From("ComplaintReport").Where<ComplaintReport>(r => r.DealerId == currentDealerId));

                return reports;
            }
            else
            {
                // Not logged in so forbid
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
        public List<Dealer> GetAll()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            return db.Fetch<Dealer>(new Sql().Select("*").From("Dealer"));
        }
        public int GetDealersCount()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            return db.ExecuteScalar<int>(new Sql().Select("COUNT(Id)").From("Dealer"));
        }
        public int GetReportsCount()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            //return db.Fetch<ComplaintReport>(new Sql().Select("*").From("ComplaintReport")).Count();
            return db.ExecuteScalar<int>(new Sql().Select("COUNT(Id)").From("ComplaintReport"));

        }



        //[Umbraco.Web.WebApi.UmbracoAuthorize]
        public Dealer GetById(int id)
        {
            var query = new Sql().Select("*").From("Dealer").Where<Dealer>(x => x.Id == id);
            return DatabaseContext.Database.Fetch<Dealer>(query).FirstOrDefault();
        }

        public JsonResult<Dealer> GetByIdJson(int id)
        {
            var query = new Sql().Select("*").From("Dealer").Where<Dealer>(x => x.Id == id);
            var data = DatabaseContext.Database.Fetch<Dealer>(query).FirstOrDefault();
            return Json(data);
        }

        public Dealer Save(Dealer dealer)
        {
            if (dealer != null)
            {
                if (dealer.Id > 0)
                {
                    DatabaseContext.Database.Update(dealer);
                }
                else
                {
                    //dealer.CreatedOn = DateTime.Now;
                    //dealer. = Services.UserService.GetByUsername(HttpContext.Current.User.Identity.Name).Id;
                    DatabaseContext.Database.Save(dealer);
                }
            }
            return dealer;
        }
    }

}

//if (Membership.ValidateUser(model.Email, model.Password))
//{
//    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
//    return Redirect("/");
//}
//var m = memberService.GetById(membro.Id);
//var userService = ApplicationContext.Services.UserService;
//int id=  userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id;
//var m = memberService.GetById(membro.Id);
//var userService = ApplicationContext.Services.UserService;
//int id=  userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id;

//var m = memberService.GetById(membro.Id);
//var userService = ApplicationContext.Services.UserService;
//int id=  userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id;
