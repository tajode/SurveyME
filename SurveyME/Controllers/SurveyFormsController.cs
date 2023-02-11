using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyME.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using SurveyME.ModelViews;

namespace SurveyME.Controllers
{
    public class SurveyFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SurveyForms
        public ActionResult Index(int? page)
        {
            List<SurveyForms> mainList = db.SurveyForms_Dbset.ToList();

            var mainministrylist = mainList.GroupBy(x => x.MinistryName)
                .Select(x => new MinistrySurveysModelViews()
                {
                    Ministry = x.Key,
                    SurveyCount = x.Count()
                }).OrderBy(s => s.Ministry).ToList();

            ViewBag.MinistryList = mainministrylist;

            return View(db.SurveyForms_Dbset.OrderBy(s => s.DateofCreation).ToList().ToPagedList(page ?? 1, 1));
        }

        public ActionResult MySurveys(int? page)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserName = User.Identity.GetUserName();
            var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);
            string capturedUserName = user.UserName;

            List<SurveyForms> mainList = db.SurveyForms_Dbset.ToList();

            var mainministrylist = mainList.GroupBy(x => x.MinistryName)
                .Select(x => new MinistrySurveysModelViews()
                {
                    Ministry = x.Key,
                    SurveyCount = x.Count()
                }).OrderBy(s => s.Ministry).ToList();

            ViewBag.MinistryList = mainministrylist;

            return View(db.SurveyForms_Dbset.Where(s => s.UserName.Equals(capturedUserName)).OrderBy(s => s.DateofCreation).ToList().ToPagedList(page ?? 1, 1));
        }

        public ActionResult MainArea(int? page, string theministry)
        {
            List<SurveyForms> mainList = db.SurveyForms_Dbset.ToList();

            var mainministrylist = mainList.GroupBy(x => x.MinistryName)
                .Select(x => new MinistrySurveysModelViews()
                {
                    Ministry = x.Key,
                    SurveyCount = x.Count()
                }).OrderBy(s => s.Ministry).ToList();

            ViewBag.MinistryList = mainministrylist;

            if (theministry == null)
            {
                return View(db.SurveyForms_Dbset.OrderBy(s => s.DateofCreation).ToList().ToPagedList(page ?? 1, 1));
            }
            else
            {
                return View(db.SurveyForms_Dbset.Where(s => s.MinistryName.Contains(theministry)).OrderBy(s => s.DateofCreation).ToList().ToPagedList(page ?? 1, 1));
            }
        }

        // GET: SurveyForms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyForms surveyForms = await db.SurveyForms_Dbset.FindAsync(id);
            if (surveyForms == null)
            {
                return HttpNotFound();
            }
            return View(surveyForms);
        }

        // GET: SurveyForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,FirstName,LastName,DateofCreation,DateofModification,IPAddress,ProjectName,MinistryName,SurveyTitle,SurveyDescription,MainResearchArea,ResearchArea,Male_gender,Female_gender,Non_binary_gender,Age_group_A,Age_group_B,Age_group_C,Age_group_D,Age_group_E,Target_PWDs,Status_Single,Status_Married,Academic_Level_Primary,Academic_Level_Secondary,Academic_Level_Diploma,Academic_Level_Degree,Academic_Level_Masters,Academic_Level_PhD")] SurveyForms surveyForms)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var researcharea = surveyForms.ResearchArea;
                var mainresearcharea = db.ResearchArea_Dbset.Where(x => x.Actual_ResearchArea.Equals(researcharea)).SingleOrDefault();

                surveyForms.UserName = user.UserName;
                surveyForms.FirstName = user.FirstName;
                surveyForms.LastName = user.LastName;
                surveyForms.DateofCreation = DateTime.Now.ToUniversalTime();
                surveyForms.IPAddress = Request.UserHostAddress;
                surveyForms.MainResearchArea = mainresearcharea.MainArea;

                db.SurveyForms_Dbset.Add(surveyForms);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(surveyForms);
        }

        // GET: SurveyForms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            SurveyForms surveyForms = await db.SurveyForms_Dbset.FindAsync(id);
            if (surveyForms == null)
            {
                return HttpNotFound();
            }
            return View(surveyForms);
        }

        // POST: SurveyForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,FirstName,LastName,DateofCreation,DateofModification,IPAddress,ProjectName,MinistryName,SurveyTitle,SurveyDescription,MainResearchArea,ResearchArea,Male_gender,Female_gender,Non_binary_gender,Age_group_A,Age_group_B,Age_group_C,Age_group_D,Age_group_E,Target_PWDs,Status_Single,Status_Married,Academic_Level_Primary,Academic_Level_Secondary,Academic_Level_Diploma,Academic_Level_Degree,Academic_Level_Masters,Academic_Level_PhD")] SurveyForms surveyForms)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.SurveyForms_Dbset.AsNoTracking().Where(x => x.Id == surveyForms.Id).FirstOrDefault();

                var researcharea = surveyForms.ResearchArea;
                var mainresearcharea = db.ResearchArea_Dbset.Where(x => x.Actual_ResearchArea.Equals(researcharea)).SingleOrDefault();

                surveyForms.UserName = original_data.UserName;
                surveyForms.FirstName = original_data.FirstName;
                surveyForms.LastName = original_data.LastName;
                surveyForms.DateofCreation = original_data.DateofCreation;

                surveyForms.DateofModification = DateTime.Now.ToUniversalTime();
                surveyForms.Editor = user.UserName;
                surveyForms.IPAddress = Request.UserHostAddress;
                surveyForms.MainResearchArea = mainresearcharea.MainArea;

                db.Entry(surveyForms).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(surveyForms);
        }

        // GET: SurveyForms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyForms surveyForms = await db.SurveyForms_Dbset.FindAsync(id);
            if (surveyForms == null)
            {
                return HttpNotFound();
            }
            return View(surveyForms);
        }

        // POST: SurveyForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SurveyForms surveyForms = await db.SurveyForms_Dbset.FindAsync(id);
            db.SurveyForms_Dbset.Remove(surveyForms);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public List<Professions> GetProfessionsList()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Professions> professionsList = db.Professions_Dbset.ToList();
            return professionsList;
        }

        [HttpPost]
        public JsonResult GetSurveyCount()
        {
            var livesurveys = db.SurveyForms_Dbset;

            SurveyFormsCountViewModel livesurveycount = new SurveyFormsCountViewModel
            {
                RecordsCount = livesurveys.Count()
            };

            return Json(livesurveycount);
        }

        [HttpPost]
        public JsonResult GetMySurveyCount()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentusername = User.Identity.GetUserName();
            var user = db.Users.SingleOrDefault(u => u.UserName == currentusername);
            var capusername = user.UserName;

            var mylivesurveys = db.SurveyForms_Dbset.Where(s => s.UserName == capusername);

            SurveyFormsCountViewModel mylivesurveycount = new SurveyFormsCountViewModel
            {
                RecordsCount = mylivesurveys.Count()
            };

            return Json(mylivesurveycount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
