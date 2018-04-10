using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class RelacaoProdutoNivel
    {
        public int? IdRelacaoProdutoNivel { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public int? IdFilho { get; set; }
        public string Nome { get; set; }
    }
}
