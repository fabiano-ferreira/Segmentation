using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class UsuarioDAO : BaseCRUD<Usuario>
    {
        #region BaseCRUD<Usuario> Members

        public void Novo(Usuario entidade)
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
                    ParameterName="@NomeUsuario",
                    Value = entidade.NomeUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdUsuario"
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Senha",
                    Value = entidade.Senha
                },
                new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MudarSenha",
                    Value = entidade.MudarSenha
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Email",
                    Value = entidade.Email
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoStatusUsuario",
                    Value = entidade.TipoStatusUsuario.IdTipoStatusUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@LogUsuario",
                    Value = entidade.LogUsuario
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioNovo", parms);
            entidade.IDUsuario = Convert.ToInt32(parms[2].Value);
        }

        public void Remover(Usuario entidade)
        {
            SqlParameter[] parmMo = new SqlParameter[]
                {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdUsuario",
                    Value = entidade.IDUsuario
                }

            };

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();

            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LinhaNegocioUsuarioRemover", parmMo);

                SqlParameter parm = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDUsuario",
                    Value = entidade.IDUsuario
                };

                SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "UsuarioRemover", parm);
                

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

        public void Editar(Usuario entidade)
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
                    ParameterName="@NomeUsuario",
                    Value = entidade.NomeUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdTipoStatusUsuario",
                    Value = entidade.TipoStatusUsuario.IdTipoStatusUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Senha",
                    Value = entidade.Senha
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Email",
                    Value = entidade.Email
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@LogUsuario",
                    Value = entidade.LogUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    Direction = ParameterDirection.Input,
                    ParameterName="@MudarSenha",
                    Value = entidade.MudarSenha
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioEditar", parms);
        }

        public Usuario Listar(Usuario entidade)
        {
            var campanha = new Campanha();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDUsuario",
                Value = entidade.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioListar", parm))
            {
                if (reader.Read())
                {
                    entidade.IDUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    entidade.NomeUsuario = reader["NomeUsuario"].ToString();
                    entidade.Nome = reader["Nome"].ToString();
                    entidade.Senha = reader["Senha"].ToString();
                    entidade.MudarSenha = Convert.ToBoolean(reader["MudarSenha"]);
                    entidade.Email = reader["Email"].ToString();
                    entidade.TipoStatusUsuario = new TipoStatusUsuario() { IdTipoStatusUsuario = Convert.ToInt32(reader["IdTipoStatusUsuario"]) };
                    entidade.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    entidade.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    entidade.LogUsuario = reader["LogUsuario"].ToString();
                }
            }
            return entidade;
        }

        public List<Usuario> Listar()
        {
            var usuarioLista = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
             {
                 DbType = DbType.Int32,
                 Direction = ParameterDirection.Input,
                 ParameterName = "@IDUsuario",
                 Value = DBNull.Value
             };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioListar", parm))
            {
                while (reader.Read())
                {
                    usuarioLista.Add(new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nome = reader["Nome"].ToString(),
                        NomeUsuario = reader["NomeUsuario"].ToString(),
                        Senha = reader["Senha"].ToString(),
                        MudarSenha = Convert.ToBoolean(reader["MudarSenha"]),
                        Email = reader["Email"].ToString(),
                        TipoStatusUsuario = new TipoStatusUsuario() { IdTipoStatusUsuario = Convert.ToInt32(reader["IdTipoStatusUsuario"]) },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        LogUsuario = reader["LogUsuario"].ToString()
                    });
                }
                return usuarioLista;
            }
        }

        public void Desabilitar(Usuario entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                Value = entidade.IDUsuario
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioDesabilitar", parm);
        }

        public Usuario ListarLinhaNegocio(Usuario entidade)
        {
            var usuario = new Usuario();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDUsuario",
                Value = entidade.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioLinhaNegocioListar", parm))
            {
                if (reader.Read())
                {
                    usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                    usuario.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IDLinhaNegocio"]) };
                }
            }

            return usuario;
        }

        public Usuario ListarPerfil(Usuario entidade)
        {
            var usuario = new Usuario();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDUsuario",
                Value = entidade.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioPerfilListar", parm))
            {
                if (reader.Read())
                {
                    usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                    usuario.Perfil = new List<Perfil>();
                    while (reader.Read())
                    {
                        var perfilLista = new Perfil();
                        perfilLista.IDPerfil = Convert.ToInt32(reader["IDPerfil"]);
                        perfilLista.Nome = reader["Nome"].ToString();
                        perfilLista.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        perfilLista.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);

                        usuario.Perfil.Add(perfilLista);
                    }

                }
            }

            return usuario;
        }

        public Usuario Validar(Usuario entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@NomeUsuario",
                    Value = entidade.NomeUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Senha",
                    Value = entidade.Senha
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioValidar", parms))
            {
                if (reader.Read())
                {
                    entidade.IDUsuario = (reader["IdUsuario"] is DBNull) ? 0 : Convert.ToInt32(reader["IdUsuario"]);
                    entidade.Nome = reader["Nome"].ToString();
                    entidade.NomeUsuario = reader["NomeUsuario"].ToString();
                    entidade.Senha = reader["Senha"].ToString();
                    entidade.MudarSenha = Convert.ToBoolean(reader["MudarSenha"]);
                    entidade.Email = reader["Email"].ToString();
                    entidade.TipoStatusUsuario = new TipoStatusUsuario() { IdTipoStatusUsuario = (reader["IdTipoStatusUsuario"] is DBNull) ? 0 : Convert.ToInt32(reader["IdTipoStatusUsuario"]) };
                    entidade.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    entidade.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    entidade.LogUsuario = reader["LogUsuario"].ToString();
                    entidade.LinhaNegocio = new LinhaNegocio() { IDLinhaNegocio = Convert.ToInt32(reader["IdLinhaNegocio"]) };
                }
            }
            return entidade;
        }
        #endregion
    }
}
