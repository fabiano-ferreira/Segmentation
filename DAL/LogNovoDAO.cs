using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class LogNovoDAO:BaseCRUD<LogNovo>
    {

        #region BaseCRUD<LogNovo> Members

        public void Novo(LogNovo entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@CodigoErroTecnico",
                    Value = entidade.CodigoErroTecnico
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MensagemErro",
                    Value = entidade.MensagemErroTecnico
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Modulo",
                    Value = entidade.Modulo
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
                    DbType = DbType.String,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdLog",
                    Value = entidade.IDLog
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@NomeUsuario",
                    Value = entidade.Usuario.Nome
                }

            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LogNovo", parms);
        }

        public void Remover(LogNovo entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(LogNovo entidade)
        {
            throw new NotImplementedException();
        }

        public LogNovo Listar(LogNovo entidade)
        {
            throw new NotImplementedException();
        }

        public List<LogNovo> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
