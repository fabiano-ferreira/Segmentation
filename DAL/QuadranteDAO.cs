using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class QuadranteDAO: BaseCRUD<Quadrante>
    {
        #region BaseCRUD<Quadrante> Members

        public void Novo(Quadrante entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdQuadrante",
                    Value = entidade.IDQuadrante
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
                    ParameterName="@XInicial",
                    Value = entidade.XInicial
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@YInicial",
                    Value = entidade.YInicial
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@XFinal",
                    Value = entidade.XFinal
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@YFinal",
                    Value = entidade.YFinal
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
                    ParameterName="@IdQuadrante",
                    Value = entidade.IDQuadrante
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "QuadranteNovo", parms);
        }

        public void Remover(Quadrante entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdQuadrante",
                Value = entidade.IDQuadrante
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "QuadranteRemover", parm);
        }

        public void Editar(Quadrante entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdQuadrante",
                    Value = entidade.IDQuadrante
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
                    ParameterName="@XInicial",
                    Value = entidade.XInicial
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@YInicial",
                    Value = entidade.YInicial
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@XFinal",
                    Value = entidade.XFinal
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@YFinal",
                    Value = entidade.YFinal
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdGrafico",
                    Value = entidade.Grafico.IDGrafico
                }
                ,
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdUsuario",
                    Value = entidade.Usuario.IDUsuario
                }
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "QuadranteEditar", parms);
        }

        public Quadrante Listar(Quadrante entidade)
        {
            throw new NotImplementedException();
        }

        public List<Quadrante> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
