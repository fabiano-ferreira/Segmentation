using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoStatusEntidadeDAO: BaseCRUD<TipoStatusEntidade>
    {
        #region BaseCRUD<TipoStatusEntidade> Members

        public void Novo(TipoStatusEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoStatusEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoStatusEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public TipoStatusEntidade Listar(TipoStatusEntidade entidade)
        {
            var tipoStatusEntidade = new TipoStatusEntidade();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdTipoStatusEntidade",
                Value = entidade.IdTipoStatusEntidade
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoStatusEntidadeListar", parm))
            {
                if (reader.Read())
                {
                    tipoStatusEntidade.IdTipoStatusEntidade = Convert.ToInt32(reader["IdTipoStatusEntidade"]);
                    tipoStatusEntidade.Nome = reader["Nome"].ToString();
                    tipoStatusEntidade.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoStatusEntidade.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoStatusEntidade.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])};
                }
            }

            return tipoStatusEntidade;
        }

        public List<TipoStatusEntidade> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
