using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoComparacaoRegraLogicaDAO : BaseCRUD<TipoComparacaoRegraLogica>
    {

        #region BaseCRUD<TipoComparacaoRegraLogica> Members

        public void Novo(TipoComparacaoRegraLogica entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoComparacaoRegraLogica entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoComparacaoRegraLogica entidade)
        {
            throw new NotImplementedException();
        }

        public TipoComparacaoRegraLogica Listar(TipoComparacaoRegraLogica entidade)
        {
            var tipoComparacaoRegraLogica = new TipoComparacaoRegraLogica();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoComparacaoRegraLogica",
                Value = entidade.IDTipoComparacaoRegraLogica
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoComparacaoRegraLogicaListar", parm))
            {
                if (reader.Read())
                {
                    tipoComparacaoRegraLogica.IDTipoComparacaoRegraLogica = Convert.ToInt32(reader["IDTipoComparacaoRegraLogica"]);
                    tipoComparacaoRegraLogica.Descricao = reader["Descricao"].ToString();
                    tipoComparacaoRegraLogica.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoComparacaoRegraLogica.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoComparacaoRegraLogica.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoComparacaoRegraLogica;

        }


        public List<TipoComparacaoRegraLogica> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
