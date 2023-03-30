using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProjetoM17E.Data;
using ProjetoM17E.Models;

namespace ProjetoM17E.Controllers
{
    public class UtilizadoresController : Controller
    {
        private ProjetoM17EContext db = new ProjetoM17EContext();

        // GET: Utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizadors.ToList());
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            var utilizador = new Utilizador();
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="1", Text="Administrador"},
                new SelectListItem{Value="0", Text="Cliente"}
            };

            return View(utilizador);
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilizadorId,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="1", Text="Administrador"},
                new SelectListItem{Value="0", Text="Cliente"}
            };
            if (ModelState.IsValid)
            {
                //verificar se o nome do utilizador já existe
                var temp = db.Utilizadors.Where(u => u.Email == utilizador.Email).ToList();
                if (temp != null && temp.Count>0)
                {
                    ModelState.AddModelError("Email", "Ja existe um Utilizador com esse email");
                    return View(utilizador);
                }
                //validar password
                if (utilizador.Password.Trim().Length<5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pelo o menos 5 letras");
                    return View(utilizador);
                }
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Utilizador utilizador = db.Utilizadors.Find(id);
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="1", Text="Administrador"},
                new SelectListItem{Value="0", Text="Cliente"}
            };
            
           
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilizadorId,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="1", Text="Administrador"},
                new SelectListItem{Value="0", Text="Cliente"}
            };
            if (ModelState.IsValid)
            {
                var t = db.Utilizadors.Find(utilizador.UtilizadorId);
                utilizador.Password = t.Password;
                t.Email = utilizador.Email;
                t.Perfil= utilizador.Perfil;
                t.Nome= utilizador.Nome;
                db.Entry(t).CurrentValues.SetValues(t);
                db.SaveChanges();
                if (User.IsInRole("Adminstrador"))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index", "Utilizadores");
            }
            if (User.IsInRole("Adminstrador")==false)
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Adminstrador"}
                };
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            db.Utilizadors.Remove(utilizador);
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
