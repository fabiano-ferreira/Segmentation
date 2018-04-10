using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public Usuario Usuario { get; set; }
        public int IDEntidade { get; set; }
        public string Codigo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Segmento Segmento { get; set; }
        public Variavel Variavel { get; set; }
        public TipoVariavel TipoVariavel { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public Modelo Modelo { get; set; }
        public List<EntidadeVariavel> EntidadeVariavel { get; set; }
        public Criterio Criterio { get; set; }
        public EntidadeVariavel EntidadeVariavelObject { get; set; }
        public string Regiao { get; set; }
    }
}
