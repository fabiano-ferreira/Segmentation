using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class ModeloVariavel
    {
        public Variavel Variavel { get; set; }
        public TipoVariavel TipoVariavel { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public Usuario Usuario { get; set; }

    }
}
