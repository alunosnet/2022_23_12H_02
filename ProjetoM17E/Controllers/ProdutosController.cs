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
    public class ProdutosController : Controller
    {
        private ProjetoM17EContext db = new ProjetoM17EContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtoes.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            var produto = new Produto();
            produto.Tipos = new[]
            {
                new SelectListItem{Value="1", Text="Caixa"},
                new SelectListItem{Value="0", Text="Saco"}
            };
            produto.Fragils = new[]
            {
                new SelectListItem{Value="1", Text="Sim"},
                new SelectListItem{Value="0", Text="Não"}
            };
            return View(produto);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Peso,Preco,Tipo,Fragil")] Produto produto)
        {
            produto.Tipos = new[]
            {
                new SelectListItem{Value="1", Text="Caixa"},
                new SelectListItem{Value="0", Text="Saco"}
            };
            produto.Fragils = new[]
            {
                new SelectListItem{Value="1", Text="Sim"},
                new SelectListItem{Value="0", Text="Não"}
            };
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            produto.Tipos = new[]
            {
                new SelectListItem{Value="1", Text="Caixa"},
                new SelectListItem{Value="0", Text="Saco"}
            };
            produto.Fragils = new[]
            {
                new SelectListItem{Value="1", Text="Sim"},
                new SelectListItem{Value="0", Text="Não"}
            };
            if (produto == null)
            {
                return HttpNotFound();
            }
            

            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Peso,Preco,Tipo,Fragil")] Produto produto)
        {
            produto.Tipos = new[]
            {
                new SelectListItem{Value="1", Text="Caixa"},
                new SelectListItem{Value="0", Text="Saco"}
            };
            produto.Fragils = new[]
            {
                new SelectListItem{Value="1", Text="Sim"},
                new SelectListItem{Value="0", Text="Não"}
            };
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
