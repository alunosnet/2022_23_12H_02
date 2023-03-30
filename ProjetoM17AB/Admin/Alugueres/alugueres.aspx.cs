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

namespace ProjetoM17AB.Admin.Alugueres
{
    public partial class Alugueres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (IsPostBack) return;

            AtualizarGrid();
            AtualizarDDResorts();
            AtualizarDDUtilizadores();
        }

        private void AtualizarDDUtilizadores()
        {
            Utilizador u = new Utilizador();
            dd_utilizador.Items.Clear();
            DataTable dados = u.ListaTodosUtilizadores();
            foreach (DataRow linha in dados.Rows)
                dd_utilizador.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["idutilizador"].ToString())
                );
        }


        private void AtualizarDDResorts()
        {
            Resort res = new Resort();
            dd_resort.Items.Clear();
            DataTable dados = res.listaResortsDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_resort.Items.Add(
                    new ListItem(linha["nresort"].ToString(), linha["idresort"].ToString())
                );
        }


        private void AtualizarGrid()
        {
            Models.Alugueres alu = new Models.Alugueres();
            DataTable dados;
            dados = alu.listaTodosAlugueresComNomes();

            gv_alugueres.Columns.Clear();
            gv_alugueres.DataSource = null;
            gv_alugueres.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botões de comando
            //receber
            ButtonField bfReceber = new ButtonField();
            bfReceber.HeaderText = "Terminar aluguer";
            bfReceber.Text = "Terminar Aluguer";
            bfReceber.ButtonType = ButtonType.Button;
            bfReceber.ControlStyle.CssClass = "btn btn-info";
            bfReceber.CommandName = "terminar aluguer";
            gv_alugueres.Columns.Add(bfReceber);
            //enviar um email
            ButtonField bfEmail = new ButtonField();
            bfEmail.HeaderText = "Enviar email";
            bfEmail.Text = "Email";
            bfEmail.ButtonType = ButtonType.Button;
            bfEmail.ControlStyle.CssClass = "btn btn-danger";
            bfEmail.CommandName = "email";
            gv_alugueres.Columns.Add(bfEmail);

            gv_alugueres.DataSource = dados;
            gv_alugueres.AutoGenerateColumns = true;
            gv_alugueres.DataBind();
        }


        private void ConfigurarGrid()
        {
            //paginação
            gv_alugueres.AllowPaging = true;
            gv_alugueres.PageSize = 5;
            gv_alugueres.PageIndexChanging += Gv_alugueres_PageIndexChanging; 
            //botões de comando
            gv_alugueres.RowCommand += Gv_alugueres_RowCommand; 
            gv_alugueres.RowDataBound += Gv_alugueres_RowDataBound; 
        }

        private void Gv_alugueres_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_alugueres.PageIndex = e.NewPageIndex;
            AtualizarGrid(); ;
        }

        private void Gv_alugueres_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //mudar de página
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument.ToString());

            //id do aluguer
            int idaluguer = int.Parse(gv_alugueres.Rows[linha].Cells[2].Text);
            Models.Alugueres alu = new Models.Alugueres();
            if (e.CommandName=="terminar aluguer")
            {
                alu.alterarEstadoAluguer(idaluguer);
                AtualizarDDUtilizadores();
                AtualizarDDResorts();
                AtualizarGrid();
            }
            if (e.CommandName=="email")
            {
                string email = ConfigurationManager.AppSettings["MeuEmail"];
                string password = ConfigurationManager.AppSettings["MinhaPassword"];
                string assunto = "Aluguer fora de prazo";
                string texto = "Caro cliente deve devolver as chaves do resort.";
                DataTable dados = alu.devolveDadosAluguer(idaluguer);
                int idutilizador = int.Parse(dados.Rows[0]["idutilizador"].ToString());
                DataTable dadosutilizador = new Utilizador().devolveDadosUtilizador(idutilizador);
                string emailutilizador = dadosutilizador.Rows[0]["email"].ToString();
                Helper.enviarMail(email, password, emailutilizador, assunto, texto);
                AtualizarDDUtilizadores();
                AtualizarDDResorts();
                AtualizarGrid();
            }
        }

        private void Gv_alugueres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime datadevolve = DateTime.Parse(e.Row.Cells[6].Text);
                string estado = e.Row.Cells[8].Text;
                if (estado.StartsWith("Conc")==false)
                {
                    e.Row.Cells[0].Controls[0].Visible = true;
                    e.Row.Cells[1].Controls[0].Visible = true;                 
                }
                else
                {
                    e.Row.Cells[0].Controls[0].Visible = false;
                    e.Row.Cells[1].Controls[0].Visible = false;
                }


            }
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Alugueres alu = new Models.Alugueres();
                int idresort = int.Parse(dd_resort.SelectedValue);
                int idutilizador = int.Parse(dd_utilizador.SelectedValue);
                DateTime data_entrada = DateTime.Parse(tb_dataentrada.Text);
                DateTime data_saida = DateTime.Parse(tb_datasaida.Text);
              
                decimal preco= alu.adicionarAluguer(idresort, idutilizador, data_entrada, data_saida);

                lb_erro.Text = $"O aluguer foi registado com sucesso. Tem {preco} a pagar";
                lb_erro.CssClass = "";
            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
            AtualizarDDUtilizadores();
            AtualizarDDResorts();
            AtualizarGrid();
        }
    }
}