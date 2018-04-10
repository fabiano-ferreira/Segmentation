using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class TipoComparacaoRegraLogica
    {
        public int IDTipoComparacaoRegraLogica { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; } 
        public Usuario Usuario { get; set; }
    }
}
