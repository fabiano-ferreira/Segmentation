using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class TipoOperadorCalculo
    {
        public int? IDTipoOperadorCalculo { get; set; }
        public string Nome { get; set; }
        public string Simbolo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
    }
}
