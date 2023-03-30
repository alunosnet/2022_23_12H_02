using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            divEditar.Visible= false;
            MostrarPerfil();
        }

        void MostrarPerfil()
        {
            int id = int.Parse(Session["idutilizador"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbTelefone.Text = dados.Rows[0]["telefone"].ToString();
                lbnif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbTelefone.Text = dados.Rows[0]["telefone"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }
        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["idutilizador"].ToString());
            string nome = tbNome.Text;
            int telefone = int.Parse(tbTelefone.Text);
            string nif = tbNif.Text;
            //TODO: validar os dados
            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.telefone = telefone;
            utilizador.nif= nif;
            utilizador.id = id;
            utilizador.atualizarUtilizador();
            btCancelar_Click(sender, e);
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
    }
}