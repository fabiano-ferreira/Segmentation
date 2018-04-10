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
    public class VariavelCalculoVariavelDAO : BaseCRUD<VariavelCalculoVariavel>
    {

        #region BaseCRUD<VariavelCalculoVariavel> Members

        public void Novo(VariavelCalculoVariavel entidade)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IdCalculoVariavel",
                    Value = entidade.CalculoVariavel.IdCalculoVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDVariavel",
                    Value = entidade.Variavel.IDVariavel
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@IDTipoOperadorCalculo",
                    Value = entidade.TipoOperadorCalculo.IDTipoOperadorCalculo
                },
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName="@OrdemOperacao",
                    Value = entidade.OrdemOperacao
                },
                new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    Direction = ParameterDirection.Input,
                    ParameterName="@AbrirParentese",
                    Value = entidade.AbreParentese
                },
                new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    Direction = ParameterDirection.Input,
                    ParameterName="@FecharParentese",
                    Value = entidade.FechaParentese
                }
            };
            SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelCalculoVariavelNovo", parms);

        }

        public void Remover(VariavelCalculoVariavel entidade)
        {
            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCalculoVariavel",
                Value = entidade.CalculoVariavel.IdCalculoVariavel
            };
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelCalculoVariavelRemove", parm);
        }

        public void Editar(VariavelCalculoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public VariavelCalculoVariavel Listar(VariavelCalculoVariavel entidade)
        {
            throw new NotImplementedException();
        }

        public List<VariavelCalculoVariavel> Listar()
        {
            throw new NotImplementedException();
        }

        public List<VariavelCalculoVariavel> ListarCalculo(VariavelCalculoVariavel entidade)
        {
            var variavelCalculoVariavel = new List<VariavelCalculoVariavel>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDVariavel",
                Value = entidade.Variavel.IDVariavel
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VariavelCalculoVariavelListar", parm))
            {
                while (reader.Read())
                {
                    variavelCalculoVariavel.Add(new VariavelCalculoVariavel()
                    {
                        Variavel = new Variavel()
                        {
                            IDVariavel = Convert.ToInt32(reader["IDVariavel"]),
                            Criterio = new Criterio() { Valor = Convert.ToInt32(reader["Valor"]) }
                        },
                        TipoOperadorCalculo = new TipoOperadorCalculo() { IDTipoOperadorCalculo = Convert.ToInt32(reader["IDTipoOperadorCalculo"]) },

                    });
                }
            }

            return variavelCalculoVariavel;
        }
        #endregion
    }
}
