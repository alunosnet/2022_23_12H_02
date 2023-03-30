using ProjetoM17AB.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoM17AB.Models
{
    public class Alugueres
    {
        BaseDados bd;

        public Alugueres()
        {
            this.bd = new BaseDados();
        }

        public decimal adicionarAluguer(int idresort, int idutilizador, DateTime dataEntrada, DateTime dataSaida)
        {
            string sql = "SELECT * FROM Resorts WHERE idresort=@idresort";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //verificar disponibilidade do resort
                if (dados.Rows[0]["estado"].ToString() != "0")
                    throw new Exception("Resort não está disponível");
                //alterar estado do resort
                sql = "UPDATE Resorts SET estado=@estado WHERE idresort=@idresort";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO Alugueres(idresort,idutilizador,data_Entrada,data_Saida,preco_pago) 
                            VALUES (@idresort,@idutilizador,@dataEntrada,@dataSaida,(SELECT resorts.precoNoite*(DATEDIFF(day,@dataEntrada,@dataSaida)) as pagamento 
                FROM resorts WHERE resorts.idresort = @idresort));SELECT CAST(SCOPE_IDENTITY() AS INT)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort },
                    new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador },
                    new SqlParameter() {ParameterName="@dataEntrada",SqlDbType=SqlDbType.Date,Value=dataEntrada},
                    new SqlParameter() {ParameterName="@dataSaida",SqlDbType=SqlDbType.Date,Value= dataSaida},
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=1 },

                };
                int id=bd.executaEDevolveSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
                sql = "SELECT preco_pago FROM alugueres WHERE idalugueres = " + id;
                DataTable dados2 =  bd.devolveSQL(sql);
                return decimal.Parse(dados2.Rows[0][0].ToString());
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
            return -1;
        }

        public void adicionarReserva(int idresort, int idutilizador, DateTime data_entrada, DateTime data_saida)
        {
            string sql = "SELECT * FROM resorts WHERE idresort=@idresort";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //testar se o livro ainda está disponível
                if (dados.Rows[0]["estado"].ToString() != "0")
                    throw new Exception("Resort não está disponível");
                //alterar estado do livro
                sql = "UPDATE Resorts SET estado=@estado WHERE idresort=@idresort";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value= 1 },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO Emprestimos(idresort,idutilizador,data_entrada,data_saida,preco_pago,estado) 
                            VALUES (@idresort,@idutilizador,@data_entrada,@data_saida,@preco_pago,@estado)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort },
                    new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador },
                    new SqlParameter() {ParameterName="@data_entrada",SqlDbType=SqlDbType.Date,Value= data_entrada},
                    new SqlParameter() {ParameterName="@data_saida",SqlDbType=SqlDbType.Date,Value= data_saida },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value= 1 },
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }

        
        public DataTable listaTodosAlugueresComNomes()
        {
            string sql = @"SELECT idalugueres, resorts.nresort, utilizadores.nome, data_entrada, data_saida, preco_pago,
                        case
                            when alugueres.estado=0 then 'Concluído'
                            when alugueres.estado=1 then 'Ocupado'
                        end as estado
                        FROM Alugueres inner join Resorts on alugueres.idresort=resorts.idresort
                        inner join utilizadores on alugueres.idutilizador=utilizadores.idutilizador";
            return bd.devolveSQL(sql);
        }

        public DataTable listaTodosaluComNomes(int idutilizador)
        {
            string sql = @"SELECT idalugueres,resorts.nresort as nResort, utilizadores.nome as nomeUtilizador, data_entrada,data_saida,
                        case
                            when alugueres.estado=0 then 'Concluído'
                            when alugueres.estado=1 then 'Ocupado'
                        end as estado
                        FROM Alugueres inner join Resorts on alugueres.idresort=resorts.idresort
                        inner join utilizadores on alugueres.idutilizador=utilizadores.idutilizador
                        where Alugueres.idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador }
            };
            return bd.devolveSQL(sql, parametros);
        }


        public void alterarEstadoAluguer(int idaluguer)
        {
            DataTable dadosAluguer = devolveDadosAluguer(idaluguer);
            int idresort = int.Parse(dadosAluguer.Rows[0]["idresort"].ToString());
            int novoestadoresort, novoestadoaluguer;
            novoestadoresort = 0;
            novoestadoaluguer = 0;

            string sql = "SELECT * FROM resorts WHERE idresort=@idresort";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //terminar aluguer
                sql = @"UPDATE Resorts SET estado=@estado WHERE idresort=@idresort";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value= novoestadoresort },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //concluir transação
                sql = @"UPDATE Alugueres SET estado=@estado WHERE idalugueres=@idalugueres";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idalugueres",SqlDbType=SqlDbType.Int,Value= idaluguer },
                    new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value= novoestadoaluguer },
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }

        public DataTable devolveDadosAluguer(int idalugueres)
        {
            string sql = "SELECT * FROM alugueres WHERE idalugueres=@idalugueres";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idalugueres",SqlDbType=SqlDbType.Int,Value=idalugueres }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public DataTable devolvePagamento(int idalugueres)
        {
            string sql = "SELECT resorts.precoNoite*(DATEDIFF(day,alugueres.data_entrada,alugueres.data_saida)) as pagamento " +
                "FROM alugueres inner join resorts on alugueres.idresort=resorts.idresort" +
                "WHERE idalugueres = @idalugueres";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idalugueres",SqlDbType=SqlDbType.Int,Value=idalugueres }
            };
            return bd.devolveSQL(sql, parametros);
        }
    }


}