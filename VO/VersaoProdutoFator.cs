using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class VersaoProdutoFator
    {
        public int? IdVersaoProdutoFator { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public int FatorPosicionamento { get; set; }
        public Usuario Usuario { get; set; }
        public List<VersaoSegmento> VersaoSegmento { get; set; }
        public VersaoSegmentoProdutoFatorProduto VersaoSegmentoProdutoFatorProduto { get; set; }
        public VersaoSegmentoProdutoFatorProdutoNivel VersaoSegmentoProdutoFatorProdutoNivel { get; set; }
        public int DistanciaPontoMaximoGrafico { get; set; }
        public Segmento Segmento { get; set; }
        public Modelo Modelo { get; set; }
        public List<VersaoProdutoFator> VersaoProdutoFatorLista { get; set; }
    }
}
