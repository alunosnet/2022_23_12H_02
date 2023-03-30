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
    public partial class EditarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            //consultar a bd para recolher os dados do utilizador
            if (IsPostBack) return;
            try
            {
                int id = int.Parse(Request["idutilizador"].ToString());
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Utilizador não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
                tbTelefone.Text = dados.Rows[0]["telefone"].ToString();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Utilizadores/Utilizadores.aspx')", true);
            }


        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text.Trim();
                if (string.IsNullOrEmpty(nome) || nome.Length < 3)
                {
                    throw new Exception("O nome não é válido.");
                }
                string telefone = tbTelefone.Text.Trim();
                if (string.IsNullOrEmpty(telefone) || telefone.Length != 9)
                {
                    throw new Exception("Atelefone não é válida.");
                }
                string nif = tbNif.Text.Trim();
                if (string.IsNullOrEmpty(nif) || nif.Length != 9)
                {
                    throw new Exception("O nif não é válido.");
                }
                int id = int.Parse(Request["idutilizador"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.telefone = int.Parse(telefone);
                utilizador.nif = nif;
                utilizador.atualizarUtilizador();
            }
            catch (Exception error)
            {
                lbErro.Text = "Ocorreu um erro: " + error.Message;
                return;
            }
            lbErro.Text = "Utilizador atualizado com sucesso.";
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Utilizadores/Utilizadores.aspx')", true);
        }
    }
}