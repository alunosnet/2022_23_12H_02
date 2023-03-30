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
    public partial class reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime data_entrada = DateTime.Parse(tb_dataentrada.Text);
                DateTime data_saida = DateTime.Parse(tb_datasaida.Text);
                int idresort = int.Parse(Request["idresort"].ToString());
                int idutilizador = int.Parse(Session["idutilizador"].ToString());
                Models.Alugueres alu = new Models.Alugueres();
                decimal preco = alu.adicionarAluguer(idresort, idutilizador, data_entrada, data_saida);

                lb_erro.Text = $"O aluguer foi registado com sucesso. Tem {preco} a pagar";
                lb_erro.CssClass = "";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('livros.aspx')", true);



            } catch(Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }

        }

        protected void bt_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Alugueres/alugueres.aspx");
        }
    }
}