using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoCriterioVariavelDAO: BaseCRUD<TipoCriterioVariavel>
    {

        #region BaseCRUD<TipoCriterioVariavel> Members

        public void Novo(TipoCriterioVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoCriterioVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoCriterioVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public TipoCriterioVariavel Listar(TipoCriterioVariavel entidade)
        {
            var tipoCriterioVariavel = new TipoCriterioVariavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoCriterioVariavel",
                Value = entidade.IDTipoCriterioVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoCriterioVariavelListar", parm))
            {
                if (reader.Read())
                {
                    tipoCriterioVariavel.IDTipoCriterioVariavel = Convert.ToInt32(reader["IDTipoCriterioVariavel"]);
                    tipoCriterioVariavel.Descricao = reader["Descricao"].ToString();
                    tipoCriterioVariavel.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoCriterioVariavel.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoCriterioVariavel.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoCriterioVariavel;
        }

        public List<TipoCriterioVariavel> Listar()
        {
            var tipoCriterioVariavel = new List<TipoCriterioVariavel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoCriterioVariavel",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoCriterioVariavelListar", parm))
            {
                while (reader.Read())
                {
                    tipoCriterioVariavel.Add(new TipoCriterioVariavel()
                    {
                        IDTipoCriterioVariavel = Convert.ToInt32(reader["IdTipoCriterioVariavel"]),
                        Descricao = reader["Descricao"].ToString()
                    });
                }
            }

            return tipoCriterioVariavel;
        }

        #endregion
    }
}
