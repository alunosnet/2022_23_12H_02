using ProjetoM17AB.Classes;
using ProjetoM17AB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //atualizar grelha livros
            atualizaListaResorts(null);
        }

        private void atualizaListaResorts(string pesquisa = null, int? ordena = null)
        {
            Resort res = new Resort();
            DataTable dados;
            dados = res.listaResortsDisponiveis();
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divResorts.InnerHtml = "";
                return;
            }
            string grelha = "<div class='row mt-6'>";
            foreach (DataRow resort in dados.Rows)
            {
                grelha += @"<div class='col-6 mt-3' style='margin-right:100px'>
                            <div class='card' style = 'width: 17rem;'>
                             <div class='card-body'>
                             <h5 class='card-title'>" + resort[1].ToString() + "</h5>";
                grelha += "<a href='detalhesresort.aspx?idresort=" + resort[0].ToString() + "'>Detalhes</a>";
                grelha += "</div>";
                grelha += "</div>";
                grelha += "</div>";
            }
            divResorts.InnerHtml = grelha;
        }

    }
}