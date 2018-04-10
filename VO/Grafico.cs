using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Grafico
    {
        public string Titulo { get; set; }
        public Usuario Usuario { get; set; }
        public int IDGrafico { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Quadrante Quadrante { get; set; }

    }
}
