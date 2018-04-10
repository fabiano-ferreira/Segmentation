using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace DAL
{
    public class EntidadeDAO:BaseCRUD<Entidade>
    {
        #region BaseCRUD<Entidade> Members

        public void Novo(Entidade entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Nome",
                    Value = entidade.Nome
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Documento",
                    Value = entidade.Documento
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
                    ParameterName="@IdEntidade",
                    Value = entidade.IDEntidade
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Regiao",
                    Value = entidade.Regiao
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeNova", parms);
        }

        public void Remover(Entidade entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdEntidade",
                Value = entidade.IDEntidade
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeRemover", parm);
        }

        public void Editar(Entidade entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Nome",
                    Value = entidade.Nome
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Documento",
                    Value = entidade.Documento
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
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdEntidade",
                    Value = entidade.IDEntidade
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeEditar", parms);
        }

        public Entidade Listar(Entidade entidade)
        {
            var entidadeVar = new Entidade();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdEntidade",
                Value = entidade.IDEntidade
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeListar", parm))
            {
                if (reader.Read())
                {
                    entidadeVar.IDEntidade = Convert.ToInt32(reader["IdEntidade"]);
                    entidadeVar.Nome = reader["Nome"].ToString();
                    entidadeVar.Documento = reader["Documento"].ToString();
                    entidadeVar.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    entidadeVar.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    entidadeVar.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                    entidadeVar.Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) };
                    entidadeVar.Regiao = reader["Regiao"].ToString();
                }
            }

            return entidadeVar;
        }

        public List<Entidade> Listar()
        {
            var entidadeBD = new List<Entidade>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdEntidade",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeListar", parm))
            {
                while (reader.Read())
                {
                    entidadeBD.Add(new Entidade()
                    {
                        IDEntidade = Convert.ToInt32(reader["IdEntidade"]),
                        Nome = reader["Nome"].ToString(),
                        Documento = reader["Documento"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) },
                        Regiao = reader["Regiao"].ToString()
                    });
                }
            }

            return entidadeBD;
        }

        public void NovoVariavel(Entidade entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdEntidade",
                    Value = entidade.IDEntidade
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
                    ParameterName="@Valor",
                    Value = entidade.EntidadeVariavelObject.Valor
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.Criterio.IDCriterio
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeVariavelNova", parms);
        }

        public void RemoverVariavel(Entidade entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdEntidade",
                    Value = entidade.IDEntidade
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeVariavelRemover", parms);
        }

        public Entidade ListarVariavel(Entidade entidade)
        {
            var variavel = new Entidade();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdEntidade",
                    Value = entidade.IDEntidade
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeVariavelListar", parms))
            {
                if (reader.Read())
                {
                    variavel.IDEntidade = Convert.ToInt32(reader["IdEntidade"]);
                    variavel.EntidadeVariavel = new List<EntidadeVariavel>();

                    while (reader.Read())
                    {
                        var entidadeVariavelLista = new EntidadeVariavel();

                        entidadeVariavelLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };


                        entidadeVariavelLista.TipoVariavel = new TipoVariavel()
                        {
                            IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                            Nome = reader["Nome"].ToString()
                        };
                        entidadeVariavelLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                        entidadeVariavelLista.Valor = Convert.ToDouble(reader["Valor"]);                        
                        entidadeVariavelLista.ClasseVariavel = new ClasseVariavel()
                        {
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                            Nome = reader["NomeClasseVariavel"].ToString()
                        };
                        entidadeVariavelLista.TipoSaida = new TipoSaida()
                        {
                            IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]),
                            Nome = reader["NomeTipoSaida"].ToString()
                        };
                        entidadeVariavelLista.Variavel = new Variavel()
                        {
                            IDVariavel = Convert.ToInt32(reader["IdVariavel"]),
                            Codigo = reader["Codigo"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Significado = reader["Significado"].ToString(),
                            MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString(),
                            MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString(),
                            PerguntaSistema = reader["PerguntaSistema"].ToString(),
                            InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString(),
                            Comentario = reader["Comentario"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                            TipoDadoVariavel = new TipoDadoVariavel() { IDTipoDadoVariavel = Convert.ToInt32(reader["IdTipoDadoVariavel"]) }
                        };

                        variavel.EntidadeVariavel.Add(entidadeVariavelLista);
                    }
                }
            }

            return variavel;
        }

        public List<Entidade> ListarVariavel()
        {
            var variavel = new List<Entidade>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdEntidade",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "EntidadeVariavelListar", parm))
            {
                while (reader.Read())
                {
                    variavel.Add(new Entidade()
                    {
                        IDEntidade = Convert.ToInt32(reader["IdEntidade"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        TipoVariavel = new TipoVariavel() 
                        { 
                            IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                            Nome = reader["Nome"].ToString() 
                        },
                        ClasseVariavel = new ClasseVariavel() 
                        {  
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                            Nome = reader["NomeClasseVariavel"].ToString() 
                        },
                        TipoSaida = new TipoSaida() 
                        { 
                            IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]),
                            Nome = reader["NomeTipoSaida"].ToString() 
                        },
                        Variavel = new Variavel()
                        {
                            IDVariavel = Convert.ToInt32(reader["IdVariavel"]),
                            Codigo = reader["Codigo"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Significado = reader["Significado"].ToString(),
                            MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString(),
                            MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString(),
                            PerguntaSistema = reader["PerguntaSistema"].ToString(),
                            InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString(),
                            Comentario = reader["Comentario"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        }
                    });
                }
            }

            return variavel;
        }

        #endregion

    }
}
