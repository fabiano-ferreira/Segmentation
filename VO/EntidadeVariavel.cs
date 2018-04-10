using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class EntidadeVariavel
    {
        public Usuario Usuario { get; set; }
        public TipoVariavel TipoVariavel { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public Variavel Variavel { get; set; }
        public double Valor { get; set; }
        public Criterio Criterio { get; set; }
    }
}
