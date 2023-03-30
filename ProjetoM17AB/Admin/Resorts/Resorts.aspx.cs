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
    public partial class Resorts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        /// <summary>
        /// Configuração da grelha dos resorts
        /// </summary>
        private void ConfigurarGrid()
        {
            gvResorts.AllowPaging= true;
            gvResorts.PageSize = 5;
            gvResorts.PageIndexChanging += GvResorts_PageIndexChanging;
        }

        private void GvResorts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResorts.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                int nresort = int.Parse(tbNResort.Text);
                if(nresort == 0) //todo: nao pode meter um que ja tem 
                {
                    throw new Exception("O numero é muito pequeno.");
                }
                string capacidade = tbCapacidade.Text;
                if(capacidade.Length == 0)
                {
                    throw new Exception("Capacidade inválida.");
                }
                Decimal precoNoite = Decimal.Parse(tbPrecoNoite.Text);
                if(precoNoite < 0)
                {
                    throw new Exception("O preço deve ser maior que 0.");
                }

                Resort res = new Resort();
                res.numero = nresort;
                res.precoNoite = precoNoite;
                res.capacidade = capacidade;
                res.piscina = cbPiscina.Checked==true ? 1:0;
                res.estado = 0;
                int idresort = res.Adicionar();
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }

            //limpar form
            tbNResort.Text = "";
            tbCapacidade.Text = "";
            tbPrecoNoite.Text = "";
            cbPiscina.Checked = false;

            //Atualiza grid
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            

            gvResorts.Columns.Clear();
            Resort res = new Resort();
            DataTable dados = res.ListaTodosResorts();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvResorts.DataSource= dados;
            gvResorts.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarResort.aspx?idresort={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "idresort" };
            hlEditar.ControlStyle.CssClass = "btn btn-info";
            gvResorts.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarResort.aspx?idresort={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "idresort" };
            hlApagar.ControlStyle.CssClass = "btn btn-danger";
            gvResorts.Columns.Add(hlApagar);
            //idresort
            BoundField bfidresort = new BoundField();
            bfidresort.HeaderText = "Id Resort";
            bfidresort.DataField = "idresort";
            gvResorts.Columns.Add(bfidresort);
            //nome
            BoundField bfnresort = new BoundField();
            bfnresort.HeaderText = "Nª Resort";
            bfnresort.DataField = "nresort";
            gvResorts.Columns.Add(bfnresort);
            //ano
            BoundField bfcapacidade = new BoundField();
            bfcapacidade.HeaderText = "Capacidade";
            bfcapacidade.DataField = "capacidade";
            gvResorts.Columns.Add(bfcapacidade);
            //Preço
            BoundField bfprecoN = new BoundField();
            bfprecoN.HeaderText = "Preço Noite";
            bfprecoN.DataField = "precoNoite";
            bfprecoN.DataFormatString = "{0:C}";
            gvResorts.Columns.Add(bfprecoN);
            //Tipo
            BoundField bfpiscina = new BoundField();
            bfpiscina.HeaderText = "Piscina";
            bfpiscina.DataField = "piscina";
            gvResorts.Columns.Add(bfpiscina);
            //Estado
            BoundField bfestado = new BoundField();
            bfestado.HeaderText = "Estado";
            bfestado.DataField = "estado";
            gvResorts.Columns.Add(bfestado);

            gvResorts.DataBind();
        }
    }
}