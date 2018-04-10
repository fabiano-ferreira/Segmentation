using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoStatusUsuarioDAO: BaseCRUD<TipoStatusUsuario>
    {
        #region BaseCRUD<TipoStatusUsuario> Members

        public void Novo(TipoStatusUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoStatusUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoStatusUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public TipoStatusUsuario Listar(TipoStatusUsuario entidade)
        {
            var tipoStatusUsuario = new TipoStatusUsuario();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoSaida",
                Value = entidade.IdTipoStatusUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoListar", parm))
            {
                if (reader.Read())
                {
                    tipoStatusUsuario.IdTipoStatusUsuario = Convert.ToInt32(reader["IdTipoStatusUsuario"]);
                    tipoStatusUsuario.Nome = reader["Nome"].ToString();
                    tipoStatusUsuario.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoStatusUsuario.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoStatusUsuario.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoStatusUsuario;
        }

        public List<TipoStatusUsuario> Listar()
        {
            var lstTipoStatusUsuario = new List<TipoStatusUsuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdTipoStatusUsuario",
                Value = DBNull.Value
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoStatusUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    var tipoStatusUsuario = new TipoStatusUsuario();
                    tipoStatusUsuario.IdTipoStatusUsuario = Convert.ToInt32(reader["IdTipoStatusUsuario"]);
                    tipoStatusUsuario.Nome = reader["Nome"].ToString();
                    tipoStatusUsuario.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoStatusUsuario.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoStatusUsuario.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                    lstTipoStatusUsuario.Add(tipoStatusUsuario);
                }
            }

            return lstTipoStatusUsuario;
        }

        #endregion
    }
}
