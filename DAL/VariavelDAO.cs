using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class VariavelDAO: BaseCRUD<Variavel>
    {

        #region BaseCRUD<Variavel> Members

        public void Novo(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IDVariavel",
                    Value = entidade.IDVariavel
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
                    ParameterName="@IdTipoVariavel",
                    Value = entidade.TipoVariavel.IDTipoVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDTipoSaida",
                    Value = entidade.TipoSaida.IDTipoSaida
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
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Significado",
                    Value = entidade.Significado
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MetodoCientificoObtencao",
                    Value = entidade.MetodoCientificoObtencao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MetodoPraticoObtencao",
                    Value = entidade.MetodoPraticoObtencao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@PerguntaSistema",
                    Value = entidade.PerguntaSistema
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@InteligenciaSistemicaModelo",
                    Value = entidade.InteligenciaSistemicaModelo
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
                    ParameterName="@ColunaImportacao",
                    Value = entidade.ColunaImportacao
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDTipoDadoVariavel",
                    Value = entidade.TipoDadoVariavel.IDTipoDadoVariavel
                }
            };

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();

            try
            {
                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "VariavelNova", parms);
                entidade.IDVariavel = Convert.ToInt32(parms[0].Value);
                SqlParameter[] parmsMo = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IDVariavel",
                        Value = entidade.IDVariavel
                    },
                    new SqlParameter()
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName="@IdModelo",
                        Value = entidade.Modelo.IDModelo
                    }
                };
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ModeloVariavelNovo", parmsMo);

                trans.Commit();
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

        public void Remover(Variavel entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDVariavel",
                Value = entidade.IDVariavel
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRemover", parm);
        }

        public void Editar(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.IDVariavel
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
                    ParameterName="@IdTipoVariavel",
                    Value = entidade.TipoVariavel.IDTipoVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDTipoSaida",
                    Value = entidade.TipoSaida.IDTipoSaida
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
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Significado",
                    Value = entidade.Significado
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MetodoCientificoObtencao",
                    Value = entidade.MetodoCientificoObtencao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MetodoPraticoObtencao",
                    Value = entidade.MetodoPraticoObtencao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@PerguntaSistema",
                    Value = entidade.PerguntaSistema
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@InteligenciaSistemicaModelo",
                    Value = entidade.InteligenciaSistemicaModelo
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
                    ParameterName="@ColunaImportacao",
                    Value = entidade.ColunaImportacao
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelEditar", parms);
        }

        public Variavel Listar(Variavel entidade)
        {
            var variavel = new Variavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDVariavel",
                Value = entidade.IDVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelListar", parm))
            {
                if (reader.Read())
                {
                    variavel.IDVariavel = Convert.ToInt32(reader["IDVariavel"]);

                    variavel.TipoVariavel = new TipoVariavel() 
                    { 
                        IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                        Nome = reader["NomeTipoVariável"].ToString()
                    };

                    variavel.ClasseVariavel = new ClasseVariavel()
                    {
                        IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                        Nome = reader["NomeClasseVariavel"].ToString()
                    };

                    variavel.TipoSaida = new TipoSaida()
                    {
                        IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]),
                        Nome = reader["NomeTipoSaida"].ToString()
                    };

                    variavel.Codigo = reader["Codigo"].ToString();
                    variavel.Descricao = reader["Descricao"].ToString();
                    variavel.Significado = reader["Significado"].ToString();
                    variavel.MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString();
                    variavel.MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString();
                    variavel.PerguntaSistema = reader["PerguntaSistema"].ToString();
                    variavel.InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString();
                    variavel.Comentario = reader["Comentario"].ToString();                
                    variavel.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    variavel.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    variavel.ColunaImportacao = Convert.ToInt32(reader["ColunaImportacao"]);
                    variavel.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return variavel;
        }

        public List<Variavel> Listar()
        {
            var variavel = new List<Variavel>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDVariavel",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Codigo",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdClasseVariavel",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = null
                },

                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelListar", parms))
            {
                while (reader.Read())
                {
                    variavel.Add(new Variavel()
                    {
                        IDVariavel = Convert.ToInt32(reader["IDVariavel"]),
                        Descricao = reader["Descricao"].ToString()
                    });
                }
                return variavel;
            }
        }

        public List<Variavel> ListarRelacaoModelo(Variavel entidade)
        {
            var variavel = new List<Variavel>();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }

                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRelacaoModeloListar", parms))
            {
                while (reader.Read())
                {
                    variavel.Add(new Variavel()
                    {
                        IDVariavel = Convert.ToInt32(reader["IDVariavel"]),
                        Descricao = reader["Descricao"].ToString()
                    });
                }
                return variavel;
            }
        }

        public Variavel ListarCriterio(Variavel entidade)
        {
            var variavel = new Variavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDVariavel",
                Value = entidade.IDVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelCriterioListar", parm))
            {
                if (reader.Read())
                {
                    variavel.IDVariavel = Convert.ToInt32(reader["IDVariavel"]);
                    entidade.CriterioVariavel = new List<CriterioVariavel>();
                    while (reader.Read())
                    {
                        var criterioLista = new CriterioVariavel();
                        criterioLista.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"]) };
                        criterioLista.Criterio = new Criterio() { Nome = reader["Nome"].ToString() };
                        criterioLista.Criterio = new Criterio() { DataCriacao = Convert.ToDateTime(reader["DataCriacao"]) };
                        criterioLista.Criterio = new Criterio() { DataModificacao = Convert.ToDateTime(reader["DataModificacao"]) };
                        criterioLista.Criterio.Usuario  = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                        entidade.CriterioVariavel.Add(criterioLista);
                    }
                }
            }

            return variavel;
        }

        public void NovaRegraLogica(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IDVariavel",
                    Value = entidade.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDCriterio",
                    Value = entidade.Criterio.IDCriterio
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRegraLogicaNova", parms);
        }

        public void RemoverRegraLogico(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                } 
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRegraLogicoRemover", parms);
        }

        public Variavel ListarRegraLogica(Variavel entidade)
        {
            var regraLogica = new Variavel();

            SqlParameter parms = new SqlParameter
            {
                
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDVariavel",
                    Value = entidade.IDVariavel
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRegraLogicaListar", parms))
            {
                regraLogica.VariavelRegraLogicaLista = new List<VariavelRegraLogica>();

                while (reader.Read())
                {
                    var variavelRegraLogica = new VariavelRegraLogica();

                    variavelRegraLogica.RegraLogica = new RegraLogica() { IdRegraLogica = Convert.ToInt32(reader["IdSegmento"]) };
                    variavelRegraLogica.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) };
                    variavelRegraLogica.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IdCriterio"]) };
                    variavelRegraLogica.Valor = reader["Valor"].ToString();
                    variavelRegraLogica.TipoComparacaoRegraLogica = new TipoComparacaoRegraLogica() { IDTipoComparacaoRegraLogica = Convert.ToInt32(reader["IDTipoComparacaoRegraLogica"]) };

                    regraLogica.VariavelRegraLogicaLista.Add(variavelRegraLogica);
                }
            }

            return regraLogica;
        }

        public void RemoverRelacao(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFilho",
                    Value = entidade.IdFilho
                },
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoVariavelRemover", parms);
        }

        public void NovaRelacao(Variavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.IdPai
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFilho",
                    Value = entidade.IDVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoVariavelNovo", parms);
        }

        public List<Variavel> ListarRelacao(Variavel entidade)
        {
            List<Variavel> variavelLista = new List<Variavel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDVariavel",
                Value = entidade.IDVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "RelacaoVariavelListar", parm))
            {
                var variavel = new Variavel();
                while (reader.Read())
                {
                    variavelLista.Add(new Variavel()
                    {
                        IDVariavel = Convert.ToInt32(reader["IdPai"]),
                        Descricao = reader["Descricao"].ToString(),
                        IdFilho = Convert.ToInt32(reader["IdFilho"])
                    });                   
                }
            }

            return variavelLista;
        }

        public Variavel ListarOutputGlobal(Variavel entidade)
        {
            var outPutGlobal = new Variavel();

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
                    ParameterName = "@IdTipoSaida",
                    Value = entidade.TipoSaida.IDTipoSaida
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelOutputGlobalListar", parms))
            {
                if (reader.Read())
                {
                    outPutGlobal.IDVariavel = Convert.ToInt32(reader["IdVariavel"]);
                    outPutGlobal.TipoVariavel = new TipoVariavel() { IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]) };
                    outPutGlobal.ClasseVariavel = new ClasseVariavel() { IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]) };
                    outPutGlobal.TipoSaida = new TipoSaida() { IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]) };
                    outPutGlobal.TipoDadoVariavel = new TipoDadoVariavel() { IDTipoDadoVariavel = Convert.ToInt32(reader["IdTipoDadoVariavel"]) };
                    outPutGlobal.Codigo = reader["Codigo"].ToString();
                    outPutGlobal.Descricao = reader["Descricao"].ToString();
                    outPutGlobal.Significado = reader["Significado"].ToString();
                    outPutGlobal.MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString();
                    outPutGlobal.MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString();
                    outPutGlobal.PerguntaSistema = reader["PerguntaSistema"].ToString();
                    outPutGlobal.InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString();
                    outPutGlobal.Comentario = reader["Comentario"].ToString();
                    outPutGlobal.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    outPutGlobal.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    if (!string.IsNullOrEmpty(reader["ColunaImportacao"].ToString()))
                        outPutGlobal.ColunaImportacao = Convert.ToInt32(reader["ColunaImportacao"]);
                    outPutGlobal.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return outPutGlobal;
        }

        public Variavel ListarRegraLogicaProcessoSegmento(Variavel entidade)
        {
            var RegraLogicaProcessoSegmento = new Variavel();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoSaida",
                    Value = entidade.TipoSaida.IDTipoSaida
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
                    ParameterName = "@IdRegraLogica",
                    Value = entidade.RegraLogica.IdRegraLogica
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelRegraLogicaProcessoSegmentoListar", parms))
            {
                RegraLogicaProcessoSegmento.VariavelRegraLogicaLista = new List<VariavelRegraLogica>();
                while (reader.Read())
                {
                    var variavelRegraLogica = new VariavelRegraLogica();

                    variavelRegraLogica.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(reader["IDVariavel"]) };
                    variavelRegraLogica.RegraLogica = new RegraLogica() { IdRegraLogica = Convert.ToInt32(reader["IDVariavel"]) };
                    variavelRegraLogica.Criterio = new Criterio() { IDCriterio = Convert.ToInt32(reader["IDCriterio"]) };
                    variavelRegraLogica.Valor = reader["Valor"].ToString();

                    RegraLogicaProcessoSegmento.VariavelRegraLogicaLista.Add(variavelRegraLogica);
                }
            }

            return RegraLogicaProcessoSegmento;
        }

        public List<Variavel> ListarModelo(Variavel entidade)
        {
            var variavel = new List<Variavel>();

            SqlParameter[] parms = new SqlParameter[]
            {
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
                    ParameterName="@IDLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDModelo",
                    Value = entidade.Modelo.IDModelo
                }
                ,
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Descricao",
                    Value = entidade.Descricao
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelListar", parms))
            {
                while (reader.Read())
                {
                    var variavelLista = new Variavel();

                    variavelLista.IDVariavel = Convert.ToInt32(reader["IDVariavel"]);

                    variavelLista.TipoVariavel = new TipoVariavel()
                    {
                        IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"])
                    };

                    variavelLista.ClasseVariavel = new ClasseVariavel()
                    {
                        IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"])
                    };

                    variavelLista.TipoSaida = new TipoSaida()
                    {
                        IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"])
                    };

                    variavelLista.Codigo = reader["Codigo"].ToString();
                    variavelLista.Descricao = reader["Descricao"].ToString();
                    variavelLista.Significado = reader["Significado"].ToString();
                    variavelLista.MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString();
                    variavelLista.MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString();
                    variavelLista.PerguntaSistema = reader["PerguntaSistema"].ToString();
                    variavelLista.InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString();
                    variavelLista.Comentario = reader["Comentario"].ToString();
                    variavelLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                    variavel.Add(variavelLista);
                }
                return variavel;
            }
        }

        public List<Variavel> ListarLinhaNegocioModelo(Variavel entidade)
        {
            var variavel = new List<Variavel>();

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
                    ParameterName = "@IDLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelModeloListar", parms))
            {
                while (reader.Read())
                {
                    var variavelLista = new Variavel();

                    variavelLista.IDVariavel = Convert.ToInt32(reader["IDVariavel"]);

                    variavelLista.TipoVariavel = new TipoVariavel()
                    {
                        IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"])
                    };

                    variavelLista.ClasseVariavel = new ClasseVariavel()
                    {
                        IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"])
                    };

                    variavelLista.TipoSaida = new TipoSaida()
                    {
                        IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"])
                    };

                    variavelLista.Codigo = reader["Codigo"].ToString();
                    variavelLista.Descricao = reader["Descricao"].ToString();
                    variavelLista.Significado = reader["Significado"].ToString();
                    variavelLista.MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString();
                    variavelLista.MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString();
                    variavelLista.PerguntaSistema = reader["PerguntaSistema"].ToString();
                    variavelLista.InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString();
                    variavelLista.Comentario = reader["Comentario"].ToString();
                    variavelLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                    variavelLista.TipoDadoVariavel = new TipoDadoVariavel() { IDTipoDadoVariavel = Convert.ToInt32(reader["IDTipoDadoVariavel"]) };
                    variavelLista.IdPai = (reader["IdPai"])is DBNull? 0 : Convert.ToInt32(reader["IdPai"]);
                    variavel.Add(variavelLista);
                }
                return variavel;
            }
        }
        #endregion
    }
}
