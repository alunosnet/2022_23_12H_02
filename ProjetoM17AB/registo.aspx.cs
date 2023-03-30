using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btguardar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                //validar o form
                string nome = tbnome.Text.Trim();
                if (nome.Length < 3)
                {
                    throw new Exception("O nome tem de ter pelo menos 3 letras");
                }
                string email = tbemail.Text.Trim();
                if (email == String.Empty || email.Contains("@") == false ||
                   email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido");
                }
                string telefone = tbtelefone.Text.Trim();
                if (telefone.Length != 9)
                {
                    throw new Exception("o telefone tem de ter 9 números");
                }
                string nif = tbnif.Text.Trim();
                if (nif.Length != 9)
                {
                    throw new Exception("O nif tem de ter 9 números");
                }
                string password = tbpassword.Text.Trim();
                if (password.Length < 5)
                {
                    throw new Exception("A password tem de ter pelo menos 5 letras");
                }

                int perfil = 1;

                //inserir o utilizador na bd
                Utilizador utilizador = new Utilizador();
                utilizador.nif = nif;
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.telefone = int.Parse(telefone);
                utilizador.password = password;
                utilizador.perfil = perfil;
                utilizador.Adicionar();
                lberro.Text = "Registado com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/login.aspx')", true);


            }
            catch (Exception erro)
            {
                lberro.Text = erro.Message;
                lberro.CssClass = "alert alert-danger";
            }
        }
    }
}