using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class CalculoVariavelDAO : BaseCRUD<CalculoVariavel>
    {
        #region BaseCRUD<CalculoVariavel> Members

        public void Novo(CalculoVariavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdCalculoVariavel",
                    Value = entidade.IdCalculoVariavel
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CalculoVariavelNovo", parms);
            entidade.IdCalculoVariavel = Convert.ToInt32(parms[2].Value);
        }

        public void Remover(CalculoVariavel entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCalculoVariavel",
                Value = entidade.IdCalculoVariavel
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CalculoVariavelRemover", parm);
        }

        public void Editar(CalculoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public CalculoVariavel Listar(CalculoVariavel entidade)
        {
            var calculoVariavel = new CalculoVariavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCalculoVariavel",
                Value = entidade.IdCalculoVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CalculoVariavelListar", parm))
            {
                if (reader.Read())
                {
                    calculoVariavel.IdCalculoVariavel = Convert.ToInt32(reader["IDVariavel"]);

                    calculoVariavel.Variavel = new Variavel()
                    {
                        IDVariavel = Convert.ToInt32(reader["IdVariavel"])
                    };

                    calculoVariavel.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    calculoVariavel.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    calculoVariavel.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return calculoVariavel;
        }

        public List<CalculoVariavel> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
