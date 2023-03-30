using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.User.Alugueres
{
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1")==false)
            {
                Response.Redirect("~/index.aspx");
            }

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvhistorico.Columns.Clear();
            gvhistorico.DataSource = null;
            gvhistorico.DataBind();

            int idutilizador = int.Parse(Session["idutilizador"].ToString());
            Models.Alugueres alu = new Models.Alugueres();
            gvhistorico.DataSource = alu.listaTodosaluComNomes(idutilizador);
            gvhistorico.DataBind();
        }
    }
}