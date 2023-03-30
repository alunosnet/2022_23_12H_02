using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoM17E.Data;
using ProjetoM17E.Models;

namespace ProjetoM17E.Controllers
{
    public class EntregasController : Controller
    {
        private ProjetoM17EContext db = new ProjetoM17EContext();

        // GET: Entregas
        public ActionResult Index()
        {
            var entregas = db.Entregas.Include(e => e.produto).Include(e => e.utilizador);
            return View(entregas.ToList());
        }

        // GET: Entregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }

            var produto = db.Produtoes.Find(entrega.ProdutoId);
            entrega.produto=produto;
            var utilizador = db.Utilizadors.Find(entrega.utilizadorid);
            entrega.utilizador=utilizador;
            return View(entrega);
        }

        // GET: Entregas/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtoes.Where(q => q.Estado==true), "ProdutoId", "ProdutoId");
            ViewBag.utilizadorid = new SelectList(db.Utilizadors, "UtilizadorId", "Nome");
            return View();
        }

        // POST: Entregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntregaId,utilizadorid,ProdutoId,data_entrega")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                var prod = db.Produtoes.Find(entrega.ProdutoId);
                prod.Estado = false;
                db.Entregas.Add(entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "ProdutoId", entrega.ProdutoId);
            ViewBag.utilizadorid = new SelectList(db.Utilizadors, "UtilizadorId", "Nome", entrega.utilizadorid);
            return View(entrega);
        }

        // GET: Entregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "ProdutoId", entrega.ProdutoId);
            ViewBag.utilizadorid = new SelectList(db.Utilizadors, "UtilizadorId", "Nome", entrega.utilizadorid);
            return View(entrega);
        }

        // POST: Entregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntregaId,utilizadorid,ProdutoId,data_entrega")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "ProdutoId", entrega.ProdutoId);
            ViewBag.utilizadorid = new SelectList(db.Utilizadors, "UtilizadorId", "Nome", entrega.utilizadorid);
            return View(entrega);
        }

        // GET: Entregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "ProdutoId", entrega.ProdutoId);
            ViewBag.utilizadorid = new SelectList(db.Utilizadors, "UtilizadorId", "Nome", entrega.utilizadorid);
            return View(entrega);
        }

        // POST: Entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entregas.Find(id);
            var prod = db.Produtoes.Find(entrega.ProdutoId);
            prod.Estado = true;
            db.Entregas.Remove(entrega);
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
