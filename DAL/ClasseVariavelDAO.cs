using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class ClasseVariavelDAO:BaseCRUD<ClasseVariavel>
    {
        #region BaseCRUD<Classe> Members

        public void Novo(ClasseVariavel entidade)
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName="@IdClasseVariavel"
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ClasseVariavelNova", parms);
            entidade.IDClasseVariavel = Convert.ToInt32(parms[4].Value);
        }

        public void Remover(ClasseVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(ClasseVariavel entidade)
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdClasseVariavel",
                    Value = entidade.IDClasseVariavel
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ClasseVariavelEditar", parms);
        }

        public ClasseVariavel Listar(ClasseVariavel entidade)
        {
            var classeVariavel = new ClasseVariavel();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdClasseVariavel",
                Value = entidade.IDClasseVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ClasseVariavelListar", parm))
            {
                if (reader.Read())
                {
                    classeVariavel.IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]);
                    classeVariavel.Nome = reader["Nome"].ToString();
                    classeVariavel.Codigo = reader["Codigo"].ToString();
                    classeVariavel.Descricao = reader["Descricao"].ToString();
                    classeVariavel.Usuario.IDUsuario = Convert.ToInt32(reader["IdUsuario"]);
                }
            }

            return classeVariavel;
        }

        public List<ClasseVariavel> Listar()
        {
            var classeVariavel = new List<ClasseVariavel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdClasseVariavel",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ClasseVariavelListar", parm))
            {
                while (reader.Read())
                {
                    classeVariavel.Add(new ClasseVariavel()
                    {
                        IDClasseVariavel = Convert.ToInt32(reader["IdClasseVariavel"]),
                        Nome = reader["Nome"].ToString(),
                        Codigo = reader["Codigo"].ToString()
                    });
                }
            }

            return classeVariavel;
        }

        public string Validar(ClasseVariavel entidade)
        {
            string resultado = string.Empty;
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                ParameterName = "@Codigo",
                Value = entidade.Codigo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "ClasseVariavelValidar", parm))
            {
                if (reader.Read())
                {
                    resultado = reader["Codigo"].ToString();
                }
            }
            return resultado;
        }

        #endregion

    }
}
