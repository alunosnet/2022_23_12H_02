using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15_ProjetoFutebol
{
    internal class Consultas
    {
        public DataTable primeiraConsulta(BaseDados bd)
        {
            string sql = @"select equipas.nome, count(*) as [nº de contratos] 
                       from contratos inner join equipas
                       on contratos.nequipa = equipas.nequipa
                       group by equipas.nome";
            return bd.DevolveSQL(sql);
        }

        public DataTable segundaConsulta(BaseDados bd)
        {
            string sql = @"select nome, (idade+10) as [idade daqui a 10 anos]
                        from Jogadores";
            return bd.DevolveSQL(sql);
        }

        public DataTable terceiraConsulta(BaseDados bd)
        {
            string sql = @"select nome
                        from Jogadores
                        Where estado = 1";
            return bd.DevolveSQL(sql);
        }

        public DataTable quartaConsulta(BaseDados bd)
        {
            string sql = @"select iif(charindex(' ', nome, 1) = 0, Nome, Left(nome,charindex(' ', nome, 1))) as [Primeiro nome]
                        from Jogadores";
            return bd.DevolveSQL(sql);
        }

    }
}
