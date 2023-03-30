using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15_ProjetoFutebol.Contratos
{
    class Contrato
    {
        public int ncontrato;
        public int njogador;
        public int nequipa;
        public DateTime DataIncioContrato;
        public DateTime DataFimContrato;

        public Contrato()
        {

        }

        public Contrato(int njogador, int nequipa, DateTime dataIncioContrato, DateTime dataFimContrato)
        {
            this.njogador=njogador;
            this.nequipa=nequipa;
            DataIncioContrato=dataIncioContrato;
            DataFimContrato=dataFimContrato;
        }

        internal static void Apagar(BaseDados bd, int ncontrato_escolhido)
        {
            string sql = "DELETE FROM contratos WHERE ncontrato=" + ncontrato_escolhido;
            bd.ExecutaSQL(sql);
        }

        internal static object ListarContratados(BaseDados bd)
        {
            string sql = @"select * from contratos";
            return bd.DevolveSQL(sql);
        }

        public static object UpdateJogador(BaseDados bd, int njogador_escolhido)
        {
            string sql = @"update Jogadores Set estado=0 where Jogadores.njogador = " + njogador_escolhido;
            return bd.DevolveSQL(sql);
        }

        public void Contratar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into contratos(njogador,nequipa,
                            inicio_contrato,fim_contrato) values 
                            (@njogador,@nequipa,@inicio_contrato,
                                @fim_contrato)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.njogador
                },
                new SqlParameter()
                {
                    ParameterName="@nequipa",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nequipa
                },
                new SqlParameter()
                {
                    ParameterName="@inicio_contrato",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataIncioContrato
                },
                new SqlParameter()
                {
                    ParameterName="@fim_contrato",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.DataFimContrato
                },
            };
            //executar
            bd.ExecutaSQL(sql, parametros);
            //alterar o estado do livro emprestado para 0
            sql = "UPDATE Jogadores SET estado=1 WHERE njogador=" + njogador;
            bd.ExecutaSQL(sql);

        }

        public DataTable Procurar(int ncontrato, BaseDados bd)
        {
            string sql = "Select * from contratos where ncontrato=" + ncontrato;
            DataTable temp = bd.DevolveSQL(sql);

            if(temp != null && temp.Rows.Count>0)
            {
                this.ncontrato = int.Parse(temp.Rows[0]["ncontrato"].ToString());
                this.njogador = int.Parse(temp.Rows[0]["njogador"].ToString());
                this.nequipa = int.Parse(temp.Rows[0]["nequipa"].ToString());
                this.DataIncioContrato = DateTime.Parse(temp.Rows[0]["inicio_contrato"].ToString());
                this.DataFimContrato = DateTime.Parse(temp.Rows[0]["fim_contrato"].ToString());
            }
            return temp;

        }

        public void FimContrato(BaseDados bd)
        {
            string sql = @"Update Jogadores set estado = 0 
                        where njogador in (select njogador from contratos where fim_contrato <= getdate());
                        Delete from Contratos where fim_contrato <= getdate()";
            bd.ExecutaSQL(sql);
        }

    }
}
