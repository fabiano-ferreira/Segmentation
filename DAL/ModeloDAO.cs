using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class ModeloDAO:BaseCRUD<Modelo>
    {
        #region BaseCRUD<Modelo> Members

        public void Novo(Modelo entidade)
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
                    ParameterName="@IdTipoSegmento",
                    Value = entidade.TipoSegmento.IDTipoSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdModelo",
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloNovo", parms);

            entidade.IDModelo = Convert.ToInt32(parms[3].Value);
        }

        public void Remover(Modelo entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloRemover", parm);
        }

        public void Editar(Modelo entidade)
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
                    ParameterName="@IdTipoSegmento",
                    Value = entidade.TipoSegmento.IDTipoSegmento
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.IDModelo
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloEditar", parms);
        }

        public Modelo Listar(Modelo entidade)
        {
            var modelo = new Modelo();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloListar", parm))
            {
                if (reader.Read())
                {
                    modelo.IDModelo = Convert.ToInt32(reader["IdModelo"]);
                    modelo.Nome = reader["ModeloNome"].ToString();
                    modelo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    modelo.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    modelo.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                    modelo.TipoSegmento = new TipoSegmento() { Nome = reader["TipoSegmentoNome"].ToString() };
                    modelo.Grafico = new Grafico() { IDGrafico = Convert.ToInt32(reader["IdGrafico"]) };
                }
            }

            return modelo;
        }

        public List<Modelo> Listar()
        {
            var modelo = new List<Modelo>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloListar", parm))
            {
                while (reader.Read())
                {
                    modelo.Add(new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
                        Nome = reader["ModeloNome"].ToString(),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])},
                        TipoSegmento = new TipoSegmento() {Nome = reader["TipoSegmentoNome"].ToString()},
                    });
                }
            }

            return modelo;
        }

        public List<Modelo> RelacaoVariavelListar(Modelo entidade)
        {
            var modelo = new List<Modelo>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = entidade.Campanha.IDCampanha
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloRelacaoVariavelListar", parm))
            {
                while (reader.Read())
                {
                    modelo.Add(new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
                        Nome = reader["Nome"].ToString(),
                    });
                }
            }

            return modelo;
        }

        public List<Modelo> CampanhaListar(Modelo entidade)
        {
            var modelo = new List<Modelo>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = null
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = entidade.Campanha.IDCampanha
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloCampanhaListar", parm))
            {
                while (reader.Read())
                {
                    modelo.Add(new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
                        Nome = reader["ModeloNome"].ToString(),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        TipoSegmento = new TipoSegmento() 
                        { 
                            Nome = reader["TipoSegmentoNome"].ToString(),
                            IDTipoSegmento = Convert.ToInt32(reader["IdTipoSegmento"])
                        },
                    });
                }

            }
            return modelo;
        }


        public Modelo ListarFator(Modelo entidade)
        {
            var fator = new Modelo();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloFatorListar", parm))
            {
                if (reader.Read())
                {
                    fator.IDModelo = Convert.ToInt32(reader["IdModelo"]);
                    fator.ModeloFator = new List<ModeloFator>();

                    while (reader.Read())
                    {
                        var modeloFatorLista = new ModeloFator();

                        modeloFatorLista.Fator = new Fator()
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
                        modeloFatorLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                        modeloFatorLista.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) };
                        modeloFatorLista.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) };

                        fator.ModeloFator.Add(modeloFatorLista);
                    }
                }
            }

            return fator;
        }

        public List<Modelo> ListarFator()
        {
            var fator = new List<Modelo>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloFatorListar", parm))
            {
                while (reader.Read())
                {
                    fator.Add(new Modelo()
                    {

                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
                        Fator = new Fator() {
                            IDFator = Convert.ToInt32(reader["IdFator"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Peso = Convert.ToInt32(reader["Peso"]),
                            Comentario = reader["Comentario"].ToString(),
                        },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() {IDUsuario = Convert.ToInt32(reader["IdUsuario"])},
                        LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"])},
                        TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(reader["IdTipoFator"]) }
                    });
                }
            }

            return fator;
        }

        public void NovoFator(Modelo entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdFator",
                    Value = entidade.Fator.IDFator
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloFatorNovo", parms);
        }

        public void RemoverFator(Modelo entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdFator",
                    Value = entidade.Fator.IDFator
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloFatorRemover", parms);
        }

        public List<Usuario> ListarUsuario(Modelo entidade)
        {
            var usuario = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    usuario.Add(new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Senha = reader["Senha"].ToString(),
                        MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                        LogUsuario = reader["LogUsuario"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                    });
                }
            }

            return usuario;
        }

        public List<Usuario> UsuarioSemRelacaoUsuarioListar(Modelo entidade)
        {
            var usuario = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloUsuarioSemRelacaoUsuario", parm))
            {
                while (reader.Read())
                {
                    usuario.Add(new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Senha = reader["Senha"].ToString(),
                        MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                        LogUsuario = reader["LogUsuario"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                    });
                }
            }

            return usuario;
        }

        public List<Modelo> ListarUsuario()
        {
            var usuario = new List<Modelo>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    usuario.Add(new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
                        Usuario = new Usuario(){
                            IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nome = reader["Nome"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                            LogUsuario = reader["LogUsuario"].ToString()
                        },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                    });
                }
            }

            return usuario;
        }

        public void NovoUsuario(Modelo entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloUsuarioNovo", parms);
        }

        public void RemoverUsuario(Modelo entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloUsuarioRemover", parm);
        }

        public Modelo ListarVariavel(Modelo entidade)
        {
            var variavel = new Modelo();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = entidade.IDModelo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloVariavelListar", parm))
            {
                if (reader.Read())
                {
                    variavel.IDModelo = Convert.ToInt32(reader["IdModelo"]);
                    variavel.ModeloVariavel = new List<ModeloVariavel>();

                    while (reader.Read())
                    {
                        var modeloVariavelLista = new ModeloVariavel();

                        modeloVariavelLista.Variavel = new Variavel()
                        {
                            IDVariavel = Convert.ToInt32(reader["IdVariavel"]),
                            Codigo = reader["Codigo"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Significado = reader["Significado"].ToString(),
                            MetodoCientificoObtencao = reader["MetodoCientificoObtencao"].ToString(),
                            MetodoPraticoObtencao = reader["MetodoPraticoObtencao"].ToString(),
                            PerguntaSistema = reader["PerguntaSistema"].ToString(),
                            InteligenciaSistemicaModelo = reader["InteligenciaSistemicaModelo"].ToString(),
                            Comentario = reader["Comentario"].ToString()
                        };
                        modeloVariavelLista.TipoVariavel = new TipoVariavel()
                        {
                            IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                            Nome = reader["NomeTipoVariavel"].ToString(),
                        };
                        modeloVariavelLista.ClasseVariavel = new ClasseVariavel()
                        {
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                            Nome = reader["NomeClasseVariavel"].ToString()
                        };
                        modeloVariavelLista.TipoSaida = new TipoSaida()
                        {
                            IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]),
                            Nome = reader["NomeTipoSaida"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                        };
                        modeloVariavelLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                        variavel.ModeloVariavel.Add(modeloVariavelLista);
                    }
                }
            }

            return variavel;
        }

        public List<Modelo> ListarVariavel()
        {
            var variavel = new List<Modelo>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdModelo",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloVariavelListar", parm))
            {
                while (reader.Read())
                {
                    variavel.Add(new Modelo()
                    {
                        IDModelo = Convert.ToInt32(reader["IdModelo"]),
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
                            Comentario = reader["Comentario"].ToString()
                        },
                        TipoVariavel = new TipoVariavel()
                        {
                            IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                            Nome = reader["NomeTipoVariavel"].ToString(),
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
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return variavel;
        }

        public void NovoVariavel(Modelo entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloVariavelNovo", parms);
        }

        public void RemoverVariavel(Modelo entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.IDModelo
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVariavel",
                    Value = entidade.Variavel.IDVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloVariavelRemover", parm);
        }

        public Modelo ListarVariavelImportacao(Modelo entidade)
        {
            var variavelImportacao = new Modelo();

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdTipoDadoVariavel",
                    Value = entidade.TipoDadoVariavel.IDTipoDadoVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.IDModelo
                }
                
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ModeloVariavelImportacaoListar", parms))
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        var modeloVariavelLista = new ModeloVariavel();

                        modeloVariavelLista.Variavel = new Variavel()
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
                            ColunaImportacao = Convert.ToInt32(reader["ColunaImportacao"])
                        };
                        modeloVariavelLista.TipoVariavel = new TipoVariavel()
                        {
                            IDTipoVariavel = Convert.ToInt32(reader["IdTipoVariavel"]),
                        };
                        modeloVariavelLista.ClasseVariavel = new ClasseVariavel()
                        {
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                        };
                        modeloVariavelLista.TipoSaida = new TipoSaida()
                        {
                            IDTipoSaida = Convert.ToInt32(reader["IdTipoSaida"]),
                        };

                        variavelImportacao.ModeloVariavel.Add(modeloVariavelLista);
                    }
                }
            }

            return variavelImportacao;
        }

        #endregion
    }
}
