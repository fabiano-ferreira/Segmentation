using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VersaoSegmentoProdutoFatorProduto
    {
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
        public Produto Produto { get; set; }
        public Segmento Segmento { get; set; }
        public Fator Fator { get; set; }
        public Criterio Criterio { get; set; } 
    }
}
