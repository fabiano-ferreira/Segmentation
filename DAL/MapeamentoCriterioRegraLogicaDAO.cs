using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class MapeamentoCriterioRegraLogicaDAO: BaseCRUD<MapeamentoCriterioRegraLogica>
    {
        #region BaseCRUD<MapeamentoCriterioRegraLogica> Members

        public void Novo(MapeamentoCriterioRegraLogica entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdMapeamentoCriterioRegraLogica",
                    Value = entidade.IdMapeamentoCriterioRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterioOriginal",
                    Value = entidade.IdCriterioOriginal
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterioTrasnformado",
                    Value = entidade.IdCriterioTrasnformado
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "MapeamentoCriterioRegraLogicaNovo", parms);
            
        }

        public void Remover(MapeamentoCriterioRegraLogica entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
            new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdMapeamentoCriterioRegraLogica",
                    Value = entidade.IdMapeamentoCriterioRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "MapeamentoCriterioRegraLogicaRemover", parms);
        }

        public void Editar(MapeamentoCriterioRegraLogica entidade)
        {
            throw new NotImplementedException();
        }

        public MapeamentoCriterioRegraLogica Listar(MapeamentoCriterioRegraLogica entidade)
        {
            var mapeamentoCriterioRegraLogica = new MapeamentoCriterioRegraLogica();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterioOriginal",
                    Value = entidade.IdCriterioOriginal
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "MapeamentoCriterioRegraLogicaListar", parms))
            {
                if (reader.Read())
                {
                    mapeamentoCriterioRegraLogica.IdCriterioTrasnformado = Convert.ToInt32(reader["IdCriterioTrasnformado"]);
                }
            }
            return mapeamentoCriterioRegraLogica;
        }

        public List<MapeamentoCriterioRegraLogica> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
