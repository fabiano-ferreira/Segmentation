using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class ProdutoNivel
    {
        public int? IDProdutoNivel { get; set; }
        public string Nome { get; set; }
        public string NomePai { get; set; }
        public string NomeFilho { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public RelacaoProdutoNivel RelacaoProdutoNivel { get; set; }
        public RelacaoProdutoNivelProduto RelacaoProdutoNivelProduto { get; set; }
        public Produto Produto { get; set; }
        public int IDFilho { get; set; }
        public List<RelacaoProdutoNivel> RelacaoProdutoNivelLista { get; set; }
        public CriterioAderencia CriterioAderencia { get; set; }
        public Segmento Segmento { get; set; }
        public List<RelacaoProdutoNivelProduto> RelacaoProdutoNivelProdutoLista { get; set; }
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
        public int IDCriterioAderenciaCalculado { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }
    }
}
