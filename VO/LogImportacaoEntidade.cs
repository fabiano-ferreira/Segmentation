using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class LogImportacaoEntidade
    {
        public int IdLogImportacaoEntidade { get; set; }
        public string CodigoVariavel { get; set; }
        public string DocumentoEntidade { get; set; }
        public Criterio Criterio { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public string NomeUsuario { get; set; }
        public List<LogImportacaoEntidade> LogImportacaoEntidadeLista { get; set; }
    }
}
