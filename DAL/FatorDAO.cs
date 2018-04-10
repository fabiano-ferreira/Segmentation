using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class FatorDAO:BaseCRUD<Fator>
    {

        #region BaseCRUD<Fator> Members

        public void Novo(Fator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Codigo",
                    Value = entidade.Codigo
                },
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
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Peso",
                    Value = entidade.Peso
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Comentario",
                    Value = entidade.Comentario
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
                    ParameterName="@IdFator"
                }
            };

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();

            try
            {
                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "FatorNovo", parms);
                entidade.IDFator = Convert.ToInt32(parms[8].Value);
                SqlParameter[] parmsMo = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IdFator",
                        Value = entidade.IDFator
                    },
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IDModelo",
                        Value = entidade.Modelo.IDModelo
                    }
                };
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ModeloFatorNovo", parmsMo);

                trans.Commit();
            }
            catch(Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void Remover(Fator entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.IDFator,
            };
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();

            try
            {
                SqlParameter[] parmsMo = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IdFator",
                        Value = entidade.IDFator
                    },
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IDModelo",
                        Value = entidade.Modelo.IDModelo
                    }
                };
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ModeloFatorRemover", parmsMo);

                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "RelacaoFatorRemover", parm);

                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "FatorRemover", parm);

                trans.Commit();
            }
            catch (SqlException e)
            {
                trans.Rollback();
                throw;
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void Editar(Fator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Codigo",
                    Value = entidade.Codigo
                },
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
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Peso",
                    Value = entidade.Peso
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Comentario",
                    Value = entidade.Comentario
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
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorEditar", parms);
        }

        public Fator Listar(Fator entidade)
        {
            var fator = new Fator();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorListar", parms))
            {
                if (reader.Read())
                {
                    fator.IDFator = Convert.ToInt32(reader["IdFator"]);
                    fator.Codigo = reader["Codigo"].ToString();
                    fator.Nome = reader["Nome"].ToString();
                    fator.Descricao = reader["Descricao"].ToString();
                    fator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) };
                    fator.Peso = Convert.ToInt32(reader["Peso"]);
                    fator.Comentario = reader["Comentario"].ToString();
                    fator.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    fator.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    fator.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                    fator.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) };
                }
            }

            return fator;
        }

        public List<Fator> Listar()
        {
            var fator = new List<Fator>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorListar", parm))
            {
                while (reader.Read())
                {
                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        Codigo = reader["Codigo"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        TipoFator = new TipoFator { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) },
                        Peso = Convert.ToInt32(reader["Peso"]),
                        Comentario = reader["Comentario"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) },
                        Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) }
                    });
                }
            }

            return fator;
        }

        public Fator ListarCriterio(Fator entidade)
        {
            var criterio = new Fator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.IDFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorCriterioListar", parm))
            {
                if (reader.Read())
                {
                    criterio.IDFator = Convert.ToInt32(reader["IdFator"]);
                    criterio.CriterioFator = new List<CriterioFator>();

                    while (reader.Read())
                    {
                        var criterioFatorLista = new CriterioFator();

                        criterioFatorLista.Criterio = new Criterio() 
                        { 
                            IDCriterio = Convert.ToInt32(reader["IdCriterio"]),
                            Nome = reader["Nome"].ToString()
                        };
                        criterioFatorLista.Valor = Convert.ToInt32(reader["Valor"]);

                        criterio.CriterioFator.Add(criterioFatorLista);
                    }
                }
            }

            return criterio;
        }

        public List<Fator> ListarCriterio()
        {
            var criterio = new List<Fator>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorCriterioListar", parm))
            {
                while (reader.Read())
                {
                    criterio.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) },
                        Nome = reader["Nome"].ToString(),
                        Valor = Convert.ToInt32(reader["DataCriacao"])
                    });
                }
            }

            return criterio;
        }

        public Fator ListarCriterioNivelSuperior(Fator entidade)
        {
            var criterio = new Fator();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdFator",
                    Value = entidade.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdFatorNivelSuperior",
                    Value = entidade.IDFatorNivelSuperior
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorNivelSuperiorListar", parm))
            {
                if (reader.Read())
                {
                    criterio.IDFatorNivelSuperior = Convert.ToInt32(reader["IdFatorNivelSuperior"]);
                }
            }

            return criterio;
        }

        public Fator ListarSub(Fator entidade)
        {
            var fator = new Fator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.IDFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorSubListar", parm))
            {
                if (reader.Read())
                {
                    fator.IDFator = Convert.ToInt32(reader["IdFator"]);
                    fator.IDFilho = Convert.ToInt32(reader["IdFilho"]);
                }
            }

            return fator;
        }

        public List<Fator> ListarSub()
        {
            var fator = new List<Fator>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorSubListar", parm))
            {
                while (reader.Read())
                {
                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        IDFilho = Convert.ToInt32(reader["IdFilho"])
                    });

                }
            }

            return fator;
        }

        public void NovoProdutoNivel(Fator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.ProdutoNivel.IDProdutoNivel
                }
            };
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorProdutoNivelNovo", parms);
                
        }

        public void NovoProduto(Fator entidade)
        {

            {
                SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.Produto.IdProduto
                }
            };
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorProdutoNovo", parms);

            }
        }

        public void RemoverProdutoNivel(Fator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Codigo",
                    Value = entidade.ProdutoNivel.IDProdutoNivel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorProdutoNivelRemover", parms);
        }

        public void RemoverProduto(Fator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Codigo",
                    Value = entidade.Produto.IdProduto
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorProdutoRemover", parms);
        }

        public Fator ListarProdutoNivel(Fator entidade)
        {
            var fator = new Fator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProdutoNivel",
                Value = entidade.ProdutoNivel.IDProdutoNivel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorListar", parm))
            {
                if (reader.Read())
                {
                    fator.IDFator = Convert.ToInt32(reader["IdFator"]);
                    fator.FatorProdutoNivel = new List<FatorProdutoNivel>();
                    while (reader.Read())
                    {
                        var fatorProdutoNivelLista = new FatorProdutoNivel();

                        fatorProdutoNivelLista.ProdutoNivel.IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]);
                        fator.FatorProdutoNivel.Add(fatorProdutoNivelLista);
                    }
                }
            }

            return fator;
        }

        public Fator ListarProduto(Fator entidade)
        {
            var fator = new Fator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProduto",
                Value = entidade.Produto.IdProduto
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorListar", parm))
            {
                if (reader.Read())
                {
                    fator.IDFator = Convert.ToInt32(reader["IdFator"]);
                    fator.FatorProduto = new List<FatorProduto>();
                    while (reader.Read())
                    {
                        var fatorProdutoLista = new FatorProduto();

                        fatorProdutoLista.Produto.IdProduto = Convert.ToInt32(reader["IdProdutoNivel"]);
                        fator.FatorProduto.Add(fatorProdutoLista);
                    }
                }
            }

            return fator;
        }

        public Fator ListarSegmento(Fator entidade)
        {
            var listarSegmento = new Fator();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdSegmento",
                Value = entidade.Segmento.IDSegmento
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorSegmentoListar", parm))
            {
                if (reader.Read())
                {
                    listarSegmento.FatorFilho = new List<Fator>();
                    while (reader.Read())
                    {
                        var fatorProdutoLista = new Fator();

                        fatorProdutoLista.IDFator = Convert.ToInt32(reader["IdFator"]);
                        fatorProdutoLista.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) };
                        fatorProdutoLista.Codigo = reader["Codigo"].ToString();
                        fatorProdutoLista.Nome = reader["Nome"].ToString();
                        fatorProdutoLista.Descricao = reader["Descricao"].ToString();
                        fatorProdutoLista.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) };
                        fatorProdutoLista.Peso = Convert.ToInt32(reader["Peso"]);
                        fatorProdutoLista.Comentario = reader["Comentario"].ToString();
                        fatorProdutoLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };

                        listarSegmento.FatorFilho.Add(fatorProdutoLista);
                    }
                }
            }

            return listarSegmento;
        }

        public Fator ListarPosicionamentoSemProduto(Fator entidade)
        {
            var fator = new Fator();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorPosicionamentoSemProdutoListar", parms))
            {
                if (reader.Read())
                {
                    fator.FatorFilho = new List<Fator>();
                    while (reader.Read())
                    {
                        var fatorProdutoLista = new Fator();

                        fatorProdutoLista.IDFator = Convert.ToInt32(reader["IdFator"]);
                        fatorProdutoLista.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) };
                        fatorProdutoLista.Codigo = reader["Codigo"].ToString();
                        fatorProdutoLista.Nome = reader["Nome"].ToString();
                        fatorProdutoLista.Descricao = reader["Descricao"].ToString();
                        fatorProdutoLista.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) };
                        fatorProdutoLista.Peso = Convert.ToInt32(reader["Peso"]);
                        fatorProdutoLista.Comentario = reader["Comentario"].ToString();
                        fatorProdutoLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };

                        fator.FatorFilho.Add(fatorProdutoLista);
                    }
                }
            }

            return fator;
        }

        public List<Fator> ListarModeloFator(Fator entidade)
        {
            var fator = new List<Fator>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorListar", parms))
            {
                while (reader.Read())
                {

                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        Codigo = reader["Codigo"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        TipoFator = new TipoFator { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) },
                        Peso = Convert.ToInt32(reader["Peso"]),
                        Comentario = reader["Comentario"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) },
                        IdPai = (reader["IdPai"] is DBNull) ? 0 : Convert.ToInt32(reader["IdPai"]),
                        Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) }
                    });
                }
            }

            return fator;
        }

        public List<Fator> ListarFiltroFator(Fator entidade)
        {
            var fator = new List<Fator>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IDFator
                },
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
                    ParameterName="@Codigo",
                    Value = entidade.Codigo
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorFiltroListar", parms))
            {
                while (reader.Read())
                {
                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        Codigo = reader["Codigo"].ToString(),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return fator;
        }

        public void RemoverRelacao(Fator entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.IDFator
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoFatorRemover", parm);
        }

        public void NovaRelacao(Fator entidade)
        {

            {
                SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.IdPai
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFilho",
                    Value = entidade.IDFator
                }
            };
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoFatorNovo", parms);

            }
        }

        public List<Fator> ListarRelacao(Fator entidade)
        {
            var fator = new List<Fator>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdFator",
                Value = entidade.IDFator
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoFatorListar", parm))
            {
                while (reader.Read())
                {
                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        IDFilho = Convert.ToInt32(reader["IdFilho"]),
                    });
                }
            }

            return fator;
        }

        public List<Fator> ListarFatorModeloFator(Fator entidade)
        {
            var fator = new List<Fator>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoFator",
                    Value = entidade.TipoFator.IDTipoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "FatorModeloFatorListar", parms))
            {
                while (reader.Read())
                {
                    fator.Add(new Fator()
                    {
                        IDFator = Convert.ToInt32(reader["IdFator"]),
                        Descricao = reader["Descricao"].ToString(),
                    });
                }
            }

            return fator;
        }

        #endregion

    }
}
