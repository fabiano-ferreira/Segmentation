using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class VersaoProdutoFatorDAO: BaseCRUD<VersaoProdutoFator>
    {
        #region BaseCRUD<VersaoProdutoFator> Members

        public void Novo(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
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
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorNovo", parms);
        }

        public void Remover(VersaoProdutoFator entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdVersaoProdutoFator",
                Value = entidade.IdVersaoProdutoFator
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorRemover", parm);
        }

        public void Editar(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.IdVersaoProdutoFator
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
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorEditar", parms);
        }

        public VersaoProdutoFator Listar(VersaoProdutoFator entidade)
        {
            var versaoProdutoFator = new VersaoProdutoFator();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.IdVersaoProdutoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorListar", parm))
            {
                versaoProdutoFator.VersaoProdutoFatorLista = new List<VersaoProdutoFator>();
                while (reader.Read())
                {
                    var versao = new VersaoProdutoFator();

                    versao.Descricao = reader["Descricao"].ToString();
                    versao.Modelo = new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"])
                    };
                    versao.IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]);

                    versaoProdutoFator.VersaoProdutoFatorLista.Add(versao);
                }
            }

            return versaoProdutoFator;
        }

        public List<VersaoProdutoFator> ListarRelacaoModelo(VersaoProdutoFator entidade)
        {
            var versaoProdutoFator = new List<VersaoProdutoFator>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorListar", parm))
            {
                while (reader.Read())
                {
                    versaoProdutoFator.Add(new VersaoProdutoFator()
                    {
                        IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]),
                        Descricao = reader["Descricao"].ToString()
                    });
                }
            }

            return versaoProdutoFator;
        }

        public VersaoProdutoFator ListarSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            var versaoProdutoFator = new VersaoProdutoFator();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.IdVersaoProdutoFator   
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdSegmento",
                    Value = entidade.Segmento.IDSegmento
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoListar", parm))
            {
                if (reader.Read())
                {
                    versaoProdutoFator.IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]);
                    versaoProdutoFator.VersaoSegmento = new List<VersaoSegmento>();
                    while (reader.Read())
                    {
                        var versaoSegmento = new VersaoSegmento();

                        versaoSegmento.VersaoSegmentoProdutoFatorProduto.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProduto.Fator = new Fator() { IDFator = Convert.ToInt32(reader["IDFator"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProduto.Produto = new Produto() { IdProduto = Convert.ToInt32(reader["IdProduto"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProduto.Segmento = new Segmento() { IDSegmento = Convert.ToInt32(reader["IdSegmento"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProduto.VersaoProdutoFator = new VersaoProdutoFator() { IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]) };

                        versaoProdutoFator.VersaoSegmento.Add(versaoSegmento);
                    }

                }
            }

            return versaoProdutoFator;
        }

        public VersaoProdutoFator ListarSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            var versaoProdutoFator = new VersaoProdutoFator();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.IdVersaoProdutoFator   
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdSegmento",
                    Value = entidade.Segmento.IDSegmento
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoNivelListar", parm))
            {
                if (reader.Read())
                {
                    versaoProdutoFator.IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]);
                    versaoProdutoFator.VersaoSegmento = new List<VersaoSegmento>();
                    while (reader.Read())
                    {
                        var versaoSegmento = new VersaoSegmento();

                        versaoSegmento.VersaoSegmentoProdutoFatorProdutoNivel.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProdutoNivel.Fator = new Fator() { IDFator = Convert.ToInt32(reader["IDFator"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProdutoNivel.ProdutoNivel = new ProdutoNivel() { IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProdutoNivel.Segmento = new Segmento() { IDSegmento = Convert.ToInt32(reader["IdSegmento"]) };
                        versaoSegmento.VersaoSegmentoProdutoFatorProdutoNivel.VersaoProdutoFator = new VersaoProdutoFator() { IdVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]) };

                        versaoProdutoFator.VersaoSegmento.Add(versaoSegmento);
                    }

                }
            }

            return versaoProdutoFator;
        }

        public void NovoSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.ProdutoNivel.IDProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoNivelNovo", parms);
        }

        public void EditarSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.ProdutoNivel.IDProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoNivelEditar", parms);
        }

        public void RemoverSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.ProdutoNivel.IDProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProdutoNivel.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoNivelRemover", parms);
        }

        public void NovoSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoNovo", parms);
        }

        public void EditarSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Criterio.IDCriterio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoEditar", parms);
        }

        public void RemoverSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDFator",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.VersaoSegmentoProdutoFatorProduto.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoSegmentoProdutoFatorProdutoRemover", parms);
        }



        #endregion

        #region BaseCRUD<VersaoProdutoFator> Members


        public List<VersaoProdutoFator> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
