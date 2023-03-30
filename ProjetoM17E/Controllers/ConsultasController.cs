using ProjetoM17E.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoM17E.Controllers
{

    public class ConsultasController : Controller
    {
        private ProjetoM17EContext db = new ProjetoM17EContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PesquisaDinamica()
        {
            return View();
        }
        public JsonResult PesquisaNome(string nome)
        {
            var utilizadors = db.Utilizadors.Where(c => c.Nome.Contains(nome)).ToList();
            return Json(utilizadors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MelhorCliente()
        {
            string sql = @"SELECT Utilizadors.Nome, count(*) as [Nº Entregas]
                            FROM Entregas INNER JOIN Utilizadors
                            ON entregas.utilizadorid = Utilizadors.UtilizadorId
                            GROUP BY entregas.utilizadorid, utilizadors.Nome
                            ORDER BY count(*) DESC ";

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }

        public class Campos
        {
            public string nome { get; set; }
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