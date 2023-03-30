using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15_ProjetoFutebol.Equipas
{
    public class Equipa
    {

        public int nequipa { get; set; }
        public string Nome { get; set; }
        public string Campeonato { get; set; }
        public byte[] Emblema { get; set; }

        public Equipa(int nequipa, string nome, string campeonato, byte[] emblema)
        {
            this.nequipa=nequipa;
            Nome=nome;
            Campeonato=campeonato;
            Emblema=emblema;
        }

        public Equipa()
        {

        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"Insert into Equipas(nome,campeonato,emblema) values
                        (@nome,@campeonato,@emblema)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {

                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },

                new SqlParameter()
                {
                    ParameterName="@campeonato",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Campeonato
                },

                new SqlParameter()
                {
                    ParameterName="@emblema",
                    SqlDbType=System.Data.SqlDbType.VarBinary,
                    Value=this.Emblema

                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * From Equipas";
            return bd.DevolveSQL(sql);
        }

        public static void Apagar(BaseDados bd, int nequipa_escolhida)
        {
            string sql = "DELETE FROM Equipas WHERE nequipa=" + nequipa_escolhida;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"Update Equipas set nome=@nome, campeonato=@campeonato";
            if (this.Emblema != null)
                sql += ",emblema = @emblema";
            sql += " where nequipa=@nequipa";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nequipa",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nequipa
                },

                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },

                new SqlParameter()
                {
                    ParameterName="@campeonato",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Campeonato
                },

            };
            if (this.Emblema != null)
                parametros.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@Emblema",
                        SqlDbType = System.Data.SqlDbType.VarBinary,
                        Value = this.Emblema
                    }
                );
            bd.ExecutaSQL(sql, parametros);
        }

        /// <summary>
        /// Nao ficar o caminho da basedados na tabela contratos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Nome;
        }

        internal void Procurar(int nequipa, BaseDados bd)
        {
            string sql = "Select * From equipas where nequipa=" + nequipa;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp!=null && temp.Rows.Count>0)
            {
                this.nequipa = int.Parse(temp.Rows[0]["nequipa"].ToString());
                this.Nome = temp.Rows[0]["nome"].ToString();
                this.Campeonato = temp.Rows[0]["campeonato"].ToString();
                this.Emblema = (byte[])temp.Rows[0]["emblema"];
            }
        }

        internal static object Pesquisa(BaseDados bd, string nome)
        {
            string sql = @"Select * from equipas where nome Like @nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }
    }
}
