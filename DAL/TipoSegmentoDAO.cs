using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;
using System.Collections;

namespace DAL
{
    public class TipoSegmentoDAO: BaseCRUD<TipoSegmento>
    {
        #region BaseCRUD<TipoSegmento> Members

        public void Novo(TipoSegmento entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output,
                    ParameterName = "IDTipoSegmento",
                    Value = entidade.IDTipoSegmento
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
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDLinhaNegocio",
                    Value = entidade.LinhaNegocio.IDLinhaNegocio
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoNovo", parms);
        }

        public void Remover(TipoSegmento entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoSegmento",
                Value = entidade.IDTipoSegmento
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoRemover", parm);
        }

        public void Editar(TipoSegmento entidade)
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
                    ParameterName="@IDTipoSegmento",
                    Value = entidade.IDTipoSegmento
                },
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoEditar", parms);
        }

        public TipoSegmento Listar(TipoSegmento entidade)
        {
            var tipoSegmento = new TipoSegmento();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoSegmento",
                Value = entidade.IDTipoSegmento
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoListar", parm))
            {
                if (reader.Read())
                {
                    tipoSegmento.IDTipoSegmento = Convert.ToInt32(reader["IDTipoSegmento"]);
                    tipoSegmento.Nome = reader["Nome"].ToString();
                    tipoSegmento.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoSegmento.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoSegmento.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoSegmento;
        }

        public List<TipoSegmento> Listar()
        {
            var tipoSegmento = new List<TipoSegmento>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoSegmento",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoListar", parm))
            {
                while (reader.Read())
                {
                    tipoSegmento.Add(new TipoSegmento()
                    {
                        IDTipoSegmento = Convert.ToInt32(reader["IDTipoSegmento"]),
                        Nome = reader["Nome"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return tipoSegmento;
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
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoModeloListar", parm))
            {
                if (reader.Read())
                {
                    modelo.TipoSegmento = new TipoSegmento() { IDTipoSegmento = Convert.ToInt32(reader["IDTipoSegmento"]) };
                    modelo.Nome = reader["Nome"].ToString();
                    modelo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    modelo.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    modelo.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return modelo;
        }

        public List<TipoSegmento> ListarLinhaNegocio(TipoSegmento entidade)
        {
            var tipoSegmento = new List<TipoSegmento>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDLinhaNegocio",
                Value = entidade.LinhaNegocio.IDLinhaNegocio
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoSegmentoListar", parm))
            {
                while (reader.Read())
                {
                    tipoSegmento.Add(new TipoSegmento()
                    {
                        IDTipoSegmento = Convert.ToInt32(reader["IDTipoSegmento"]),
                        Nome = reader["Nome"].ToString(),
                        Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return tipoSegmento;
        }
        #endregion
    }
}
