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

namespace SurveyME.Controllers
{
    public class SurveyQuestionTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SurveyQuestionTypes
        public ActionResult Index(int? page)
        {
            return View(db.SurveyQuestionTypes_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: SurveyQuestionTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionType surveyQuestionType = await db.SurveyQuestionTypes_Dbset.FindAsync(id);
            if (surveyQuestionType == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionType);
        }

        // GET: SurveyQuestionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyQuestionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,QuestionType_Name")] SurveyQuestionType surveyQuestionType)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                surveyQuestionType.UserName = user.UserName;
                surveyQuestionType.DateofCreation = DateTime.Now.ToUniversalTime();
                surveyQuestionType.IPAddress = Request.UserHostAddress;

                db.SurveyQuestionTypes_Dbset.Add(surveyQuestionType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(surveyQuestionType);
        }

        // GET: SurveyQuestionTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionType surveyQuestionType = await db.SurveyQuestionTypes_Dbset.FindAsync(id);
            if (surveyQuestionType == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionType);
        }

        // POST: SurveyQuestionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,QuestionType_Name")] SurveyQuestionType surveyQuestionType)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.SurveyQuestionTypes_Dbset.AsNoTracking().Where(x => x.Id == surveyQuestionType.Id).FirstOrDefault();

                surveyQuestionType.UserName = original_data.UserName;
                surveyQuestionType.DateofCreation = original_data.DateofCreation;

                surveyQuestionType.Editor = user.UserName;
                surveyQuestionType.DateofModification = DateTime.Now.ToUniversalTime();
                surveyQuestionType.IPAddress = Request.UserHostAddress;

                db.Entry(surveyQuestionType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(surveyQuestionType);
        }

        // GET: SurveyQuestionTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestionType surveyQuestionType = await db.SurveyQuestionTypes_Dbset.FindAsync(id);
            if (surveyQuestionType == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestionType);
        }

        // POST: SurveyQuestionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SurveyQuestionType surveyQuestionType = await db.SurveyQuestionTypes_Dbset.FindAsync(id);
            db.SurveyQuestionTypes_Dbset.Remove(surveyQuestionType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
