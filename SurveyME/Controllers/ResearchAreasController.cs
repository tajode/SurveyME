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
    public class ResearchAreasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResearchAreas
        public ActionResult Index(int? page)
        {
            return View(db.ResearchArea_Dbset.ToList().ToPagedList(page ?? 1, 12));
        }

        // GET: ResearchAreas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAreas researchAreas = await db.ResearchArea_Dbset.FindAsync(id);
            if (researchAreas == null)
            {
                return HttpNotFound();
            }
            return View(researchAreas);
        }

        // GET: ResearchAreas/Create
        public ActionResult Create()
        {
            ViewBag.mainareasList = new SelectList(GetMainAreasList(), "MainArea", "MainArea");

            return View();
        }

        // POST: ResearchAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,MainArea,SubArea,Actual_ResearchArea")] ResearchAreas researchAreas)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                researchAreas.UserName = user.UserName;
                researchAreas.DateofCreation = DateTime.Now.ToUniversalTime();
                researchAreas.IPAddress = Request.UserHostAddress;

                db.ResearchArea_Dbset.Add(researchAreas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(researchAreas);
        }

        // GET: ResearchAreas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAreas researchAreas = await db.ResearchArea_Dbset.FindAsync(id);
            if (researchAreas == null)
            {
                return HttpNotFound();
            }
            return View(researchAreas);
        }

        // POST: ResearchAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Editor,DateofCreation,DateofModification,IPAddress,MainArea,SubArea,Actual_ResearchArea")] ResearchAreas researchAreas)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string currentUserName = User.Identity.GetUserName();
                var user = db.Users.SingleOrDefault(u => u.UserName == currentUserName);

                var original_data = db.ResearchArea_Dbset.AsNoTracking().Where(x => x.Id == researchAreas.Id).FirstOrDefault();

                researchAreas.UserName = original_data.UserName;
                researchAreas.DateofCreation = original_data.DateofCreation;

                researchAreas.Editor = user.UserName;
                researchAreas.DateofModification = DateTime.Now.ToUniversalTime();
                researchAreas.IPAddress = Request.UserHostAddress;

                db.Entry(researchAreas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(researchAreas);
        }

        // GET: ResearchAreas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchAreas researchAreas = await db.ResearchArea_Dbset.FindAsync(id);
            if (researchAreas == null)
            {
                return HttpNotFound();
            }
            return View(researchAreas);
        }

        // POST: ResearchAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ResearchAreas researchAreas = await db.ResearchArea_Dbset.FindAsync(id);
            db.ResearchArea_Dbset.Remove(researchAreas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public List<ResearchAreas> GetMainAreasList()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ResearchAreas> mainareasList = db.ResearchArea_Dbset.ToList();
            var groupedmainareas = mainareasList.GroupBy(item => item.MainArea);
            var uniquemainareaslist = groupedmainareas.Select(grp => grp.OrderBy(item => item.MainArea).First()).ToList();
            return uniquemainareaslist;
        }

        public ActionResult GetSubAreasList(string mainareaName)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ResearchAreas> subareasList = db.ResearchArea_Dbset.Where(x => x.MainArea == mainareaName).ToList();
            var groupedsubareas = subareasList.GroupBy(item => item.SubArea);
            var uniquesubareaslist = groupedsubareas.Select(grp => grp.OrderBy(item => item.SubArea).First());
            ViewBag.SubAreaOptions = new SelectList(uniquesubareaslist, "SubArea", "SubArea");
            return PartialView("SubAreaOptionPartial");
        }

        public ActionResult GetActualAreaList(string subareaName)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ResearchAreas> actualareasList = db.ResearchArea_Dbset.Where(x => x.SubArea.Equals(subareaName)).ToList();
            var groupedsubareas = actualareasList.GroupBy(item => item.Actual_ResearchArea);
            var uniquesubareaslist = groupedsubareas.Select(grp => grp.OrderBy(item => item.Actual_ResearchArea).First());
            ViewBag.ActualAreaOptions = new SelectList(uniquesubareaslist, "Actual_ResearchArea", "Actual_ResearchArea");
            return PartialView("ActualAreaOptionPartial");
        }

        public JsonResult GetResearchAreas(string term)
        {
            var researchareas = db.ResearchArea_Dbset.Select(q => new
            {
                Id = q.Id,
                researcharea = q.Actual_ResearchArea
            }).Where(q => q.researcharea.Contains(term));

            return Json(researchareas, JsonRequestBehavior.AllowGet);
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
