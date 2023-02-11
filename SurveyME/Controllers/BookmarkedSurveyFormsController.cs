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
using SurveyME.ModelViews;

namespace SurveyME.Controllers
{
    public class BookmarkedSurveyFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookmarkedSurveyForms
        public async Task<ActionResult> Index()
        {
            return View(await db.BookmarkedSurveyForms_Dbset.ToListAsync());
        }

        // GET: BookmarkedSurveyForms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookmarkedSurveyForms bookmarkedSurveyForms = await db.BookmarkedSurveyForms_Dbset.FindAsync(id);
            if (bookmarkedSurveyForms == null)
            {
                return HttpNotFound();
            }
            return View(bookmarkedSurveyForms);
        }

        // GET: BookmarkedSurveyForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookmarkedSurveyForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SurveyFormID,UserName,BookmarkStatus,DateofCreation,DateofStatusChange")] BookmarkedSurveyForms bookmarkedSurveyForms)
        {
            if (ModelState.IsValid)
            {
                db.BookmarkedSurveyForms_Dbset.Add(bookmarkedSurveyForms);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bookmarkedSurveyForms);
        }

        // GET: BookmarkedSurveyForms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookmarkedSurveyForms bookmarkedSurveyForms = await db.BookmarkedSurveyForms_Dbset.FindAsync(id);
            if (bookmarkedSurveyForms == null)
            {
                return HttpNotFound();
            }
            return View(bookmarkedSurveyForms);
        }

        // POST: BookmarkedSurveyForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SurveyFormID,UserName,BookmarkStatus,DateofCreation,DateofStatusChange")] BookmarkedSurveyForms bookmarkedSurveyForms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookmarkedSurveyForms).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookmarkedSurveyForms);
        }

        // GET: BookmarkedSurveyForms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookmarkedSurveyForms bookmarkedSurveyForms = await db.BookmarkedSurveyForms_Dbset.FindAsync(id);
            if (bookmarkedSurveyForms == null)
            {
                return HttpNotFound();
            }
            return View(bookmarkedSurveyForms);
        }

        // POST: BookmarkedSurveyForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookmarkedSurveyForms bookmarkedSurveyForms = await db.BookmarkedSurveyForms_Dbset.FindAsync(id);
            db.BookmarkedSurveyForms_Dbset.Remove(bookmarkedSurveyForms);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetBookmarks(string formid, BookmarkedSurveyForms bookmarkedSurveyForms)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentusername = User.Identity.GetUserName();
            var user = db.Users.SingleOrDefault(u => u.UserName == currentusername);
            var capusername = user.UserName;
            string bookmark_yes = "Yes";
            string bookmark_no = "No";

            var livebookmarks = db.BookmarkedSurveyForms_Dbset.SingleOrDefault(g => g.UserName == currentusername && g.SurveyFormID == formid);

            if (livebookmarks == null)
            {
                bookmarkedSurveyForms.UserName = capusername;
                bookmarkedSurveyForms.SurveyFormID = formid.ToString();
                bookmarkedSurveyForms.BookmarkStatus = bookmark_yes;
                bookmarkedSurveyForms.DateofCreation = DateTime.Now.ToUniversalTime();
                bookmarkedSurveyForms.IPAddress = Request.UserHostAddress;
                db.BookmarkedSurveyForms_Dbset.Add(bookmarkedSurveyForms);
                db.SaveChanges();
            }
            else
            {
                var cap_bookmarkstatus = livebookmarks.BookmarkStatus;

                if (cap_bookmarkstatus == bookmark_yes)
                {
                    livebookmarks.BookmarkStatus = bookmark_no;
                    livebookmarks.DateofStatusChange = DateTime.Now.ToUniversalTime();
                    livebookmarks.IPAddress = Request.UserHostAddress;
                    db.SaveChanges();
                }
                else if (cap_bookmarkstatus == bookmark_no)
                {
                    livebookmarks.BookmarkStatus = bookmark_yes;
                    livebookmarks.DateofStatusChange = DateTime.Now.ToUniversalTime();
                    livebookmarks.IPAddress = Request.UserHostAddress;
                    db.SaveChanges();
                }
            }

            var updatedbookmarks = db.BookmarkedSurveyForms_Dbset.SingleOrDefault(g => g.UserName == currentusername && g.SurveyFormID == formid);

            BookmarkSurveyFormsViewModel userbookmarks = new BookmarkSurveyFormsViewModel
            {
                Id = updatedbookmarks.Id,
                SurveyFormID = updatedbookmarks.SurveyFormID,
                UserName = updatedbookmarks.UserName,
                BookmarkStatus = updatedbookmarks.BookmarkStatus,
                DateofCreation = updatedbookmarks.DateofCreation,
                DateofStatusChange = updatedbookmarks.DateofStatusChange
            };

            return Json(userbookmarks);
        }

        [HttpPost]
        public JsonResult GetBookmarksCount(string countformid)
        {
            string bookmark_yes = "Yes";
            var livebookmarks = db.BookmarkedSurveyForms_Dbset.Where(g => g.SurveyFormID == countformid && g.BookmarkStatus == bookmark_yes);

            BookmarkSurveyFormsCountViewModel bookmarkscount = new BookmarkSurveyFormsCountViewModel
            {
                BookmarkCount = livebookmarks.Count()
            };

            return Json(bookmarkscount);
        }

        [HttpPost]
        public JsonResult GetBookmarksStatus(string statusformid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentusername = User.Identity.GetUserName();
            var user = db.Users.SingleOrDefault(u => u.UserName == currentusername);
            var capusername = user.UserName;

            var livebookmarkstatus = db.BookmarkedSurveyForms_Dbset.SingleOrDefault(g => g.SurveyFormID == statusformid && g.UserName == capusername);

            BookmarkSurveyFormsStatusViewModel bookmarksstatus = new BookmarkSurveyFormsStatusViewModel
            {
                BookmarkStatus = livebookmarkstatus.BookmarkStatus
            };

            return Json(bookmarksstatus);
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
