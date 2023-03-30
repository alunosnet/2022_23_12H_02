﻿using ProjetoM17AB.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoM17AB.Models
{
    public class Utilizador
    {
        public int id;
        public string nome;
        public string email;
        public int telefone;
        public string nif;
        public string password;
        public int perfil;


        BaseDados bd;

        public Utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar
        public void Adicionar()
        {
            string sql = @"INSERT INTO utilizadores(email,nome,telefone,nif,password,perfil,estado)
                            VALUES (@email,@nome,@telefone,@nif,HASHBYTES('SHA2_512',@password),@perfil,@estado)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@telefone",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.telefone
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=1
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
                
            };
            bd.executaSQL(sql, parametros);


        }
        internal DataTable ListaTodosUtilizadores()
        {
            return bd.devolveSQL("SELECT * FROM Utilizadores");
        }

        public void atualizarUtilizador()
        {
            string sql = @"UPDATE utilizadores SET nome=@nome,telefone=@telefone,nif=@nif 
                            WHERE idutilizador=@idutilizador";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@telefone",SqlDbType=SqlDbType.Int,Value=telefone },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);


        }

        public DataTable devolveDadosUtilizador(int id)
        {
            string sql = "SELECT * FROM utilizadores WHERE idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }

        public int estadoUtilizador(int id)
        {
            string sql = "SELECT estado FROM utilizadores WHERE idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=id}
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return int.Parse(dados.Rows[0][0].ToString());
        }

        public void ativarDesativarUtilizador(int idutilizador)
        {
            int estado = this.estadoUtilizador(idutilizador);
            if (estado == 0) estado = 1;
            else estado = 0;
            string sql = "UPDATE utilizadores SET estado = @estado WHERE idutilizador=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Bit,Value=estado },
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value= idutilizador }
            };
            bd.executaSQL(sql, parametros);
        }

        public void removerUtilizador(int idutilizador)
        {
            string sql = "DELETE FROM Utilizadores WHERE idutilizador=@idutilizador";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value= idutilizador},
            };
            bd.executaSQL(sql, parametros);
        }

        public void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE utilizadores set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }


        public void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE utilizadores set password=HASHBYTES('SHA2_512',@password),estado=1,lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }

        public DataTable devolveDadosUtilizador(string email)
        {
            string sql = "SELECT * FROM utilizadores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }

    }
}