using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VersaoProdutoFatorProdutoNivel
    {
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public List<VersaoProdutoFatorProdutoNivel> VersaoProdutoFatorProdutoNivelLista { get; set; }
    }
}
