using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIMAkademik.Models;

namespace SIMAkademik.Controllers
{
    public class DosenController : Controller
    {
        private AKADEMIKEntities db = new AKADEMIKEntities();

        // GET: Dosen
        public ActionResult Index()
        {
            var tBLM_DOSEN = db.TBLM_DOSEN.Include(t => t.TBLM_AGAMA).Include(t => t.TBLM_SEX);
            return View(tBLM_DOSEN.ToList());
        }

        // GET: Dosen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_DOSEN tBLM_DOSEN = db.TBLM_DOSEN.Find(id);
            if (tBLM_DOSEN == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_DOSEN);
        }

        // GET: Dosen/Create
        public ActionResult Create()
        {
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA");
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA");
            return View();
        }

        // POST: Dosen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDOSEN,NIP,NUPTK,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,ALAMAT,EMAIL,HP,TELEPON,IDAGAMA,IDSEX,FILENAME,CONTENTTYPE,DATA")] TBLM_DOSEN tBLM_DOSEN)
        {
            if (ModelState.IsValid)
            {
                db.TBLM_DOSEN.Add(tBLM_DOSEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_DOSEN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_DOSEN.IDSEX);
            return View(tBLM_DOSEN);
        }

        // GET: Dosen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_DOSEN tBLM_DOSEN = db.TBLM_DOSEN.Find(id);
            if (tBLM_DOSEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_DOSEN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_DOSEN.IDSEX);
            return View(tBLM_DOSEN);
        }

        // POST: Dosen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDOSEN,NIP,NUPTK,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,ALAMAT,EMAIL,HP,TELEPON,IDAGAMA,IDSEX,FILENAME,CONTENTTYPE,DATA")] TBLM_DOSEN tBLM_DOSEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLM_DOSEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_DOSEN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_DOSEN.IDSEX);
            return View(tBLM_DOSEN);
        }

        // GET: Dosen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_DOSEN tBLM_DOSEN = db.TBLM_DOSEN.Find(id);
            if (tBLM_DOSEN == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_DOSEN);
        }

        // POST: Dosen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLM_DOSEN tBLM_DOSEN = db.TBLM_DOSEN.Find(id);
            db.TBLM_DOSEN.Remove(tBLM_DOSEN);
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
