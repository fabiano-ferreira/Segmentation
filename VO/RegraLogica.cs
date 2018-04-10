using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class RegraLogica
    {
        public int? IdRegraLogica { get; set; }
        public float Valor { get; set; }
        public bool Valido { get; set; }
        public Variavel Variavel { get; set; }
        public Criterio Criterio { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public List<VariavelRegraLogica> VariavelRegraLogica { get; set; }
        public Variavel VariavelHerdado { get; set; }
        public TipoComparacaoRegraLogica TipoComparacaoRegraLogica { get; set; }
        public List<RegraLogica> RegraLogicaLista { get; set; }
    }
}
