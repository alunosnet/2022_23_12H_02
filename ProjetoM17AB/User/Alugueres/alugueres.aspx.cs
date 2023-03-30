using ProjetoM17AB.Admin.Alugueres;
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
    public partial class alugueres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            AtualizarGrid();

        }


        private void AtualizarGrid()
        {
            gvresorts.Columns.Clear();
            gvresorts.DataSource = null;
            gvresorts.DataBind();

            Resort res = new Resort();
            gvresorts.DataSource = res.listaResortsDisponiveis();

            //botão reservar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Reservar";
            bt.Text = "Reservar";
            bt.ButtonType= ButtonType.Button;
            bt.CommandName = "reservar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            gvresorts.Columns.Add(bt);

            gvresorts.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvresorts.RowCommand += Gvresorts_RowCommand; ;
        }

        private void Gvresorts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int idresort = int.Parse(gvresorts.Rows[linha].Cells[1].Text);
            if (e.CommandName=="reservar")
            {
                Response.Redirect("~/User/Alugueres/reserva.aspx?idresort=" + idresort);
                AtualizarGrid();
            }
        }
    }


}