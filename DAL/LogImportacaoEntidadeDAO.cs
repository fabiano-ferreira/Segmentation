using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class LogImportacaoEntidadeDAO: BaseCRUD<LogImportacaoEntidade>
    {
        #region BaseCRUD<LogImportacaoEntidade> Members

        public void Novo(LogImportacaoEntidade entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@CodigoVariavel",
                    Value = entidade.CodigoVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@DocumentoEntidade",
                    Value = entidade.DocumentoEntidade
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Mensagem",
                    Value = entidade.Mensagem
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
                    Direction = ParameterDirection.Input,
                    ParameterName="@NomeUsuario",
                    Value = entidade.NomeUsuario
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LogImportacaoEntidadeNovo", parms);
        }

        public void Remover(LogImportacaoEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(LogImportacaoEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public LogImportacaoEntidade Listar(LogImportacaoEntidade entidade)
        {
            var logImportacaoEntidade = new LogImportacaoEntidade();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLogImportacaoEntidade",
                    Value = entidade.IdLogImportacaoEntidade
                },
                new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Data",
                    Value = entidade.Data
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LogImportacaoEntidadeListar", parms))
            {
                if (reader.Read())
                {
                    logImportacaoEntidade.LogImportacaoEntidadeLista = new List<LogImportacaoEntidade>();

                    while (reader.Read())
                    {

                        logImportacaoEntidade.IdLogImportacaoEntidade = Convert.ToInt32(reader["IdLogImportacaoEntidade"]);
                        logImportacaoEntidade.CodigoVariavel = reader["CodigoVariavel"].ToString();
                        logImportacaoEntidade.DocumentoEntidade = reader["DocumentoEntidade"].ToString();
                        logImportacaoEntidade.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                        logImportacaoEntidade.Mensagem = reader["Mensagem"].ToString();
                        logImportacaoEntidade.Data = Convert.ToDateTime(reader["Data"]);
                        logImportacaoEntidade.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                        logImportacaoEntidade.NomeUsuario = reader["NomeUsuario"].ToString();
                    }
                    logImportacaoEntidade.LogImportacaoEntidadeLista.Add(logImportacaoEntidade);
                }
            }

            return logImportacaoEntidade;
        }

        public List<LogImportacaoEntidade> Listar()
        {
            var logImportacaoEntidade = new List<LogImportacaoEntidade>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLogImportacaoEntidade",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Data",
                    Value = null
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LogImportacaoEntidadeListar", parms))
            {
                while (reader.Read())
                {
                    logImportacaoEntidade.Add(new LogImportacaoEntidade()
                    {
                        IdLogImportacaoEntidade = Convert.ToInt32(reader["IdLogImportacaoEntidade"]),
                        CodigoVariavel = reader["CodigoVariavel"].ToString(),
                        DocumentoEntidade = reader["DocumentoEntidade"].ToString(),
                        Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) },
                        Mensagem = reader["Mensagem"].ToString(),
                        Data = Convert.ToDateTime(reader["Data"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        NomeUsuario = reader["NomeUsuario"].ToString()
                    });
                }
            }

            return logImportacaoEntidade;
        }

        #endregion
    }
}
