using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class TipoSaida
    {
        public int IDTipoSaida { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }

    }
}
