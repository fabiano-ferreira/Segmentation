using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class VersaoProdutoFatorSegmentoDAO:BaseCRUD<VersaoProdutoFatorSegmento>
    {

        #region BaseCRUD<VersaoProdutoFatorSegmento> Members

        public void Novo(VersaoProdutoFatorSegmento entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(VersaoProdutoFatorSegmento entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(VersaoProdutoFatorSegmento entidade)
        {
            throw new NotImplementedException();
        }

        public VersaoProdutoFatorSegmento Listar(VersaoProdutoFatorSegmento entidade)
        {
            throw new NotImplementedException();
        }

        public List<VersaoProdutoFatorSegmento> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Segmento> ListarRelacaoSegmento(VersaoProdutoFatorSegmento entidade)
        {
            var versaoProdutoFatorSegmento = new List<Segmento>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorSegmentoListar", parm))
            {
                while (reader.Read())
                {
                    versaoProdutoFatorSegmento.Add(new Segmento()
                    {
                        IDSegmento = Convert.ToInt32(reader["IdSegmento"]),
                        IDVersaoProdutoFator = Convert.ToInt32(reader["IdVersaoProdutoFator"]),
                        Codigo = reader["Codigo"].ToString()
                    });
                }
            }

            return versaoProdutoFatorSegmento;
        }

        #endregion
    }
}
