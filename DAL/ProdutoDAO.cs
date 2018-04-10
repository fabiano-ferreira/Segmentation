using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class ProdutoDAO:BaseCRUD<Produto>
    {

        #region BaseCRUD<Produto> Members

        public void Novo(Produto entidade)
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
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
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
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoNovo", parms);
        }

        public void Remover(Produto entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProduto",
                Value = entidade.IdProduto
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoRemover", parm);
        }

        public void Editar(Produto entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
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
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoEditar", parms);
        }

        public Produto Listar(Produto entidade)
        {
            var produto = new Produto();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProduto",
                Value = entidade.IdProduto
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoListar", parm))
            {
                if (reader.Read())
                {
                    produto.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                    produto.Nome = reader["Nome"].ToString();
                    produto.Descricao = reader["Descricao"].ToString();
                    produto.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    produto.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    produto.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return produto;
        }

        public List<Produto> Listar()
        {
            var produto = new List<Produto>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProduto",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoListar", parm))
            {
                while (reader.Read())
                {
                    produto.Add(new Produto()
                    {
                        IdProduto = Convert.ToInt32(reader["IdProduto"]),
                        Nome = reader["Nome"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return produto;
        }

        public void NovoCriterioAderenciaSegmento(Produto entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
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
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoCriterioAderenciaSegmentoNovo", parms);
            
        }

        public void RemoverCriterioAderenciaSegmento(Produto entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
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
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoCriterioAderenciaSegmentoRemover", parms);
        }

        public Produto ListarCriterioAderenciaSegmento(Produto entidade)
        {
            var produto = new Produto();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
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
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ProdutoCriterioAderenciaSegmentoListar", parms))
            {
                if (reader.Read())
                {
                    produto.CriterioAderencia = new CriterioAderencia()
                    {
                        IDCriterioAderencia =(reader["IdCriterioAderencia"] is DBNull)? 0 : Convert.ToInt32(reader["IdCriterioAderencia"])
                    };
                }
            }

            return produto;
        }

        public Produto ListarCriterioAderencia(Produto entidade)
        {
            var produto = new Produto();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.IdProduto
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
                    ParameterName="@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CriterioAderenciaSegmentoListar", parms))
            {
                if (reader.Read())
                {
                    produto.valor = Convert.ToInt32(reader["Valor"]);
                }
            }

            return produto;
        }

        #endregion
    }
}
