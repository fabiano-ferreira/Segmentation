using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Quadrante
    {
        public int IDQuadrante { get; set; }
        public string Descricao { get; set; }
        public int XInicial { get; set; }
        public int YInicial { get; set; }
        public int XFinal { get; set; }
        public int YFinal { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public Grafico Grafico { get; set; }
    }
}
