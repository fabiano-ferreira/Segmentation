using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class TipoOperadorCalculoDAO: BaseCRUD<TipoOperadorCalculo>
    {
        #region BaseCRUD<TipoOperadorCalculo> Members

        public void Novo(TipoOperadorCalculo entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoOperadorCalculo entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoOperadorCalculo entidade)
        {
            throw new NotImplementedException();
        }

        public TipoOperadorCalculo Listar(TipoOperadorCalculo entidade)
        {
            var tipoOperadorCalculo = new TipoOperadorCalculo();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoOperadorCalculo",
                Value = entidade.IDTipoOperadorCalculo
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoOperadorCalculoListar", parm))
            {
                if (reader.Read())
                {
                    tipoOperadorCalculo.IDTipoOperadorCalculo = Convert.ToInt32(reader["IDTipoOperadorCalculo"]);
                    tipoOperadorCalculo.Nome = reader["Nome"].ToString();
                    tipoOperadorCalculo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                    tipoOperadorCalculo.DataModificacao = Convert.ToDateTime(reader["DataModificacao"]);
                    tipoOperadorCalculo.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(reader["IdUsuario"]) };
                }
            }

            return tipoOperadorCalculo;
        }

        public List<TipoOperadorCalculo> Listar()
        {
            List<TipoOperadorCalculo> dadosTipoOperador = new List<TipoOperadorCalculo>();

            SqlParameter parm = new SqlParameter()
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                ParameterName = "@IDTipoOperadorCalculo",
                Value = null
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "TipoOperadorCalculoListar", parm))
            {
                while (reader.Read())
                {
                    dadosTipoOperador.Add(new TipoOperadorCalculo()
                    {
                        IDTipoOperadorCalculo = Convert.ToInt32(reader["IdTipoOperadorCalculo"]),
                        Simbolo = reader["Simbolo"].ToString()
                    });

                }
            }
            return dadosTipoOperador;
        }
        #endregion
    }
}
