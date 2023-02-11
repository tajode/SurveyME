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
    public class SectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sections
        public ActionResult Index(int? page, string surveyform_id)
        {
            int passed_surveyformid = Convert.ToInt32(surveyform_id);
            var filteredsectionslist = db.Sections_Dbset.Where(x => x.SurveyForm_Id.Equals(passed_surveyformid)).ToList().ToPagedList(page ?? 1, 1);
            var filteredbinarylist = db.BinaryChoices_Dbset.Where(x => x.SurveyForm_Id.Equals(passed_surveyformid)).ToList();

            CompleteSectionViewModel groupmodel = new CompleteSectionViewModel();
            groupmodel.sectionslist = filteredsectionslist;
            groupmodel.binarychoicelist = filteredbinarylist;
            return View(groupmodel);
        }

        // GET: Sections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = await db.Sections_Dbset.FindAsync(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // GET: Sections/Create
        public ActionResult Create(string surveyform_id)
        {
            TempData["temp_surveyformid"] = surveyform_id;
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SurveyForm_Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,SectionTitle,SectionDescription")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                int passed_surveyformid = Convert.ToInt32(TempData["temp_surveyformid"]);

                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                sections.UserName = user.UserName;
                sections.DateofCreation = DateTime.Now.ToUniversalTime();
                sections.IPAddress = Request.UserHostAddress;
                sections.SurveyForm_Id = passed_surveyformid;

                db.Sections_Dbset.Add(sections);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { surveyform_id = passed_surveyformid });
            }

            return View(sections);
        }

        // GET: Sections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = await db.Sections_Dbset.FindAsync(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SurveyForm_Id,UserName,DateofCreation,IPAddress,SectionTitle,SectionDescription")] Sections sections)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.Sections_Dbset.AsNoTracking().Where(x => x.Id == sections.Id).FirstOrDefault();

                sections.SurveyForm_Id = original_data.SurveyForm_Id;
                sections.UserName = original_data.UserName;
                sections.DateofCreation = original_data.DateofCreation;
                
                sections.Editor = user.UserName;
                sections.DateofModification = DateTime.Now.ToUniversalTime();
                sections.IPAddress = Request.UserHostAddress;

                db.Entry(sections).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sections);
        }

        // GET: Sections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sections sections = await db.Sections_Dbset.FindAsync(id);
            if (sections == null)
            {
                return HttpNotFound();
            }
            return View(sections);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sections sections = await db.Sections_Dbset.FindAsync(id);
            db.Sections_Dbset.Remove(sections);
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
