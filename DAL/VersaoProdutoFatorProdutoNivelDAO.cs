using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VO;

namespace DAL
{
    public class VersaoProdutoFatorProdutoNivelDAO:BaseCRUD<VersaoProdutoFatorProdutoNivel>
    {
        #region BaseCRUD<VersaoProdutoFatorProdutoNivel> Members

        public void Novo(VersaoProdutoFatorProdutoNivel entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(VersaoProdutoFatorProdutoNivel entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(VersaoProdutoFatorProdutoNivel entidade)
        {
            throw new NotImplementedException();
        }

        public VersaoProdutoFatorProdutoNivel Listar(VersaoProdutoFatorProdutoNivel entidade)
        {
            throw new NotImplementedException();
        }

        public List<VersaoProdutoFatorProdutoNivel> Listar()
        {
            throw new NotImplementedException();
        }

        public List<VersaoProdutoFatorProdutoNivel> ListarProduto(VersaoProdutoFatorProdutoNivel entidade)
        {
            var versaoProdutoFatorProdutoNivel = new List<VersaoProdutoFatorProdutoNivel>();

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter()
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@IdVersaoProdutoFator",
                    Value = entidade.VersaoProdutoFator.IdVersaoProdutoFator
                }
            };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "VersaoProdutoFatorProdutoNivelListar", parm))
            {
                while (reader.Read())
                {
                    versaoProdutoFatorProdutoNivel.Add(new VersaoProdutoFatorProdutoNivel()
                    {
                        ProdutoNivel = new ProdutoNivel() 
                        { 
                            IDProdutoNivel = Convert.ToInt32(reader["IDProdutoNivel"]),
                            Nome = reader["Nome"].ToString()
                        }
                    });
                }
            }

            return versaoProdutoFatorProdutoNivel;
        }

        #endregion
    }
}
