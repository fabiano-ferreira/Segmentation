using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class LinhaNegocioProdutoNivel
    {
        public ProdutoNivel ProdutoNivel { get; set; }
        public RelacaoProdutoNivel RelacaoProdutoNivel { get; set; }
        public Produto Produto { get; set; }
        public RelacaoProdutoNivelProduto RelacaoProdutoNivelProduto { get; set; }

    }
}
