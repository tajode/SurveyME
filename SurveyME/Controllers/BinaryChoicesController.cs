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
    public class BinaryChoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BinaryChoices
        public ActionResult Index(int? page)
        {
            return View(db.BinaryChoices_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: BinaryChoices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinaryChoice binaryChoice = await db.BinaryChoices_Dbset.FindAsync(id);
            if (binaryChoice == null)
            {
                return HttpNotFound();
            }
            return View(binaryChoice);
        }

        // GET: BinaryChoices/Create
        public ActionResult Create(int surveyform_id, int section_id)
        {
            int cap_surveyformid = surveyform_id;
            TempData["temp_surveyformid"] = cap_surveyformid;

            int cap_sectionid = section_id;
            TempData["temp_sectionid"] = cap_sectionid;

            return View();
        }

        // POST: BinaryChoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SurveyForm_Id,Section_Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,Question,FirstOption,SecondOption")] BinaryChoice binaryChoice)
        {
            if (ModelState.IsValid)
            {
                int passed_surveyformid = Convert.ToInt32(TempData["temp_surveyformid"]);
                int passed_sectionid = Convert.ToInt32(TempData["temp_sectionid"]);

                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                binaryChoice.UserName = user.UserName;
                binaryChoice.SurveyForm_Id = passed_surveyformid;
                binaryChoice.Section_Id = passed_sectionid;
                binaryChoice.DateofCreation = DateTime.Now.ToUniversalTime();
                binaryChoice.IPAddress = Request.UserHostAddress;

                db.BinaryChoices_Dbset.Add(binaryChoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(binaryChoice);
        }

        // GET: BinaryChoices/Edit/5
        public async Task<ActionResult> Edit(int? id, int? surveyform_Id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinaryChoice binaryChoice = await db.BinaryChoices_Dbset.FindAsync(id);
            if (binaryChoice == null)
            {
                return HttpNotFound();
            }

            TempData["temp_surveyformid"] = surveyform_Id;
            return View(binaryChoice);
        }

        // POST: BinaryChoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SurveyForm_Id,Section_Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,Question,FirstOption,SecondOption")] BinaryChoice binaryChoice)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();

                int passed_surveyformid = Convert.ToInt32(TempData["temp_surveyformid"]);

                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);
                var original_data = db.BinaryChoices_Dbset.AsNoTracking().Where(x => x.Id == binaryChoice.Id).FirstOrDefault();

                binaryChoice.Editor = user.UserName;
                binaryChoice.DateofCreation = DateTime.Now.ToUniversalTime();
                binaryChoice.IPAddress = Request.UserHostAddress;

                binaryChoice.SurveyForm_Id = original_data.SurveyForm_Id;
                binaryChoice.Section_Id = original_data.Section_Id;
                binaryChoice.UserName = original_data.UserName;
                binaryChoice.DateofCreation = original_data.DateofCreation;

                db.Entry(binaryChoice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Sections", new { surveyform_id = passed_surveyformid });
            }
            return View(binaryChoice);
        }

        // GET: BinaryChoices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinaryChoice binaryChoice = await db.BinaryChoices_Dbset.FindAsync(id);
            if (binaryChoice == null)
            {
                return HttpNotFound();
            }
            return View(binaryChoice);
        }

        // POST: BinaryChoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BinaryChoice binaryChoice = await db.BinaryChoices_Dbset.FindAsync(id);
            db.BinaryChoices_Dbset.Remove(binaryChoice);
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
