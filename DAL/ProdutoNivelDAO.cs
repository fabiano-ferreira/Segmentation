using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;
using System.Xml.Serialization;
using System.IO;


namespace DAL
{
    public class ProdutoNivelDAO : BaseCRUD<ProdutoNivel>
    {

        #region BaseCRUD<ProdutoNivel> Members

        public void Novo(ProdutoNivel entidade)
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
                    ParameterName="@IdProdutoNivel"
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelNovo", parms);
            entidade.IDProdutoNivel = Convert.ToInt32(parms[2].Value);
        }

        public void Remover(ProdutoNivel entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProdutoNivel",
                Value = entidade.IDProdutoNivel
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelRemover", parm);
        }

        public void Editar(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.IDProdutoNivel
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelEditar", parms);
        }

        public ProdutoNivel Listar(ProdutoNivel entidade)
        {
            var produtoNivel = new ProdutoNivel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProdutoNivel",
                Value = entidade.IDProdutoNivel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListar", parm))
            {
                if (reader.Read())
                {
                    produtoNivel.IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]);
                    produtoNivel.NomePai = reader["ProdutoNivelPai"].ToString();
                    produtoNivel.RelacaoProdutoNivel = new RelacaoProdutoNivel() { IdFilho = Convert.ToInt32(reader["IdFilho"]) };
                    produtoNivel.NomeFilho = reader["ProdutoNivelFilho"].ToString();
                    produtoNivel.RelacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto() { IDProduto = Convert.ToInt32(reader["IdProduto"]) };
                    produtoNivel.Produto = new Produto() { Nome = reader["Produto"].ToString() };
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> Listar()
        {
            var produtoNivel = new List<ProdutoNivel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProdutoNivel",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListar", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        NomePai = reader["ProdutoNivelPai"].ToString(),
                        RelacaoProdutoNivel = new RelacaoProdutoNivel() {IdFilho = Convert.ToInt32(reader["IdFilho"]) },
                        NomeFilho = reader["ProdutoNivelFilho"].ToString(),
                        RelacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto() {IDProduto = Convert.ToInt32(reader["IdProduto"])},
                        Produto = new Produto() { Nome = reader["Produto"].ToString() }
                    });
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> ListarNivel()
        {
            var produtoNivel = new List<ProdutoNivel>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@nome",
                    Value = null
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListarTodos", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> ListarNivel(string nome)
        {
            var produtoNivel = new List<ProdutoNivel>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@nome",
                    Value = nome
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListarTodos", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> ListarPais()
        {
            var produtoNivel = new List<ProdutoNivel>();

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListarPais"))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> ListarFilhos(int idPai)
        {
            var produtoNivel = new List<ProdutoNivel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@idprodutonivel",
                Value = idPai
            };

            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListarFilhos", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return produtoNivel;
        }

        public ProdutoNivel ListarNivel(int id)
        {
            var produtoNivel = new ProdutoNivel();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = id
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@nome",
                    Value = null
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelListarTodos", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Nome = reader["nome"].ToString();
                    produtoNivel.IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]);
                }
            }

            return produtoNivel;
        }

        public List<ProdutoNivel> ListarRelacaoLinhaNegocio(ProdutoNivel entidade)
        {
            var produtoNivel = new List<ProdutoNivel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.LinhaNegocio.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelRelacaoLinhaNegocioListar", parm))
            {
                while (reader.Read())
                {
                    produtoNivel.Add(new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                        NomePai = reader["Nome"].ToString(),
                    });
                }
            }

            return produtoNivel;
        }

        public void NovoRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdRelacaoProdutoNivel",
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.IDProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFilho",
                    Value = entidade.IDFilho
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelNovo", parms);
            entidade.RelacaoProdutoNivel = new RelacaoProdutoNivel();
            entidade.RelacaoProdutoNivel.IdRelacaoProdutoNivel = Convert.ToInt32(parms[0].Value);
        }

        public void RemoverRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRelacaoProdutoNivel",
                    Value = entidade.RelacaoProdutoNivel.IdRelacaoProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = entidade.IDProdutoNivel
                },
                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelRemover", parms);
        }

        public void NovoRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRelacaoNivelProduto",
                    Value = entidade.RelacaoProdutoNivelProduto.IDProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.Produto.IdProduto
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelProdutoNovo", parms);
        }

        public void RemoverRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdRelacaoNivelProduto",
                    Value = entidade.RelacaoProdutoNivelProduto.IDProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProduto",
                    Value = entidade.IDProdutoNivel
                },
                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelProdutoRemover", parms);
        }

        public ProdutoNivel ListarRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            var produtoNivel = new ProdutoNivel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProdutoNivel",
                Value = entidade.IDProdutoNivel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelListar", parm))
            {
                produtoNivel.RelacaoProdutoNivelLista = new List<RelacaoProdutoNivel>();
                while (reader.Read())
                {
                    var relacaoProdutoNivel = new RelacaoProdutoNivel();

                    relacaoProdutoNivel.IdFilho = Convert.ToInt32(reader["IdFilho"]);
                    relacaoProdutoNivel.IdRelacaoProdutoNivel = Convert.ToInt32(reader["IdRelacaoProdutoNivel"]);
                    relacaoProdutoNivel.Nome = reader["Nome"].ToString();

                    produtoNivel.RelacaoProdutoNivelLista.Add(relacaoProdutoNivel);
                }
            }

            return produtoNivel;
        }

        public void NovoCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterioAderencia",
                    Value = entidade.CriterioAderencia.IDCriterioAderencia
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdSegmento",
                    Value = entidade.Segmento.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCriterioAderenciaCalculado",
                    Value = entidade.IDCriterioAderenciaCalculado
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelCriterioAderenciaSegmentoNovo", parms);

        }

        public void RemoverCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdSegmento",
                    Value = entidade.Segmento.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelCriterioAderenciaSegmentoRemover", parms);
        }

        public ProdutoNivel ListarCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            var produto = new ProdutoNivel();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdSegmento",
                    Value = entidade.Segmento.IDSegmento
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNivelCriterioAderenciaSegmentoListar", parms))
            {
                if (reader.Read())
                {
                    produto.IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]);
                    produto.Nome = reader["Nome"].ToString();
                }
            }

            return produto;
        }

        public ProdutoNivel ListarRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            var produto = new ProdutoNivel();

            SqlParameter parm = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdRelacaoNivelProduto",
                Value = entidade.IDProdutoNivel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoProdutoNivelProdutoListar", parm))
            {
                produto.RelacaoProdutoNivelProdutoLista = new List<RelacaoProdutoNivelProduto>();

                while (reader.Read())
                {
                    var relacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto();

                    relacaoProdutoNivelProduto.IDProduto = Convert.ToInt32(reader["IDProduto"]);
                    relacaoProdutoNivelProduto.Nome = reader["Nome"].ToString();

                    produto.RelacaoProdutoNivelProdutoLista.Add(relacaoProdutoNivelProduto);
                }
            }

            return produto;
        }

        #endregion
    }
}
