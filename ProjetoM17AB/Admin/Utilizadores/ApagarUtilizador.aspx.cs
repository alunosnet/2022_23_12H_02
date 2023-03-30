using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin.Utilizadores
{
    public partial class ApagarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;

            try
            {
                int idutilizador = int.Parse(Request["idutilizador"].ToString());
                Utilizador uti = new Utilizador();

                DataTable dados = uti.devolveDadosUtilizador(idutilizador);

                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("O utilizador não existe");
                }

                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbId.Text = dados.Rows[0]["idutilizador"].ToString();
            }

            catch
            {
                Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int idutilizador = int.Parse(Request["idutilizador"].ToString());
            Utilizador uti = new Utilizador();

            uti.removerUtilizador(idutilizador);
            Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
        }
    }
}