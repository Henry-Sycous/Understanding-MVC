using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using First_Application.Models;

namespace First_Application.Controllers
{
    public class PersonInfoController : Controller
    {
        private PersonDBContext db = new PersonDBContext();

        // GET: PersonInfo
        public ActionResult Index()
        {
           return View(db.PersonInfo.ToList());
        }

        // GET: PersonInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return HttpNotFound();
            }
            return View(personInfo);
        }

        // GET: PersonInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,surname,DOB")] PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                db.PersonInfo.Add(personInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInfo);
        }

        // GET: PersonInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return HttpNotFound();
            }
            return View(personInfo);
        }

        // POST: PersonInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,surname,DOB")] PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInfo);
        }

        // GET: PersonInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return HttpNotFound();
            }
            return View(personInfo);
        }

        // POST: PersonInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInfo personInfo = db.PersonInfo.Find(id);
            db.PersonInfo.Remove(personInfo);
            db.SaveChanges();
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
