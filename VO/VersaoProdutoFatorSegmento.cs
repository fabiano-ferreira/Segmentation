using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VersaoProdutoFatorSegmento
    {
        public int IdVersaoProdutoFator { get; set; }
        public Segmento Segmento { get; set; }
        public int FatorPosicionamento { get; set; }
        public int DistanciaPontoMaximoGrafico { get; set; }
    }
}
