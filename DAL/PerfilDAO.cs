using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class PerfilDAO:BaseCRUD<Perfil>
    {
        #region BaseCRUD<Perfil> Members

        public void Novo(Perfil entidade)
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
                    ParameterName="@IdPerfil",
                    Value = entidade.IDPerfil
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilNovo", parms);
        }

        public void Remover(Perfil entidade)
        {
            SqlParameter parm = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = entidade.IDPerfil
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilRemover", parm);
        }

        public void Editar(Perfil entidade)
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
                    ParameterName="@IdPerfil",
                    Value = entidade.IDPerfil
                }

            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilEditar", parms);
        }

        public Perfil Listar(Perfil entidade)
        {
            var perfil = new Perfil();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = entidade.IDPerfil
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilListar", parm))
            {
                if (reader.Read())
                {
                    perfil.IDPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    perfil.Nome = reader["Nome"].ToString();
                    perfil.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    perfil.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    perfil.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return perfil;
        }

        public List<Perfil> Listar()
        {
            var perfil = new List<Perfil>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilListar", parm))
            {
                while (reader.Read())
                {
                    perfil.Add(new Perfil()
                    {
                        IDPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])}
                    });
                }
            }

            return perfil;
        }

        public Perfil ListarPermissaoSistemaPerfil(Perfil entidade)
        {
            var permissaoSistema = new Perfil();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = entidade.IDPerfil
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaPerfilListar", parm))
            {
                if (reader.Read())
                {
                    permissaoSistema.IDPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    permissaoSistema.PerfilPermissaoSistema = new List<PerfilPermissaoSistema>();

                    while (reader.Read())
                    {
                        var perfilPermissaoSistemaLista = new PerfilPermissaoSistema();

                        perfilPermissaoSistemaLista.PermissaoSistema = new PermissaoSistema()
                        {
                            IDPermissao = Convert.ToInt32(reader["IdPermissao"]),
                            Nome = reader["Nome"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"])
                        };
                        perfilPermissaoSistemaLista.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };

                        permissaoSistema.PerfilPermissaoSistema.Add(perfilPermissaoSistemaLista);
                    }
                }
            }

            return permissaoSistema;
        }

        public List<Perfil> ListarPermissaoSistemaPerfil()
        {
            var PermissaoSistema = new List<Perfil>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaPerfilListar", parm))
            {
                while (reader.Read())
                {
                    PermissaoSistema.Add(new Perfil()
                    {
                        IDPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        PermissaoSistema = new PermissaoSistema(){
                            IDPermissao = Convert.ToInt32(reader["IdPermissao"]),
                            Nome = reader["Nome"].ToString()
                        },
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])}
                    });
                }
            }

            return PermissaoSistema;
        }

        public void NovoPermissaoSistema(Perfil entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdPerfil",
                    Value = entidade.IDPerfil
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdPermissao",
                    Value = entidade.PermissaoSistema.IDPermissao
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaPerfilNovo", parms);
        }

        public void RemoverPermissaoSistema(Perfil entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdPerfil",
                    Value = entidade.IDPerfil
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdPermissao",
                    Value = entidade.PermissaoSistema.IDPermissao
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilPermissaoSistemaRemover", parms);
        }

        public void NovoUsuario(Perfil entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
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
                    ParameterName="@IdPerfil",
                    Value = entidade.IDPerfil
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilUsuarioNovo", parms);
        }

        public void RemoverUsuario(Perfil entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter(){
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdPerfil",
                    Value = entidade.IDPerfil
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilUsuarioRemover", parms);
        }

        public List<Perfil> ListarSemRelacaoUsuario(Perfil entidade)
        {
            var Perfil = new List<Perfil>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                Value = entidade.Usuario.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilSemRelacaoUsuarioListar", parm))
            {
               while (reader.Read())
                {
                    Perfil.Add(new Perfil()
                    {
                        IDPerfil = Convert.ToInt32(reader["IDPerfil"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return Perfil;
        }

        public List<Perfil> ListarUsuario(Perfil entidade)
        {
            var PermissaoSistema = new List<Perfil>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                Value = entidade.Usuario.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PerfilUsuarioListar", parm))
            {
            while (reader.Read())
                {
                    PermissaoSistema.Add(new Perfil()
                    {
                        IDPerfil = Convert.ToInt32(reader["IDPerfil"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }

            return PermissaoSistema;
        }

        #endregion
    }
}
