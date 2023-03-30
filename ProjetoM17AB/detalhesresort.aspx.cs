using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB
{
    public partial class detalhesresort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["idresort"].ToString());
                Resort res = new Resort();
                DataTable dados = res.devolveDadosResort(id);
                lbNResort.Text = dados.Rows[0]["nresort"].ToString();
                lbCapacidade.Text = dados.Rows[0]["capacidade"].ToString();
                if (dados.Rows[0]["piscina"].ToString()=="1")
                {
                    lbPiscina.Text = "Sim";
                }
                else 
                {
                    lbPiscina.Text = "Não";
                }
                lbPreco.Text = String.Format("{0:c}", Decimal.Parse(dados.Rows[0]["precoNoite"].ToString()));
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }

        //protected void btReservar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int idresort = int.Parse(Request["idresort"].ToString());
        //        int idutilizador = int.Parse(Session["idutilizador"].ToString());
        //        Alugueres alu = new Alugueres();
        //        alu.adicionarAluguer(idresort, idutilizador, );
        //        lbErro.Text = "Livro reservado com sucesso";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page),
        //            "Redirecionar", "returnMain('/index.aspx')", true);
        //    }
        //    catch
        //    {
        //        Response.Redirect("/index.aspx");
        //    }
        //}
    }
}