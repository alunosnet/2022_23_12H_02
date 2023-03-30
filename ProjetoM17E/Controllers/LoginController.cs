using Microsoft.Ajax.Utilities;
using ProjetoM17E.Data;
using ProjetoM17E.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoM17E.Controllers
{
    public class LoginController : Controller
    {
        private ProjetoM17EContext db = new ProjetoM17EContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Utilizador utilizador)
        {
            if (utilizador.Email != null && utilizador.Password != null)
            {
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);

                foreach (var u in db.Utilizadors.Where(u => u.Perfil==1).ToList())
                {
                    if (u.Email.ToLower()==utilizador.Email.ToLower() && u.Password==utilizador.Password)
                    {
                        //iniciar sessao
                        FormsAuthentication.SetAuthCookie(utilizador.Email, false);

                        //redirecionar
                        if (Request.QueryString["ReturnUrl"]==null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente ou verifique se é adminstrador. ");
            return View(utilizador);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}