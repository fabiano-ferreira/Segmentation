using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class GraficoDAO:BaseCRUD<Grafico>
    {

        #region BaseCRUD<Grafico> Members

        public void Novo(Grafico entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Titulo",
                    Value = entidade.Titulo
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
                    ParameterName="@IdGrafico",
                    Value = entidade.IDGrafico
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoNovo", parms);
        }

        public void Remover(Grafico entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdGrafico",
                Value = entidade.IDGrafico
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoRemover", parm);
        }

        public void Editar(Grafico entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName="@Titulo",
                    Value = entidade.Titulo
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
                    ParameterName="@IdGrafico",
                    Value = entidade.IDGrafico
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoEditar,", parms);
        }

        public Grafico Listar(Grafico entidade)
        {
            var grafico = new Grafico();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdGrafico",
                Value = entidade.IDGrafico
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoListar", parm))
            {
                if (reader.Read())
                {
                    grafico.IDGrafico = Convert.ToInt32(reader["IdGrafico"]);
                    grafico.Titulo = reader["Titulo"].ToString();
                    grafico.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    grafico.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    grafico.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return grafico;
        }

        public List<Grafico> Listar()
        {
            var grafico = new List<Grafico>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdGrafico",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoListar", parm))
            {
                while (reader.Read())
                {
                    grafico.Add(new Grafico()
                    {
                        IDGrafico = Convert.ToInt32(reader["IdGrafico"]),
                        Titulo = reader["Titulo"].ToString(),
                        DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                        DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        Usuario = new Usuario(){ IDUsuario = Convert.ToInt32(reader["IdUsuario"]) }
                    });
                }
            }

            return grafico;
        }

        public Grafico ListarQuadrante(Grafico entidade)
        {
            var grafico = new Grafico();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdGrafico",
                Value = entidade.IDGrafico
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoQuadranteListar", parm))
            {
                if (reader.Read())
                {
                    grafico.Quadrante = new Quadrante ()
                    { 
                            IDQuadrante = Convert.ToInt32(reader["IDQuadrante"]), 
                            Descricao = reader["Descricao"].ToString(),
                            XInicial = Convert.ToInt32(reader["XInicial"]),
                            YInicial = Convert.ToInt32(reader["YInicial"]),
                            XFinal = Convert.ToInt32(reader["XFinal"]),
                            YFinal = Convert.ToInt32(reader["YFinal"]),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                    };
                    grafico.IDGrafico = Convert.ToInt32(reader["IdGrafico"]);
                    grafico.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return grafico;
        }

        public List<Grafico> ListarQuadrante()
        {
            var grafico = new List<Grafico>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdGrafico",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "GraficoQuadranteListar", parm))
            {
                while (reader.Read())
                {
                    grafico.Add(new Grafico()
                    {
                        Quadrante = new Quadrante (){ 
                            IDQuadrante = Convert.ToInt32(reader["IDQuadrante"]), 
                            Descricao = reader["Descricao"].ToString(),
                            XInicial = Convert.ToInt32(reader["XInicial"]),
                            YInicial = Convert.ToInt32(reader["YInicial"]),
                            XFinal = Convert.ToInt32(reader["XFinal"]),
                            YFinal = Convert.ToInt32(reader["YFinal"]),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            DataModificacao = Convert.ToDateTime(reader["DataModificacao"]),
                        },
                        IDGrafico = Convert.ToInt32(reader["IdGrafico"]),
                        Usuario = new Usuario(){ IDUsuario = Convert.ToInt32(reader["IdUsuario"])}
                    });
                }   
            }

            return grafico;
        }

        #endregion
    }
}
