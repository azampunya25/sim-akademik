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
    public class MahasiswaController : Controller
    {
        private AKADEMIKEntities db = new AKADEMIKEntities();

        // GET: Mahasiswa
        public ActionResult Index()
        {
            var tBLM_MAHASISWA = db.TBLM_MAHASISWA.Include(t => t.TBLM_AGAMA).Include(t => t.TBLM_DESA).Include(t => t.TBLM_NEGARA).Include(t => t.TBLM_PROGRAM).Include(t => t.TBLM_SATUSMAHASISWA).Include(t => t.TBLM_SEX).Include(t => t.TBLM_STATUSSIPIL).Include(t => t.TBLM_WARGANEGARA);
            return View(tBLM_MAHASISWA.ToList());
        }

        // GET: Mahasiswa/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_MAHASISWA tBLM_MAHASISWA = db.TBLM_MAHASISWA.Find(id);
            if (tBLM_MAHASISWA == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_MAHASISWA);
        }

        // GET: Mahasiswa/Create
        public ActionResult Create()
        {
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA");
            ViewBag.IDDESA = new SelectList(db.TBLM_DESA, "IDDESA", "NAMA");
            ViewBag.IDNEGARA = new SelectList(db.TBLM_NEGARA, "IDNEGARA", "NAMA");
            ViewBag.IDPROGRAM = new SelectList(db.TBLM_PROGRAM, "IDPROGRAM", "NAMA");
            ViewBag.IDSTATUSMAHASISWA = new SelectList(db.TBLM_SATUSMAHASISWA, "IDSTATUSMAHASISWA", "NAMA");
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA");
            ViewBag.IDSTATUSSIPIL = new SelectList(db.TBLM_STATUSSIPIL, "IDSTATUSSIPIL", "NAMA");
            ViewBag.IDWARGANEGARA = new SelectList(db.TBLM_WARGANEGARA, "IDWARGANEGARA", "NAMA");
            return View();
        }

        // POST: Mahasiswa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIM,NIK,NOPENDAFTARAN,IDSTATUSMAHASISWA,IDPROGRAM,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,IDAGAMA,IDSEX,IDSTATUSSIPIL,IDWARGANEGARA,HP,EMAIL,TELEPON,ALAMAT,RT,RW,IDDESA,IDNEGARA,SD,TGLSSTBSD,THNMASUKSD,THNKELUARSD,SMP,TLGSSTBSMP,THNMASUKSMP,THNKELUARSMP,SMA,TGLSSTBSMA,THNMASUKSMA,THNKELUARSMA,JURUSANSMA,NAMAYAH,TEMPATLAHIRAYAH,TANGGALLAHIRAYAH,ALAMATAYAH,PEKERJAANAYAH,NAMAIBU,TEMPATLAHIRIBU,TANGGALLAHIRIBU,ALAMATIBU,FILENAME,CONTENTTYPE,DATA,CREATEDDATE,CREATEDBY,UPDATEDDATE,UPDATEDBY")] TBLM_MAHASISWA tBLM_MAHASISWA)
        {
            if (ModelState.IsValid)
            {
                db.TBLM_MAHASISWA.Add(tBLM_MAHASISWA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_MAHASISWA.IDAGAMA);
            ViewBag.IDDESA = new SelectList(db.TBLM_DESA, "IDDESA", "NAMA", tBLM_MAHASISWA.IDDESA);
            ViewBag.IDNEGARA = new SelectList(db.TBLM_NEGARA, "IDNEGARA", "NAMA", tBLM_MAHASISWA.IDNEGARA);
            ViewBag.IDPROGRAM = new SelectList(db.TBLM_PROGRAM, "IDPROGRAM", "NAMA", tBLM_MAHASISWA.IDPROGRAM);
            ViewBag.IDSTATUSMAHASISWA = new SelectList(db.TBLM_SATUSMAHASISWA, "IDSTATUSMAHASISWA", "NAMA", tBLM_MAHASISWA.IDSTATUSMAHASISWA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_MAHASISWA.IDSEX);
            ViewBag.IDSTATUSSIPIL = new SelectList(db.TBLM_STATUSSIPIL, "IDSTATUSSIPIL", "NAMA", tBLM_MAHASISWA.IDSTATUSSIPIL);
            ViewBag.IDWARGANEGARA = new SelectList(db.TBLM_WARGANEGARA, "IDWARGANEGARA", "NAMA", tBLM_MAHASISWA.IDWARGANEGARA);
            return View(tBLM_MAHASISWA);
        }

        // GET: Mahasiswa/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_MAHASISWA tBLM_MAHASISWA = db.TBLM_MAHASISWA.Find(id);
            if (tBLM_MAHASISWA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_MAHASISWA.IDAGAMA);
            ViewBag.IDDESA = new SelectList(db.TBLM_DESA, "IDDESA", "NAMA", tBLM_MAHASISWA.IDDESA);
            ViewBag.IDNEGARA = new SelectList(db.TBLM_NEGARA, "IDNEGARA", "NAMA", tBLM_MAHASISWA.IDNEGARA);
            ViewBag.IDPROGRAM = new SelectList(db.TBLM_PROGRAM, "IDPROGRAM", "NAMA", tBLM_MAHASISWA.IDPROGRAM);
            ViewBag.IDSTATUSMAHASISWA = new SelectList(db.TBLM_SATUSMAHASISWA, "IDSTATUSMAHASISWA", "NAMA", tBLM_MAHASISWA.IDSTATUSMAHASISWA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_MAHASISWA.IDSEX);
            ViewBag.IDSTATUSSIPIL = new SelectList(db.TBLM_STATUSSIPIL, "IDSTATUSSIPIL", "NAMA", tBLM_MAHASISWA.IDSTATUSSIPIL);
            ViewBag.IDWARGANEGARA = new SelectList(db.TBLM_WARGANEGARA, "IDWARGANEGARA", "NAMA", tBLM_MAHASISWA.IDWARGANEGARA);
            return View(tBLM_MAHASISWA);
        }

        // POST: Mahasiswa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIM,NIK,NOPENDAFTARAN,IDSTATUSMAHASISWA,IDPROGRAM,NAMALENGKAP,NAMAPANGGILAN,TEMPATLAHIR,TANGGALLAHIR,IDAGAMA,IDSEX,IDSTATUSSIPIL,IDWARGANEGARA,HP,EMAIL,TELEPON,ALAMAT,RT,RW,IDDESA,IDNEGARA,SD,TGLSSTBSD,THNMASUKSD,THNKELUARSD,SMP,TLGSSTBSMP,THNMASUKSMP,THNKELUARSMP,SMA,TGLSSTBSMA,THNMASUKSMA,THNKELUARSMA,JURUSANSMA,NAMAYAH,TEMPATLAHIRAYAH,TANGGALLAHIRAYAH,ALAMATAYAH,PEKERJAANAYAH,NAMAIBU,TEMPATLAHIRIBU,TANGGALLAHIRIBU,ALAMATIBU,FILENAME,CONTENTTYPE,DATA,CREATEDDATE,CREATEDBY,UPDATEDDATE,UPDATEDBY")] TBLM_MAHASISWA tBLM_MAHASISWA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLM_MAHASISWA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAGAMA = new SelectList(db.TBLM_AGAMA, "IDAGAMA", "NAMA", tBLM_MAHASISWA.IDAGAMA);
            ViewBag.IDDESA = new SelectList(db.TBLM_DESA, "IDDESA", "NAMA", tBLM_MAHASISWA.IDDESA);
            ViewBag.IDNEGARA = new SelectList(db.TBLM_NEGARA, "IDNEGARA", "NAMA", tBLM_MAHASISWA.IDNEGARA);
            ViewBag.IDPROGRAM = new SelectList(db.TBLM_PROGRAM, "IDPROGRAM", "NAMA", tBLM_MAHASISWA.IDPROGRAM);
            ViewBag.IDSTATUSMAHASISWA = new SelectList(db.TBLM_SATUSMAHASISWA, "IDSTATUSMAHASISWA", "NAMA", tBLM_MAHASISWA.IDSTATUSMAHASISWA);
            ViewBag.IDSEX = new SelectList(db.TBLM_SEX, "IDSEX", "NAMA", tBLM_MAHASISWA.IDSEX);
            ViewBag.IDSTATUSSIPIL = new SelectList(db.TBLM_STATUSSIPIL, "IDSTATUSSIPIL", "NAMA", tBLM_MAHASISWA.IDSTATUSSIPIL);
            ViewBag.IDWARGANEGARA = new SelectList(db.TBLM_WARGANEGARA, "IDWARGANEGARA", "NAMA", tBLM_MAHASISWA.IDWARGANEGARA);
            return View(tBLM_MAHASISWA);
        }

        // GET: Mahasiswa/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLM_MAHASISWA tBLM_MAHASISWA = db.TBLM_MAHASISWA.Find(id);
            if (tBLM_MAHASISWA == null)
            {
                return HttpNotFound();
            }
            return View(tBLM_MAHASISWA);
        }

        // POST: Mahasiswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TBLM_MAHASISWA tBLM_MAHASISWA = db.TBLM_MAHASISWA.Find(id);
            db.TBLM_MAHASISWA.Remove(tBLM_MAHASISWA);
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
