using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin.Utilizadores
{
    public partial class BloquearUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                int idutilizador = int.Parse(Request["idutilizador"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.ativarDesativarUtilizador(idutilizador);
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");

            }
            catch
            {

                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }
    }
}