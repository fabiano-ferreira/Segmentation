using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoDadoVariavelDAO: BaseCRUD<TipoDadoVariavel>
    {
        #region BaseCRUD<TipoDadoVariavel> Members

        public void Novo(TipoDadoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoDadoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoDadoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public TipoDadoVariavel Listar(TipoDadoVariavel entidade)
        {
            var TipoDadoVariavel = new TipoDadoVariavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoDadoVariavel",
                Value = entidade.IDTipoDadoVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoDadoVariavelListar", parm))
            {
                if (reader.Read())
                {
                    TipoDadoVariavel.IDTipoDadoVariavel = Convert.ToInt32(reader["IDTipoDadoVariavel"]);
                    TipoDadoVariavel.Nome = reader["Nome"].ToString();
                    TipoDadoVariavel.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    TipoDadoVariavel.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    TipoDadoVariavel.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return TipoDadoVariavel;
        }

        public List<TipoDadoVariavel> Listar()
        {
            throw new NotImplementedException();
        }

        public List<TipoDadoVariavel> ListarTodos()
        {
            List<TipoDadoVariavel> tipoSaida = new List<TipoDadoVariavel>();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoDadoVariavelListar"))
            {
                while (reader.Read())
                {
                    tipoSaida.Add(new TipoDadoVariavel()
                    {
                        IDTipoDadoVariavel = Convert.ToInt32(reader["IDTipoDadoVariavel"]),
                        Nome = reader["Nome"].ToString()
                    });

                }
            }

            return tipoSaida;
        }

        #endregion
    }
}
