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
    public class ProfessionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Professions
        public ActionResult Index(int? page)
        {
            return View(db.Professions_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: Professions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professions professions = await db.Professions_Dbset.FindAsync(id);
            if (professions == null)
            {
                return HttpNotFound();
            }
            return View(professions);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,ProfessionName")] Professions professions)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                professions.UserName = user.UserName;
                professions.DateofCreation = DateTime.Now.ToUniversalTime();
                professions.IPAddress = Request.UserHostAddress;

                db.Professions_Dbset.Add(professions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professions);
        }

        // GET: Professions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professions professions = await db.Professions_Dbset.FindAsync(id);
            if (professions == null)
            {
                return HttpNotFound();
            }
            return View(professions);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,ProfessionName")] Professions professions)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.Professions_Dbset.AsNoTracking().Where(x => x.Id == professions.Id).FirstOrDefault();

                professions.UserName = original_data.UserName;
                professions.DateofCreation = original_data.DateofCreation;

                professions.Editor = user.UserName;
                professions.DateofModification = DateTime.Now.ToUniversalTime();
                professions.IPAddress = Request.UserHostAddress;

                db.Entry(professions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professions);
        }

        // GET: Professions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professions professions = await db.Professions_Dbset.FindAsync(id);
            if (professions == null)
            {
                return HttpNotFound();
            }
            return View(professions);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Professions professions = await db.Professions_Dbset.FindAsync(id);
            db.Professions_Dbset.Remove(professions);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetProfessions(string term)
        {
            var professions = db.Professions_Dbset.Select(q => new
            {
                Id = q.Id,
                profession = q.ProfessionName
            }).Where(q => q.profession.Contains(term));

            return Json(professions, JsonRequestBehavior.AllowGet);
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
