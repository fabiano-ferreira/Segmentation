using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VersaoSegmentoProdutoFatorProdutoNivel
    {
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public Segmento Segmento { get; set; }
        public Fator Fator { get; set; }
        public Criterio Criterio { get; set; } 
    }
}
