using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"]!=null)
                divLogin.Visible=false;
        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_Email.Text.Trim().Length == 0)
                {
                    throw new Exception("Indique um email");
                }
                string email = tb_Email.Text.Trim();
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(email);
                if (dados==null || dados.Rows.Count != 1)
                {
                    throw new Exception("Foi enviado um email para recuperação da palavra passe");
                }
                Guid guid = Guid.NewGuid();
                utilizador.recuperarPassword(email, guid.ToString());

                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarpassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(guid.ToString()) + "'>Clique aqui</a>";

                string meuemail = ConfigurationManager.AppSettings["MeuEmail"];
                string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"];
                Helper.enviarMail(meuemail, minhapassword, email, "Recuperação de password", mensagem);

                lb_erro.Text = "Foi enviado um email para recuperação da palavra passe";
            }
            catch (Exception ex)
            {
                lb_erro.Text= ex.Message;
            }
        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_Email.Text;
                string password = tb_Password.Text;
                UserLogin user = new UserLogin();
                DataTable dados = user.VerificaLogin(email, password);
                if (dados == null)
                    throw new Exception("Login falhou");


                //iniciar sessão
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["idutilizador"] = dados.Rows[0]["idutilizador"].ToString();


                //autorização
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                Session["ip"] = Request.UserHostAddress;
                Session["useragent"] = Request.UserAgent;


                //redirecionar
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/User.aspx");
            }
            catch
            {
                lb_erro.Text = "Login falhou. Tente novamente";
            }
        }
    }
}