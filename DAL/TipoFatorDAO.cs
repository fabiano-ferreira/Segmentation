using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoFatorDAO: BaseCRUD<TipoFator>
    {
        #region BaseCRUD<TipoFator> Members

        public void Novo(TipoFator entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoFator entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoFator entidade)
        {
            throw new NotImplementedException();
        }

        public TipoFator Listar(TipoFator entidade)
        {
            var tipoFator = new TipoFator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoFator",
                Value = entidade.IDTipoFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoFatorListar", parm))
            {
                if (reader.Read())
                {
                    tipoFator.IDTipoFator = Convert.ToInt32(reader["IDTipoFator"]);
                    tipoFator.Nome = reader["Nome"].ToString();
                    tipoFator.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoFator.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoFator.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoFator;
        
        }

        public List<TipoFator> Listar()
        {
            var tipoFatorLista = new List<TipoFator>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdTipoFator",
                Value = DBNull.Value
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoFatorListar", parm))
            {
                while (reader.Read())
                {
                    tipoFatorLista.Add(new TipoFator()
                    {
                        IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]),
                        Nome = reader["Nome"].ToString(),
                    });
                }
                return tipoFatorLista;
            }
        }

        #endregion
    }
}
