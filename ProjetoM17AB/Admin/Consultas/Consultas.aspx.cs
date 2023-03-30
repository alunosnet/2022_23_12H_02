using ProjetoM17AB.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoM17AB.Admin.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();
        }

        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                //Resorts Ocupados
                case 0:
                    sql = @"SELECT * FROM resorts WHERE estado=1";
                    break;

                //Resorts com Piscina
                case 1:
                    sql = @"SELECT * FROM resorts WHERE piscina=1";
                    break;

                //Utilizadores com o Cargo Admin
                case 2:
                    sql= @"SELECT idutilizador, nome, email FROM utilizadores WHERE perfil=0";
                    break;

                //Ordenar resorts por preco
                case 3:
                    sql= @"SELECT * FROM resorts Order by precoNoite";
                    break;

                //Top dos resorts mais alugados
                case 4:
                    sql= @"SELECT Resorts.idresort,count(Alugueres.idresort) as [Nº de Alugueres] 
                            FROM Resorts
                            INNER JOIN Alugueres ON Resorts.idresort=Alugueres.idresort 
                            GROUP BY Resorts.idresort,Resorts.idresort
                            ORDER BY count(Alugueres.idresort) DESC";
                    break;


            }

            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();

        }

    }
}