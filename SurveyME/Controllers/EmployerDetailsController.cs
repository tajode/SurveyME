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
    public class EmployerDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployerDetails
        public ActionResult Index(int? page)
        {
            return View(db.EmployerDetails_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: EmployerDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerDetails employerDetails = await db.EmployerDetails_Dbset.FindAsync(id);
            if (employerDetails == null)
            {
                return HttpNotFound();
            }
            return View(employerDetails);
        }

        // GET: EmployerDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,NameofEmployer")] EmployerDetails employerDetails)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.EmployerDetails_Dbset.AsNoTracking().Where(x => x.Id == employerDetails.Id).FirstOrDefault();

                employerDetails.UserName = original_data.UserName;
                employerDetails.DateofCreation = original_data.DateofCreation;

                employerDetails.Editor = user.UserName;
                employerDetails.DateofModification = DateTime.Now.ToUniversalTime();
                employerDetails.IPAddress = Request.UserHostAddress;

                db.EmployerDetails_Dbset.Add(employerDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employerDetails);
        }

        // GET: EmployerDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerDetails employerDetails = await db.EmployerDetails_Dbset.FindAsync(id);
            if (employerDetails == null)
            {
                return HttpNotFound();
            }
            return View(employerDetails);
        }

        // POST: EmployerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,NameofEmployer")] EmployerDetails employerDetails)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                employerDetails.UserName = user.UserName;
                employerDetails.DateofCreation = DateTime.Now.ToUniversalTime();
                employerDetails.IPAddress = Request.UserHostAddress;

                db.Entry(employerDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employerDetails);
        }

        // GET: EmployerDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployerDetails employerDetails = await db.EmployerDetails_Dbset.FindAsync(id);
            if (employerDetails == null)
            {
                return HttpNotFound();
            }
            return View(employerDetails);
        }

        // POST: EmployerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployerDetails employerDetails = await db.EmployerDetails_Dbset.FindAsync(id);
            db.EmployerDetails_Dbset.Remove(employerDetails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetEmployers(string term)
        {
            var employers = db.EmployerDetails_Dbset.Select(q => new
            {
                Id = q.Id,
                employer = q.NameofEmployer
            }).Where(q => q.employer.Contains(term));

            return Json(employers, JsonRequestBehavior.AllowGet);
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
