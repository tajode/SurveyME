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
    public class MinistryDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MinistryDetails
        public ActionResult Index(int? page)
        {
            return View(db.MinistryDetails_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: MinistryDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryDetails ministryDetails = await db.MinistryDetails_Dbset.FindAsync(id);
            if (ministryDetails == null)
            {
                return HttpNotFound();
            }
            return View(ministryDetails);
        }

        // GET: MinistryDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MinistryDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,NameofMinistry")] MinistryDetails ministryDetails)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                ministryDetails.UserName = user.UserName;
                ministryDetails.DateofCreation = DateTime.Now.ToUniversalTime();
                ministryDetails.IPAddress = Request.UserHostAddress;

                db.MinistryDetails_Dbset.Add(ministryDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ministryDetails);
        }

        // GET: MinistryDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryDetails ministryDetails = await db.MinistryDetails_Dbset.FindAsync(id);
            if (ministryDetails == null)
            {
                return HttpNotFound();
            }
            return View(ministryDetails);
        }

        // POST: MinistryDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,NameofMinistry")] MinistryDetails ministryDetails)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.MinistryDetails_Dbset.AsNoTracking().Where(x => x.Id == ministryDetails.Id).FirstOrDefault();

                ministryDetails.UserName = original_data.UserName;
                ministryDetails.DateofCreation = original_data.DateofCreation;

                ministryDetails.Editor = user.UserName;
                ministryDetails.DateofModification = DateTime.Now.ToUniversalTime();
                ministryDetails.IPAddress = Request.UserHostAddress;

                db.Entry(ministryDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ministryDetails);
        }

        // GET: MinistryDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryDetails ministryDetails = await db.MinistryDetails_Dbset.FindAsync(id);
            if (ministryDetails == null)
            {
                return HttpNotFound();
            }
            return View(ministryDetails);
        }

        // POST: MinistryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MinistryDetails ministryDetails = await db.MinistryDetails_Dbset.FindAsync(id);
            db.MinistryDetails_Dbset.Remove(ministryDetails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetMinistries(string term)
        {
            var ministries = db.MinistryDetails_Dbset.Select(q => new
            {
                Id = q.Id,
                ministry = q.NameofMinistry
            }).Where(q => q.ministry.Contains(term));

            return Json(ministries, JsonRequestBehavior.AllowGet);
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
