using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class VersaoProdutoFatorProdutoNivelBLL
    {
        private VersaoProdutoFatorProdutoNivelDAO _versaoProdutoFatorProdutoNivel;

        public VersaoProdutoFatorProdutoNivelBLL()
        {
            if (_versaoProdutoFatorProdutoNivel == null)
                _versaoProdutoFatorProdutoNivel = new VersaoProdutoFatorProdutoNivelDAO();
        }

        public List<VersaoProdutoFatorProdutoNivel> ListarProduto(VersaoProdutoFatorProdutoNivel entidade)
        {
            return _versaoProdutoFatorProdutoNivel.ListarProduto(entidade);
        }
    }
}
