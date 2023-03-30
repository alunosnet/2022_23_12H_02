using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_ProjetoFutebol.Jogadores
{
    public class Jogador
    {
        public int njogador { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public byte[] Fotografia { get; set; }
        public bool Estado { get; set; }

        public Jogador()
        {

        }

        public Jogador(int njogador, string nome, int idade, byte[] fotografia, bool estado)
        {
            this.njogador=njogador;
            Nome=nome;
            Idade=idade;
            Fotografia=fotografia;
            Estado=estado;
        }

        

        public void Guardar(BaseDados bd)
        {
            string sql = @"Insert into Jogadores(nome,idade,fotografia,estado) values
                        (@nome,@idade,@fotografia,0)";
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
                    ParameterName="@idade",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Idade
                },

                new SqlParameter()
                {
                    ParameterName="@fotografia",
                    SqlDbType=System.Data.SqlDbType.VarBinary,
                    Value=this.Fotografia
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * From Jogadores";
            return bd.DevolveSQL(sql);
        }


        internal static void Apagar(BaseDados bd, int njogador_escolhido)
        {
            string sql = "DELETE FROM Jogadores WHERE njogador=" + njogador_escolhido;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"Update Jogadores set nome=@nome, idade=@idade, estado=0";
            if (this.Fotografia != null)
                sql += ",fotografia = @fotografia";
            sql += "where njogador=@njogador";
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
                    ParameterName="@idade",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Idade
                },

                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.njogador
                },
            };
            if (this.Fotografia != null)
                parametros.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@fotografia",
                        SqlDbType = System.Data.SqlDbType.VarBinary,
                        Value = this.Fotografia
                    }
                );
            bd.ExecutaSQL(sql, parametros);
        }

        /// <summary>
        /// Na tabela contratos o nome do jogador nao 
        /// ficar com o caminho da base de dados
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Nome;
        }

        public void Procurar(int njogador, BaseDados bd)
        {
            string sql = "Select * From jogadores where njogador=" + njogador;
            DataTable temp = bd.DevolveSQL(sql);

            if(temp!=null && temp.Rows.Count>0)
            {
                this.njogador = int.Parse(temp.Rows[0]["njogador"].ToString());
                this.Nome = temp.Rows[0]["nome"].ToString();
                this.Idade = int.Parse(temp.Rows[0]["idade"].ToString());
                this.Fotografia = (byte[])temp.Rows[0]["Fotografia"];
                this.Estado = bool.Parse(temp.Rows[0]["estado"].ToString());
            }
        }

        public static DataTable Pesquisa(BaseDados bd, string nome)
        {
            string sql = @"Select * from jogadores where nome Like @nome";
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

        internal static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos from Jogadores";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        internal static object ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT njogador,nome,idade,fotografia,Estado FROM
                        (SELECT row_number() over (order by njogador) as Num,* FROM Jogadores) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.DevolveSQL(sql);
        }

        internal static DataTable ListarDisponiveis(BaseDados bd)
        {
            string sql = "select * from jogadores WHERE estado=0";
            return bd.DevolveSQL(sql);
        }
    }
}
