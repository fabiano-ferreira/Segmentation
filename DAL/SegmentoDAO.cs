using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class SegmentoDAO : BaseCRUD<Segmento>
    {
        #region BaseCRUD<Segmento> Members

        public void Novo(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdSegmento",
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@TamanhoMercado",
                    Value = entidade.TamanhoMercado
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@FatorAtratividade",
                    Value = entidade.FatorAtratividade
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
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoNovo", parms);

            entidade.IDSegmento = Convert.ToInt32(parms[0].Value);
        }

        public void Remover(Segmento entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDSegmento",
                    Value = entidade.IDSegmento
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
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoRemover", parm);
        }

        public void Editar(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@TamanhoMercado",
                    Value = entidade.TamanhoMercado
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Codigo",
                    Value = entidade.Codigo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@FatorAtratividade",
                    Value = entidade.FatorAtratividade
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo
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
                    ParameterName="IdClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoEditar", parms);
        }

        public Segmento Listar(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoListar", parms))
            {
                segmento.SegmentoLista = new List<Segmento>();
                while (reader.Read())
                {
                    var segmentoLista = new Segmento();

                    segmentoLista.IDSegmento = Convert.ToInt32(reader["IdSegmento"]);
                    if(!string.IsNullOrEmpty(reader["TamanhoMercado"].ToString()))
                        segmentoLista.TamanhoMercado = Convert.ToInt32(reader["TamanhoMercado"]);
                    segmentoLista.Codigo = reader["Codigo"].ToString();
                    if (!string.IsNullOrEmpty(reader["FatorAtratividade"].ToString()))
                        segmentoLista.FatorAtratividade = Convert.ToInt32(reader["FatorAtratividade"]);
                    segmentoLista.Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) };
                    segmentoLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                    segmento.SegmentoLista.Add(segmentoLista);
                }
            }

            return segmento;
        }

        public List<Segmento> Listar()
        {
            throw new NotImplementedException();
        }

        public Segmento ListarEntidade(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDSegmento",
                Value = entidade.IDSegmento
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoEntidadeListar", parm))
            {
                if (reader.Read())
                {
                    segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);
                    segmento.EntidadeList = new List<Entidade>();

                    while (reader.Read())
                    {
                        var entidadeLista = new Entidade();

                        entidadeLista.IDEntidade = Convert.ToInt32(reader["@IdEntidade"]);
                        entidadeLista.Nome = reader["@Nome"].ToString();
                        entidadeLista.Documento = reader["@Documento"].ToString();
                        entidadeLista.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        entidadeLista.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);

                        segmento.EntidadeList.Add(entidadeLista);
                    }
                }
            }

            return segmento;
        }

        public List<Segmento> ListarEntidade()
        {
            throw new NotImplementedException();
            //var segmento = new List<Segmento>();

            //SqlParameter parm = new SqlParameter()
            //{
            //    DbType = DbType.Int32,
            //    Direction = ParameterDirection.Input,
            //    ParameterName = "@IDSegmento",
            //    Value = null
            //};
            //using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoEntidadeListar", parm))
            //{
            //    while(reader.Read())
            //    {
            //        segmento.Add(ListarEntidade(new Segmento() { IDSegmento = Convert.ToInt32(reader["IdSegmento"].ToString()) }));
            //        segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);

            //        while (reader.Read())
            //        {
            //            var entidadeLista = new Entidade();

            //            entidadeLista.IDEntidade = Convert.ToInt32(reader["@IdEntidade"]);
            //            entidadeLista.Nome = reader["@Nome"].ToString();
            //            entidadeLista.Documento = reader["@Documento"].ToString();
            //            entidadeLista.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
            //            entidadeLista.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);

            //            segmento.Entidade.Add(ListarEntidade(segmento));
            //        }
            //    }
            //}

            //return segmento;
        }

        public void NovaEntidade(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },      
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdEntidade",
                    Value = entidade.Entidade.IDEntidade
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoEntidadeNovo", parms);
        }

        public void RemoverEntidade(string idSegmento, string idEntidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            { 
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDSegmento",
                    Value = idSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdEntidade",
                    Value = idEntidade
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoEntidadeRemover", parms);
        }

        public Segmento ListarFator(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdFator",
                    Value = entidade.Fator.IDFator
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoFatorListar", parm))
            {
                if (reader.Read())
                {
                    segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);
                    segmento.SegmentoFator = new List<SegmentoFator>();

                    while (reader.Read())
                    {
                        var segmentoFatorLista = new SegmentoFator();

                        segmentoFatorLista.Fator = new Fator()
                        {
                            IDFator = Convert.ToInt32(reader["IdFator"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Peso = Convert.ToInt32(reader["Peso"]),
                            Comentario = reader["Comentario"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                        };

                        segmentoFatorLista.Criterio = new Criterio() 
                        { 
                            IDCriterio = Convert.ToInt32(reader["IDCriterio"])
                        };

                        segmento.SegmentoFator.Add(segmentoFatorLista);
                    }
                }
            }

            return segmento;
        }

        public void NovoFator(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },      
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@idFator",
                    Value = entidade.Fator.IDFator
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = entidade.ProdutoNivel.IDProdutoNivel
                },  
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProduto",
                    Value = entidade.Produto.IdProduto
                },  
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.Criterio.IDCriterio
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoFatorNovo", parms);
        }

        public void RemoverFator(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },      
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@idFator",
                    Value = entidade.Fator.IDFator
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].
                ConnectionString, CommandType.StoredProcedure, "SegmentoFatorRemover", parms);
        }

        public void RemoverRegraLogica(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].
                ConnectionString, CommandType.StoredProcedure, "SegmentoRegraLogicaRemover", parms);
        }

        public Segmento ListarModelo(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },      
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoModeloListar", parms))
            {
                if (reader.Read())
                {
                    segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);
                    segmento.TamanhoMercado = Convert.ToInt32(reader["@TamanhoMercado"]);
                    segmento.Codigo = reader["Codigo"].ToString();
                    segmento.FatorAtratividade = Convert.ToInt32(reader["FatorAtratividade"]);
                    segmento.FatorPosicionamento = Convert.ToInt32(reader["FatorPosicionamento"]);
                    segmento.DistanciaPontoMaximoGrafico = Convert.ToInt32(reader["DistanciaPontoMaximoGrafico"]);
                    segmento.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    segmento.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    segmento.Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) };
                    segmento.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return segmento;
        }

        public Segmento ListarProdutoCriterioAderencia(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDSegmento",
                Value = entidade.IDSegmento
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoProdutoCriterioAderenciaListar", parm))
            {
                if (reader.Read())
                {
                    segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);
                    segmento.CriterioAderencia = new CriterioAderencia() { 
                        IDCriterioAderencia = Convert.ToInt32(reader["IDCriterioAderencia"]) };
                    segmento.Produto = new Produto() { 
                        IdProduto = Convert.ToInt32(reader["IdProduto"]) };
                }
            }

            return segmento;
        }

        public Segmento ListarProdutoNivelCriterioAderencia(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDSegmento",
                Value = entidade.IDSegmento
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoProdutoNivelCriterioAderenciaListar", parm))
            {
                if (reader.Read())
                {
                    segmento.IDSegmento = Convert.ToInt32(reader["@IDSegmento"]);
                    segmento.CriterioAderencia = new CriterioAderencia()
                    {
                        IDCriterioAderencia = Convert.ToInt32(reader["IDCriterioAderencia"])
                    };
                    segmento.ProdutoNivel = new ProdutoNivel()
                    {
                        IDProdutoNivel = Convert.ToInt32(reader["IDProdutoNivel"])
                    };
                }
            }

            return segmento;
        }

        public Segmento ListarRegraLogica(Segmento entidade)
        {
            var regraLogica = new Segmento();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDSegmento",
                    Value = entidade.IDSegmento
                },      
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoRegraLogicaListar", parms))
            {
                if (reader.Read())
                {
                    regraLogica.SegmentoRegraLogicaLista = new List<SegmentoRegraLogica>();

                    while (reader.Read())
                    {
                        var segmentoRegraLogicaLista = new SegmentoRegraLogica();

                        segmentoRegraLogicaLista.RegraLogica = new RegraLogica() { IdRegraLogica = Convert.ToInt32(reader["IdSegmento"]) };
                        segmentoRegraLogicaLista.Segmento = new Segmento() { IDSegmento = Convert.ToInt32(reader["IdRegraLogica"]) };

                        regraLogica.SegmentoRegraLogicaLista.Add(segmentoRegraLogicaLista);
                    }
                }
            }

            return regraLogica;
        }

        public void NovoRegraLogica(Segmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="IdSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoRegraLogicaNovo", parms);
        }

        public void ControleTamanhoMercado(Segmento entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDSegmento",
                Value = entidade.IDSegmento
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoTamanhoMercadoControlar", parm);
        }

        public Segmento ListarRazaoAderenciaProduto(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProduto",
                    Value = entidade.Produto.IdProduto
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoRazaoAderenciaProdutoListar", parm))
            {
                if (reader.Read())
                {
                    segmento.FatorPosicionamento = Convert.ToInt32(reader["RazaoAderencia"]);
                }
            }

            return segmento;
        }

        public Segmento ListarRazaoAderenciaProdutoNivel(Segmento entidade)
        {
            var segmento = new Segmento();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDSegmento",
                    Value = entidade.IDSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = entidade.ProdutoNivel.IDProdutoNivel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "SegmentoRazaoAderenciaProdutoNivelListar", parm))
            {
                if (reader.Read())
                {
                    segmento.FatorPosicionamento = Convert.ToInt32(reader["RazaoAderencia"]);
                }
            }

            return segmento;
        }
        #endregion
    }
}
