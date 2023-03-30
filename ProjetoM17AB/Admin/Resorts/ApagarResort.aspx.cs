using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin.Resorts
{
    public partial class ApagarResort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            try
            {
                //querystring nlivro
                int id = int.Parse(Request["idresort"].ToString());

                Resort res = new Resort();
                DataTable dados = res.devolveDadosResort(id);
                if (dados==null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("Resort não existe.");
                }
                //mostrar os dados livro
                lbNResort.Text = dados.Rows[0]["nresort"].ToString();
                lbCapacidade.Text = dados.Rows[0]["capacidade"].ToString();
                
            }
            catch
            {
                Response.Redirect("~/Admin/Livros/livros.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Livros/livros.aspx");
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int idresort = int.Parse(Request["idresort"].ToString());
                Resort res = new Resort();
                res.removerResort(idresort);
                //Response.Redirect("~/Admin/Livros/livros.aspx");
                lbErro.Text = "O livro foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Resorts.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Resorts/Resorts.aspx");
            }
        }
    }
}