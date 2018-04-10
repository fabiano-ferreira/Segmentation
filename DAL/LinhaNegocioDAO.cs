using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class LinhaNegocioDAO:BaseCRUD<LinhaNegocio>
    {

        #region BaseCRUD<LinhaNegocio> Members

        public void Novo(LinhaNegocio entidade)
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
                    ParameterName="@RazaoSocial",
                    Value = entidade.RazaoSocial
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@CNPJ",
                    Value = entidade.CNPJ
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
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                }

            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioNova", parms);
        }

        public void Remover(LinhaNegocio entidade)
        {
            SqlParameter parm = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.IDLinhaNegocio
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioRemover", parm);
        }

        public void Editar(LinhaNegocio entidade)
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
                    ParameterName="@RazaoSocial",
                    Value = entidade.RazaoSocial
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@CNPJ",
                    Value = entidade.CNPJ
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
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioEditar", parms);
        }

        public LinhaNegocio Listar(LinhaNegocio entidade)
        {
            var linhaNegocio = new LinhaNegocio();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioListar", parm))
            {
                if (reader.Read())
                {
                    linhaNegocio.IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]);
                    linhaNegocio.Nome = reader["Nome"].ToString();
                    linhaNegocio.RazaoSocial = reader["RazaoSocial"].ToString();
                    linhaNegocio.CNPJ = reader["CNPJ"].ToString();
                    linhaNegocio.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    linhaNegocio.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    linhaNegocio.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return linhaNegocio;
        }

        public List<LinhaNegocio> Listar()
        {
            var linhaNegocio = new List<LinhaNegocio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioListar", parm))
            {
                while (reader.Read())
                {
                    linhaNegocio.Add(new LinhaNegocio()
                    {
                        IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]),
                        Nome = reader["Nome"].ToString(),
                        RazaoSocial = reader["RazaoSocial"].ToString(),
                        CNPJ = reader["CNPJ"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])}
                    });
                }
            }

            return linhaNegocio;
        }

        public LinhaNegocio ListarClasseVariavel(LinhaNegocio entidade)
        {
            var classeVariavel = new LinhaNegocio();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioClasseVariavelListar", parm))
            {
                if (reader.Read())
                {
                    classeVariavel.IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]);
                    classeVariavel.LinhaNegocioClasseVariavel = new List<LinhaNegocioClasseVariavel>();

                    while (reader.Read())
                    {
                        var linhaNegocioClasseVariavelLista = new LinhaNegocioClasseVariavel();

                        linhaNegocioClasseVariavelLista.ClasseVariavel = new ClasseVariavel()
                        {
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                            Nome = reader["Nome"].ToString(),
                            Codigo = reader["Codigo"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                        };
                        linhaNegocioClasseVariavelLista.Usuario = new Usuario() 
                        { 
                            IDUsuario = Convert.ToInt32(reader["IdUsuario"]) 
                        };

                        classeVariavel.LinhaNegocioClasseVariavel.Add(linhaNegocioClasseVariavelLista);
                    }
                }
            }

            return classeVariavel;
        }

        public List<LinhaNegocio> ListarClasseVariavel()
        {
            var classeVariavel = new List<LinhaNegocio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioClasseVariavelListar", parm))
            {
                while (reader.Read())
                {
                    classeVariavel.Add(new LinhaNegocio()
                    {
                        IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]),
                        ClasseVariavel = new ClasseVariavel() {
                            IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                            Nome = reader["Nome"].ToString(),
                            Codigo = reader["Codigo"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                        },
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return classeVariavel;

        }

        public void NovoClasseVariavel(LinhaNegocio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioClasseVariavelNova", parms);
        }

        public void RemoverClasseVariavel(LinhaNegocio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                }
            };
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            
            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LinhaNegocioClasseVariavelRemover", parms);

                SqlParameter parm = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDClasseVariavel",
                    Value = entidade.ClasseVariavel.IDClasseVariavel
                };

                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "ClasseVariavelRemover", parm);


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

        public LinhaNegocio ListarProdutoNivel(LinhaNegocio entidade)
        {
            var produtoNivel = new LinhaNegocio();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioProdutoNivelListar", parm))
            {
                if (reader.Read())
                {
                    produtoNivel.IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]);
                    produtoNivel.LinhaNegocioProdutoNivel = new List<LinhaNegocioProdutoNivel>();

                    while (reader.Read())
                    {
                        var linhaNegocioProdutoNivelLista = new LinhaNegocioProdutoNivel();

                        linhaNegocioProdutoNivelLista.ProdutoNivel = new ProdutoNivel()
                        {
                            IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]),
                            NomePai = reader["ProdutoNivelPai"].ToString(),
                            NomeFilho = reader["ProdutoNivelFilho"].ToString(),

                        };
                        linhaNegocioProdutoNivelLista.RelacaoProdutoNivel = new RelacaoProdutoNivel()
                        {
                            IdFilho = Convert.ToInt32(reader["IdFilho"])
                        };
                        linhaNegocioProdutoNivelLista.RelacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto()
                        {
                            IDProduto = Convert.ToInt32(reader["IdProduto"]),
                        };
                        linhaNegocioProdutoNivelLista.Produto = new Produto()
                        {
                            Nome = reader["Produto"].ToString()
                        };

                        produtoNivel.LinhaNegocioProdutoNivel.Add(linhaNegocioProdutoNivelLista);
                    }
                }
            }

            return produtoNivel;
        }

        public List<LinhaNegocio> ListarProdutoNivel()
        {
            throw new NotImplementedException();

            //var produtoNivel = new List<LinhaNegocio>();

            //SqlParameter parm = new SqlParameter()
            //{
            //    DbType = DbType.Int32,
            //    Direction = ParameterDirection.Input,
            //    ParameterName = "@IdLinhaNegocio",
            //    Value = null
            //};
            //using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioProdutoNivelListar", parm))
            //{
            //    while (reader.Read())
            //    {
            //        produtoNivel.Add(ListarProdutoNivel(new LinhaNegocio()
            //        {
            //            IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"])
            //        }));
            //        //var produtoNivelLista = new ProdutoNivel();
            //        //var relacaoProdutoNivelLista = new RelacaoProdutoNivel();
            //        //var produtoLista = new Produto();
            //        //var relacaoProdutoNivelProdutoLista = new RelacaoProdutoNivelProduto();

            //        //produtoNivelLista.IDProdutoNivel = Convert.ToInt32(reader["IdProdutoNivel"]);
            //        //produtoNivelLista.NomePai = reader["ProdutoNivelPai"].ToString();
            //        //produtoNivelLista.NomeFilho = reader["ProdutoNivelFilho"].ToString();
            //        //produtoNivel.ProdutoNivel.Add(produtoNivelLista);

            //        //relacaoProdutoNivelLista.IdFilho = Convert.ToInt32(reader["IdFilho"]);
            //        //produtoNivel.RelacaoProdutoNivel.Add(relacaoProdutoNivelLista);

            //        //relacaoProdutoNivelProdutoLista.IDProduto = Convert.ToInt32(reader["IdProduto"]);
            //        //produtoNivel.RelacaoProdutoNivelProduto.Add(relacaoProdutoNivelProdutoLista);

            //        //produtoLista.Nome = reader["Produto"].ToString();
            //        //produtoNivel.Produto.Add(produtoLista);

            //    }
            //}

            //return produtoNivel;

        }

        public void NovoProdutoNivel(string idLinhaNegocio, string idProdutoNivel)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = idLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdProdutoNivel",
                    Value = idProdutoNivel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioProdutoNivelNovo", parms);
        }

        public void RemoverProdutoNivel(LinhaNegocio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdProdutoNivel",
                    Value = entidade.ProdutoNivel.IDProdutoNivel
                },
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioProdutoNivelRemover", parms);
        }

        public List<Usuario> ListarUsuario(LinhaNegocio entidade)
        {
            List<Usuario> usuarioLista = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = entidade.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario = new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nome = reader["Nome"].ToString(),
                        Senha = reader["Senha"].ToString(),
                        MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                        Email = reader["Email"].ToString(),
                        LogUsuario = reader["LogUsuario"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                    };
                    usuarioLista.Add(usuario);
                }
            }

            return usuarioLista;
        }

        public List<LinhaNegocio> ListarUsuario()
        {
            var usuario = new List<LinhaNegocio>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdLinhaNegocio",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    usuario.Add(new LinhaNegocio()
                    {
                        IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]),
                        Usuario = new Usuario(){
                            IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nome = reader["Nome"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                            Email = reader["Email"].ToString(),
                            LogUsuario = reader["LogUsuario"].ToString()
                        },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                    });
                }
            }

            return usuario;

        }

        public void NovoUsuario(LinhaNegocio entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioUsuarioNovo", parms);
        }

        public void RemoverUsuario(LinhaNegocio entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.IDLinhaNegocio
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "LinhaNegocioUsuarioRemover", parm);
        }

        #endregion
    }
}
