using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjetoM17AB.Admin.Resorts
{
    public partial class EditarResort : System.Web.UI.Page
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
                
                int id = int.Parse(Request["idresort"].ToString());

                Resort res = new Resort();
                DataTable dados = res.devolveDadosResort(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("Resort não existe.");
                }
                //mostrar os dados livro
                tbNResort.Text = dados.Rows[0]["nresort"].ToString();
                tbCapacidade.Text = dados.Rows[0]["capacidade"].ToString();
                tbPrecoNoite.Text = dados.Rows[0]["precoNoite"].ToString();
                if (dados.Rows[0]["piscina"].ToString() == "0")
                {
                    cbPiscina.Checked = false;
                }else
                {
                    cbPiscina.Checked = true;
                }
                
            }
            catch
            {
                Response.Redirect("~/Admin/Resorts/Resorts.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int nresort = int.Parse(tbNResort.Text);
                if (nresort == 0) //todo: nao pode meter um que ja tem 
                {
                    throw new Exception("O numero é muito pequeno.");
                }
                string capacidade = tbCapacidade.Text;
                if (capacidade.Length == 0)
                {
                    throw new Exception("Capacidade inválida.");
                }
                Decimal precoNoite = Decimal.Parse(tbPrecoNoite.Text);
                if (precoNoite < 0)
                {
                    throw new Exception("O preço deve ser maior que 0.");
                }

                Resort res = new Resort();
                res.numero = nresort;
                res.precoNoite = precoNoite;
                res.capacidade = capacidade;
                res.piscina = cbPiscina.Checked==true ? 1 : 0;
                int idresort = int.Parse(Request["idresort"].ToString());
                res.idresort = idresort;
                res.AtualizaResort();

                lbErro.Text = "O Resort foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Resorts.aspx')", true);
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }
    }
}