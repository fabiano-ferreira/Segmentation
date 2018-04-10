using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class CriterioDAO:BaseCRUD<Criterio>
    {
        #region BaseCRUD<CriterioAderencia> Members

        public void Novo(Criterio entidade)
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioNovo", parms);
        }

        public void Remover(Criterio entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCriterio",
                Value = entidade.IDCriterio
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioRemover", parm);
        }

        public void Editar(Criterio entidade)
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
                },
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioEditar", parms);
        }

        public Criterio Listar(Criterio entidade)
        {
            var criterio = new Criterio();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioListar", parm))
            {
                if (reader.Read())
                {
                    criterio.IDCriterio = Convert.ToInt32(reader["IdCriterio"]);
                    criterio.Nome = reader["Nome"].ToString();
                    criterio.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    criterio.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    criterio.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                    criterio.IDIdCriterioAderencia = Convert.ToInt32(reader["IdCriterioAderencia"]);
                }
            }

            return criterio;
        }

        public List<Criterio> Listar()
        {
            var criterio = new List<Criterio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCriterio",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return criterio;
        }

        public List<Criterio> ListarRelacaoLinhaNegocio(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        IDIdCriterioAderencia = Convert.ToInt32(reader["IdCriterioAderencia"])
                    });
                }
            }

            return criterio;
        }

        public void NovoAderencia(Criterio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Valor",
                    Value = entidade.Valor
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdCriterioAderencia"
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioAderenciaNovo", parms);
        }

        public void RemoverAderencia(Criterio entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCriterioAderencia",
                Value = entidade.CriterioAderencia.IDCriterioAderencia
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioAderenciaRemover", parm);
        }

        public List<Criterio> ListarAderencia(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterioAderencia",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioAderenciaListar", parms))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        Nome = reader["Nome"].ToString() + " / " + reader["Valor"].ToString()
                    });
                }
            }

            return criterio;
        }

        public void EditarFator(Criterio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Valor",
                    Value = entidade.Valor
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioFatorEditar", parms);
        }

        public void NovoFator(Criterio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Valor",
                    Value = entidade.Valor
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioFatorNovo", parms);
        }

        public void RemoverFator(Criterio entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdFator",
                    Value = entidade.Fator.IDFator
                }                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioFatorRemover", parm);
        }

        public void EditarVariavel(Criterio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
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
                    ParameterName="@Valor1",
                    Value = entidade.CriterioVariavel.Valor1
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Valor2",
                    Value = entidade.CriterioVariavel.Valor2
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoCriterioVariavel",
                    Value = entidade.TipoCriterioVariavel.IDTipoCriterioVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelEditar", parms);
        }

        public void NovoVariavel(Criterio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterio",
                    Value = entidade.IDCriterio
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
                    ParameterName="@Valor1",
                    Value = entidade.Valor
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Valor2",
                    Value = entidade.Valor2
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoCriterioVariavel",
                    Value = entidade.TipoCriterioVariavel.IDTipoCriterioVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelNovo", parms);
        }

        public void RemoverVariavel(Criterio entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelRemover", parm);
        }

        public Criterio ListarVariavel(Criterio entidade)
        {
            var variavel = new Criterio();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Double,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Valor1",
                    Value = entidade.CriterioVariavel.Valor1
                },
                new SqlParameter()
                {
                    DbType = DbType.Double,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Valor2",
                    Value = entidade.CriterioVariavel.Valor1
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoCriterioVariavel",
                    Value = entidade.TipoCriterioVariavel.IDTipoCriterioVariavel
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelListar", parms))
            {
                if (reader.Read())
                {
                    variavel.IDCriterio = Convert.ToInt32(reader["IdCriterio"]);
                    variavel.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IdVariavel"]) };
                    variavel.CriterioVariavel = new CriterioVariavel() {
                        Valor1 = Convert.ToInt32(reader["Valor1"]),
                        Valor2 = Convert.ToInt32(reader["Valor2"])
                    };
                }
            }

            return variavel;
        }

        public List<Criterio> ListarVariavelLista(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Double,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Valor1",
                    Value = entidade.CriterioVariavel.Valor1
                },
                new SqlParameter()
                {
                    DbType = DbType.Double,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Valor2",
                    Value = entidade.CriterioVariavel.Valor1
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoCriterioVariavel",
                    Value = entidade.TipoCriterioVariavel.IDTipoCriterioVariavel
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelListar", parms))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString(),
                        Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IdVariavel"]) },
                        CriterioVariavel = new CriterioVariavel()
                        {
                            Valor1 = Convert.ToInt32(reader["Valor1"]),
                            Valor2 = Convert.ToInt32(reader["Valor2"])
                        },
                        TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = Convert.ToInt32(reader["IDTipoCriterioVariavel"]) }
                    });
                }
            }

            return criterio;
        }

        public Criterio ListarFator(Criterio entidade)
        {
            var listarFator = new Criterio();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = entidade.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioFatorListar", parms))
            {
                if (reader.Read())
                {
                    listarFator.IDCriterio = Convert.ToInt32(reader["IdCriterio"]);
                    listarFator.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IdFator"]) };
                    listarFator.CriterioFatorLista = new List<CriterioFator>();

                    while (reader.Read())
                    {
                        var criterioLista = new CriterioFator();

                        criterioLista.Valor = Convert.ToInt32(reader["Valor"]);

                        listarFator.CriterioFatorLista.Add(criterioLista);
                    }

                }
            }

            return listarFator;
        }

        public Criterio ListarVariavelImportacao(Criterio entidade)
        {
            var listarFator = new Criterio();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Nome",
                    Value = entidade.Nome
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioVariavelImportacaoListar", parms))
            {
                if (reader.Read())
                {
                    listarFator.IDCriterio = Convert.ToInt32(reader["IDCriterio"]);

                }
            }

            return listarFator;
        }

        public List<Criterio> ListarRelacaoFator(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.Fator.IDFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioRelacaoFatorListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = string.Concat(reader["Nome"].ToString(), " / ", Convert.ToInt32(reader["Valor"])),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return criterio;
        }

        public List<Criterio> ListarSemRelacaoFator(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.Fator.IDFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioSemRelacaoFatorListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return criterio;
        }

        public List<Criterio> RelacaoVariavelListar(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioRelacaoVariavelListar", parm))
            {
                while (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader["Descricao"].ToString()))
                    {
                        criterio.Add(new Criterio()
                        {
                            IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                            Nome = reader["Nome"].ToString() + " - " + reader["Descricao"].ToString() + " / " +
                            reader["Valor1"].ToString() + " / " + reader["Valor2"].ToString()
                        });
                    }
                    else
                    {
                        criterio.Add(new Criterio()
                        {
                            IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                            Nome = reader["Nome"].ToString()
                        });
                    }
                }
            }

            return criterio;
        }

        public List<Criterio> RelacaoSemVariavelListar(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioSemRelacaoVariavelListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return criterio;
        }

        public Criterio ListarAderenciaValor(Criterio entidade)
        {
            var criterio = new Criterio();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Valor",
                    Value = entidade.Valor
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioAderenciaValorListar", parms))
            {
                while (reader.Read())
                {
                    criterio.IDIdCriterioAderencia = Convert.ToInt32(reader["IdCriterioAderencia"]);
                    criterio.Nome = reader["Nome"].ToString();
                }
            }

            return criterio;
        }

        public List<Criterio> ListarLinhaNegocio(Criterio entidade)
        {
            var criterio = new List<Criterio>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCriterio",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Criterio()
                    {
                        IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return criterio;
        }
        #endregion

    }
}
