using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class RegraLogicaDAO: BaseCRUD<RegraLogica>
    {
        #region BaseCRUD<RegraLogica> Members

        public void Novo(RegraLogica entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaNova", parms);
        }

        public void Remover(RegraLogica entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdRegraLogica",
                Value = entidade.IdRegraLogica
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaRemover", parm);
        }

        public void Editar(RegraLogica entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaEditar", parms);
        }

        public RegraLogica Listar(RegraLogica entidade)
        {
            var regraLogica = new RegraLogica();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRegraLogica",
                    Value = entidade.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaListar", parm))
            {
                regraLogica.RegraLogicaLista = new List<RegraLogica>();
                while (reader.Read())
                {
                    var regraLogicaLista = new RegraLogica();

                    regraLogicaLista.IdRegraLogica = Convert.ToInt32(reader["IdRegraLogica"]);
                    regraLogicaLista.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) };
                    regraLogicaLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"]) };
                    regraLogicaLista.Usuario = new Usuario() 
                    {
                        IDUsuario = Convert.ToInt32(reader["IdUsuario"])
                    };

                    regraLogica.RegraLogicaLista.Add(regraLogicaLista);
                }
            }

            return regraLogica;
        }

        public List<RegraLogica> Listar()
        {
            var RegraLogica = new List<RegraLogica>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdRegraLogica",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaListar", parm))
            {
                while (reader.Read())
                {
                    RegraLogica.Add(new RegraLogica()
                    {
                        IdRegraLogica = Convert.ToInt32(reader["IdRegraLogica"]),
                        Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) },
                        Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"].ToString()) },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return RegraLogica;
        }

        public List<RegraLogica> ListarPorVariavel(RegraLogica entidade)
        {
            var RegraLogica = new List<RegraLogica>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRegraLogica",
                    Value = entidade.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaListar", parm))
            {
                while (reader.Read())
                {
                    RegraLogica.Add(new RegraLogica()
                    {
                        IdRegraLogica = Convert.ToInt32(reader["IdRegraLogica"]),
                        Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) },
                        Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"].ToString()) },
                        VariavelHerdado = new Variavel() { IDVariavel = Convert.ToInt32(reader["IdVariavelValorHerdado"]) },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return RegraLogica;
        }

        public RegraLogica ListarVariavel(RegraLogica entidade)
        {
            var regraLogica = new RegraLogica();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdRegraLogica",
                Value = entidade.IdRegraLogica
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaVariavelListar", parm))
            {
                if (reader.Read())
                {
                    regraLogica.IdRegraLogica = Convert.ToInt32(reader["IdRegraLogica"]);
                    regraLogica.VariavelRegraLogica = new List<VariavelRegraLogica>();

                    while (reader.Read())
                    {
                        var variavelRegraLogicaLista = new VariavelRegraLogica();

                        variavelRegraLogicaLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                        variavelRegraLogicaLista.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IdVariavel"]) };

                        regraLogica.VariavelRegraLogica.Add(variavelRegraLogicaLista);
                    }
                }
            }

            return regraLogica;
        }

        public List<VariavelRegraLogica> ListarVariavelLista(RegraLogica entidade)
        {
            var RegraLogica = new List<VariavelRegraLogica>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRegraLogica",
                    Value = entidade.IdRegraLogica
                }                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaVariavelListar", parm))
            {
                while (reader.Read())
                {
                    RegraLogica.Add(new VariavelRegraLogica()
                    {
                        RegraLogica = new RegraLogica() { IdRegraLogica = Convert.ToInt32(reader["IdRegraLogica"]) },
                        Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) },
                        Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"].ToString()) },
                        Valor = reader["Valor"].ToString(),
                        TipoComparacaoRegraLogica = new TipoComparacaoRegraLogica() { IDTipoComparacaoRegraLogica = Convert.ToInt32(reader["IDTipoComparacaoRegraLogica"]) }
                    });
                }
            }

            return RegraLogica;
        }

        public RegraLogica ValidarVariavel(Variavel entidade)
        {
            RegraLogica regraLogica = new RegraLogica();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDCriterio",
                    Value = entidade.Criterio.IDCriterio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RegraLogicaValidar", parm))
            {
                if (reader.Read())
                {
                    regraLogica.Valido = true;
                }
            }

            return regraLogica;
        }



        #endregion
    }
}
