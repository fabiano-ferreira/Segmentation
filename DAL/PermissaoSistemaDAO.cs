using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class PermissaoSistemaDAO: BaseCRUD<PermissaoSistema>
    {
        #region BaseCRUD<PermissaoSistema> Members

        public void Novo(PermissaoSistema entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(PermissaoSistema entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(PermissaoSistema entidade)
        {
            throw new NotImplementedException();
        }

        public PermissaoSistema Listar(PermissaoSistema entidade)
        {
            var PermissaoSistema = new PermissaoSistema();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPermissao",
                Value = entidade.IDPermissao
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaListar", parm))
            {
                if (reader.Read())
                {
                    PermissaoSistema.IDPermissao = Convert.ToInt32(reader["IdPermissao"]);
                    PermissaoSistema.Nome = reader["Nome"].ToString();
                    PermissaoSistema.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    PermissaoSistema.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    PermissaoSistema.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return PermissaoSistema;
        }

        public List<PermissaoSistema> Listar()
        {
             var PermissaoSistema = new List<PermissaoSistema>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDPermissao",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaListar", parm))
            {
                while (reader.Read())
                {
                    PermissaoSistema.Add(new PermissaoSistema()
                    {
                        IDPermissao = Convert.ToInt32(reader["IDPermissao"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"])}
                    });
                }
            }

            return PermissaoSistema;
        }

        public List<PermissaoSistema> ListarSemRelacaoPerfil(PermissaoSistema entidade)
        {
            var PermissaoSistema = new List<PermissaoSistema>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = entidade.Perfil.IDPerfil
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaSemRelacaoPerfilListar", parm))
            {
                while (reader.Read())
                {
                    PermissaoSistema.Add(new PermissaoSistema()
                    {
                        IDPermissao = Convert.ToInt32(reader["IDPermissao"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return PermissaoSistema;
        }

        public List<PermissaoSistema> ListarPerfil(PermissaoSistema entidade)
        {
            var PermissaoSistema = new List<PermissaoSistema>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdPerfil",
                Value = entidade.Perfil.IDPerfil
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaPerfilListar", parm))
            {
                while (reader.Read())
                {
                    PermissaoSistema.Add(new PermissaoSistema()
                    {
                        IDPermissao = Convert.ToInt32(reader["IDPermissao"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) },
                        Perfil = new Perfil()
                        {
                            IDPerfil = Convert.ToInt32(reader["IdPerfil"])
                        },
                    });
                }
            }

            return PermissaoSistema;
        }

        public List<PermissaoSistema> ListarSemRelacaoUsuario(PermissaoSistema entidade)
        {
            var PermissaoSistema = new List<PermissaoSistema>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                Value = entidade.Usuario.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaSemRelacaoUsuarioListar", parm))
            {
                while (reader.Read())
                    {
                        PermissaoSistema.Add(new PermissaoSistema()
                        {
                            IDPermissao = Convert.ToInt32(reader["IDPermissao"]),
                            Nome = reader["Nome"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                            Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                        });
                    }               
            }

            return PermissaoSistema;
        }

        public List<PermissaoSistema> ListarUsuario(PermissaoSistema entidade)
        {
            var PermissaoSistema = new List<PermissaoSistema>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                Value = entidade.Usuario.IDUsuario
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoSistemaUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    PermissaoSistema.Add(new PermissaoSistema()
                    {
                        IDPermissao = Convert.ToInt32(reader["IDPermissao"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return PermissaoSistema;
        }

        public void NovoUsuario(PermissaoSistema entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDPermissao",
                    Value = entidade.IDPermissao
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoUsuarioNovo", parms);
        }

        public void RemoverUsuario(PermissaoSistema entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDPermissao",
                    Value = entidade.IDPermissao
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "PermissaoUsuarioRemover", parm);
        }
        #endregion
    }
}
