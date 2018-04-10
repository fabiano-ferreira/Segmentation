using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class LogNovo
    {
        public int IDLog { get; set; }
        public string CodigoErroTecnico { get; set; }
        public string MensagemErroTecnico { get; set; }
        public string Modulo { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Usuario Usuario { get; set; }

    }
}
