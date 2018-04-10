using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class CampanhaDAO:BaseCRUD<Campanha>
    {
        #region BaseCRUD<Campanha> Members

        public void Novo(Campanha entidade)
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
                    ParameterName="@IdCampanha",
                    Value = entidade.IDCampanha
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaNova", parms);
        }

        public void Remover(Campanha entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName="@IdCampanha",
                Value = entidade.IDCampanha
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaRemover", parm);
        }

        public void Editar(Campanha entidade)
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
                    ParameterName="@IdCampanha",
                    Value = entidade.IDCampanha
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaEditar", parms);
        }

        public List<Campanha> ListarRelacaoUsuario(Campanha entidade)
        {
            var campanha = new List<Campanha>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = entidade.IDCampanha
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaRelacaoUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    campanha.Add(new Campanha()
                    {
                        IDCampanha = Convert.ToInt32(reader["IdCampanha"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return campanha;
        }

        public List<Campanha> Listar()
        {
            var campanha = new List<Campanha>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = DBNull.Value
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaListar", parm))
            {
                while (reader.Read())
                {
                    campanha.Add(new Campanha()
                    {
                        IDCampanha = Convert.ToInt32(reader["IdCampanha"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return campanha;
        }

        public Campanha Listar(Campanha entidade)
        {
            var campanha = new Campanha();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = DBNull.Value
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaListar", parm))
            {
                if (reader.Read())
                {
                    campanha.IDCampanha = Convert.ToInt32(reader["IdCampanha"]);
                    campanha.Nome = reader["Nome"].ToString();
                    campanha.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    campanha.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    campanha.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return campanha;
        }

        public List<Campanha> ListarModelo()
        {
            var campanha = new List<Campanha>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCampanha",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaModeloListar", parm))
            {
                while (reader.Read())
                {
                    campanha.Add(new Campanha()
                    {
                        IDCampanha = Convert.ToInt32(reader["IdCampanha"]),
                        Modelo = new Modelo() { IDModelo = Convert.ToInt32(reader["IdModelo"]) },
                        Nome = reader["Nome"].ToString()

                    });
                }
            }

            return campanha;
        }

        public void NovoModelo(Campanha entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCampanha",
                    Value = entidade.IDCampanha
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaModeloNovo", parms);
        }

        public Campanha ListarModelo(Campanha entidade)
        {
            var campanha = new Campanha();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCampanha",
                Value = entidade.IDCampanha
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaModeloListar", parm))
            {
                if (reader.Read())
                {
                    campanha.CampanhaModelo = new List<CampanhaModelo>();

                    campanha.IDCampanha = Convert.ToInt32(reader["IdCampanha"]);
                    while (reader.Read())
                    {
                        var campanhaModeloLista = new CampanhaModelo();
                        

                        campanhaModeloLista.Modelo = new Modelo() 
                        { 
                            IDModelo = Convert.ToInt32(reader["IdModelo"]),
                            Nome = reader["Nome"].ToString()
                        };
                        campanha.CampanhaModelo.Add(campanhaModeloLista);
                    }
                }
            }

            return campanha;
        }

        public void NovoUsuario(Campanha entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCampanha",
                    Value = entidade.IDCampanha
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaUsuarioNovo", parms);
        }
        
        public void RemoverUsuario(Campanha entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = entidade.IDCampanha
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IDUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaUsuarioRemover", parm);
        }

        public List<Usuario> ListarUsuario (Campanha entidade)
        {
            List<Usuario> dadosUsuarioLista = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCampanha",
                Value = entidade.IDCampanha
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    dadosUsuarioLista.Add(new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IDUsuario"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }
            return dadosUsuarioLista;
        }

        public List<Usuario> ListarUsuarioSemRelacao(Campanha entidade)
        {
            List<Usuario> dadosUsuarioLista = new List<Usuario>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCampanha",
                Value = entidade.IDCampanha
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaSemRelacaoUsuarioListar", parm))
            {
                while (reader.Read())
                {
                    dadosUsuarioLista.Add(new Usuario()
                    {
                        IDUsuario = Convert.ToInt32(reader["IDUsuario"]),
                        Nome = reader["Nome"].ToString()
                    });
                }
            }
            return dadosUsuarioLista;
        }

        public void ModeloRemover(Campanha entidade)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdCampanha",
                    Value = entidade.IDCampanha
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdModelo",
                    Value = entidade.Modelo.IDModelo
                }
                
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "CampanhaModeloRemover", parm);
        }
        #endregion

    }
}
