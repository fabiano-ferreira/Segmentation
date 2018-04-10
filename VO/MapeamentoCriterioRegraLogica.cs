using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class MapeamentoCriterioRegraLogica
    {
        public int IdMapeamentoCriterioRegraLogica { get; set; }
        public RegraLogica RegraLogica { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public int IdCriterioOriginal { get; set; }
        public int IdCriterioTrasnformado { get; set; }
        public Usuario Usuario { get; set; }
    }
}
