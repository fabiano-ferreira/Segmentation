using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Criterio
    {
        public int? IDCriterio { get; set; }
        public int? IDIdCriterioAderencia { get; set; }
        public string Nome { get; set; }
        public int? Valor { get; set; }
        public int? Valor2 { get; set; }
        public Usuario Usuario { get; set; }
        public Fator Fator { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Variavel Variavel { get; set; }
        public TipoCriterioVariavel TipoCriterioVariavel { get; set; }
        public CriterioAderencia CriterioAderencia { get; set; }
        public CriterioVariavel CriterioVariavel { get; set; }
        public List<CriterioFator> CriterioFatorLista { get; set; }
        public string Descricao { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }
    }
}
