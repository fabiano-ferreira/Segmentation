using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Segmento
    {
        public int? IDSegmento { get; set; }
        public int IdCriterioAderenciaCalculado { get; set; }
        public int IDVersaoProdutoFator { get; set; }
        public int? TamanhoMercado { get; set; }
        public string Codigo { get; set; }
        public int? FatorAtratividade { get; set; }
        public int FatorPosicionamento { get; set; }
        public int DistanciaPontoMaximoGrafico { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Modelo Modelo { get; set; }
        public Usuario Usuario { get; set; }
        public Fator Fator { get; set; }
        public List<Entidade> EntidadeList { get; set; }
        public Entidade Entidade { get; set; }
        public Produto Produto { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public Criterio Criterio { get; set; }
        public TipoFator TipoFator { get; set; }
        public CriterioAderencia CriterioAderencia { get; set; }
        public List<SegmentoFator> SegmentoFator { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public List<Segmento> SegmentoLista { get; set; }
        public RegraLogica RegraLogica { get; set; }
        public List<SegmentoRegraLogica> SegmentoRegraLogicaLista { get; set; }
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
    }
}
