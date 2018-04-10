using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Produto
    {
        public int? IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public CriterioAderencia CriterioAderencia { get; set; }
        public Segmento Segmento { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public VersaoProdutoFator VersaoProdutoFator { get; set; }
        public int valor { get; set; }
    }
}
