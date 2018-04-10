using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VariavelCalculoVariavel
    {
        public Variavel Variavel { get; set; }
        public CalculoVariavel CalculoVariavel { get; set; }
        public TipoOperadorCalculo TipoOperadorCalculo { get; set; }
        public int OrdemOperacao { get; set; }
        public bool AbreParentese { get; set; }
        public bool FechaParentese { get; set; }
    }
}
