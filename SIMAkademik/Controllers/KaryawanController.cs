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
    public class KaryawanController : Controller
    {
        private AKADEMIKEntities db = new AKADEMIKEntities();

        // GET: Karyawan
        public ActionResult Index()
        {
            var tBLM_KARYAWAN = db.TBLM_KARYAWAN.Include(t => t.TBLM_AGAMA).Include(t => t.TBLM_SEX);
            return View(tBLM_KARYAWAN.ToList());
        }

        // GET: Karyawan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_KARYAWAN tBLM_KARYAWAN = db.TBLM_KARYAWAN.Find(id);
            if (tBLM_KARYAWAN == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_KARYAWAN);
        }

        // GET: Karyawan/Create
        public ActionResult Create()
        {
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA");
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA");
            return View();
        }

        // POST: Karyawan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIK,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,ALAMAT,EMAIL,HP,TELEPON,IDAGAMA,IDSEX,FILENAME,CONTENTTYPE,DATA")] TBLM_KARYAWAN tBLM_KARYAWAN)
        {
            if (ModelState.IsValid)
            {
                db.TBLM_KARYAWAN.Add(tBLM_KARYAWAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_KARYAWAN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_KARYAWAN.IDSEX);
            return View(tBLM_KARYAWAN);
        }

        // GET: Karyawan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_KARYAWAN tBLM_KARYAWAN = db.TBLM_KARYAWAN.Find(id);
            if (tBLM_KARYAWAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_KARYAWAN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_KARYAWAN.IDSEX);
            return View(tBLM_KARYAWAN);
        }

        // POST: Karyawan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIK,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,ALAMAT,EMAIL,HP,TELEPON,IDAGAMA,IDSEX,FILENAME,CONTENTTYPE,DATA")] TBLM_KARYAWAN tBLM_KARYAWAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLM_KARYAWAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_KARYAWAN.IDAGAMA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_KARYAWAN.IDSEX);
            return View(tBLM_KARYAWAN);
        }

        // GET: Karyawan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_KARYAWAN tBLM_KARYAWAN = db.TBLM_KARYAWAN.Find(id);
            if (tBLM_KARYAWAN == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_KARYAWAN);
        }

        // POST: Karyawan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TBLM_KARYAWAN tBLM_KARYAWAN = db.TBLM_KARYAWAN.Find(id);
            db.TBLM_KARYAWAN.Remove(tBLM_KARYAWAN);
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
