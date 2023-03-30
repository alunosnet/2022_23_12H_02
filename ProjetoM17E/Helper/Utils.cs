using ProjetoM17E.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoM17E.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper, System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";
            using (var context = new ProjetoM17EContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT UtilizadorId FROM Utilizadors Where email=@p0", utilizador.Identity.Name);
                if (consulta.ToList().Count>0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }
            return iduser;

        }
    }
}