using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VariavelRegraLogica
    {
        public Variavel Variavel { get; set; }
        public RegraLogica RegraLogica { get; set; }
        public Criterio Criterio { get; set; }
        public string Valor { get; set; }
        public TipoComparacaoRegraLogica TipoComparacaoRegraLogica { get; set; }
    }
}
