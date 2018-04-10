using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoSaidaDAO: BaseCRUD<TipoSaida>
    {

        #region BaseCRUD<TipoSaida> Members

        public void Novo(TipoSaida entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoSaida entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoSaida entidade)
        {
            throw new NotImplementedException();
        }

        public TipoSaida Listar(TipoSaida entidade)
        {
            var tipoSaida = new TipoSaida();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSaidaListar"))
            {
                if (reader.Read())
                {
                    tipoSaida.IDTipoSaida = Convert.ToInt32(reader["IDTipoSaida"]);
                    tipoSaida.Nome = reader["Nome"].ToString();
                    tipoSaida.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoSaida.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoSaida.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoSaida;
        }

        public List<TipoSaida> Listar()
        {
            throw new NotImplementedException();
        }

        public List<TipoSaida> ListarTodos()
        {
            List<TipoSaida> tipoSaida = new List<TipoSaida>();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSaidaListar"))
            {
                while (reader.Read())
                {
                    tipoSaida.Add(new TipoSaida()
                    {
                        IDTipoSaida = Convert.ToInt32(reader["IDTipoSaida"]),
                        Nome = reader["Nome"].ToString()
                    });
                    
                }
            }

            return tipoSaida;
        }
        #endregion
    }
}
