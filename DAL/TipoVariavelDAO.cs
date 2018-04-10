using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoVariavelDAO: BaseCRUD<TipoVariavel>
    {

        #region BaseCRUD<TipoVariavel> Members

        public void Novo(TipoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public TipoVariavel Listar(TipoVariavel entidade)
        {
            var tipoStatusUsuario = new TipoVariavel();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoVariavelListar"))
            {
                if (reader.Read())
                {
                    tipoStatusUsuario.IDTipoVariavel = Convert.ToInt32(reader["IDTipoVariavel"]);
                    tipoStatusUsuario.Nome = reader["Nome"].ToString();
                    tipoStatusUsuario.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoStatusUsuario.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoStatusUsuario.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }
            return tipoStatusUsuario;
        }

        public List<TipoVariavel> Listar()
        {
            throw new NotImplementedException();
        }

        public List<TipoVariavel> ListarTodos()
        {
            List<TipoVariavel> tipoSaida = new List<TipoVariavel>();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoVariavelListar"))
            {
                while (reader.Read())
                {
                    tipoSaida.Add(new TipoVariavel()
                    {
                        IDTipoVariavel = Convert.ToInt32(reader["IDTipoVariavel"]),
                        Nome = reader["Nome"].ToString()
                    });

                }
            }

            return tipoSaida;
        }

        #endregion
    }
}
