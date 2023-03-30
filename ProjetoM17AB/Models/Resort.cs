using ProjetoM17AB.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoM17AB.Models
{
    public class Resort
    {
        public int idresort;
        public int numero;
        public string capacidade;
        public decimal precoNoite;
        public int piscina;
        public int estado;

        BaseDados bd;
        public Resort()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = @"INSERT INTO Resorts(nresort,capacidade,precoNoite,piscina,estado)
                    VALUES (@nresort, @capacidade, @precoNoite, @piscina,0);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nresort",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.numero
                },
                new SqlParameter()
                {
                    ParameterName="@capacidade",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.capacidade
                },
                new SqlParameter()
                {
                    ParameterName="@precoNoite",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.precoNoite
                },
                
                new SqlParameter()
                {
                    ParameterName="@piscina",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.piscina
                },

            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        public DataTable devolveDadosResort(int idresort)
        {
            string sql = "SELECT * FROM Resorts WHERE idresort=@idresort";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public void removerResort(int idresort)
        {
            string sql = "DELETE FROM Resorts WHERE idresort=@idresort";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort }
            };
            bd.executaSQL(sql, parametros);
        }

        public void AtualizaResort()
        {
            string sql = "UPDATE Resorts SET nresort=@nresort, capacidade=@capacidade, precoNoite=@precoNoite, piscina=@piscina WHERE idresort=@idresort;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nresort",SqlDbType=SqlDbType.VarChar,Value= numero},
                new SqlParameter() {ParameterName="@capacidade",SqlDbType=SqlDbType.VarChar,Value= capacidade},
                new SqlParameter() {ParameterName="@precoNoite",SqlDbType=SqlDbType.Decimal,Value= precoNoite},
                new SqlParameter() {ParameterName="@piscina",SqlDbType=SqlDbType.Int,Value=piscina},
                new SqlParameter() {ParameterName="@idresort",SqlDbType=SqlDbType.Int,Value=idresort}
            };
            bd.executaSQL(sql, parametros);

        }

        public DataTable listaResortsDisponiveis()
        {
            string sql = "SELECT * FROM Resorts WHERE estado=0";
            
            return bd.devolveSQL(sql);
        }

        internal DataTable ListaTodosResorts()
        {
            string sql = @"SELECT idresort,nresort,capacidade,precoNoite,
                    case
                        when estado=0 then 'livre'
                        when estado=1 then 'ocupado'
                        when estado=2 then 'reservado'
                    end as estado,
                    case
                        when piscina=0 then 'sem piscina'
                        when piscina=1 then 'com piscina'
                    end as piscina
                    FROM resorts";
            return bd.devolveSQL(sql);
        }


    }

    
}