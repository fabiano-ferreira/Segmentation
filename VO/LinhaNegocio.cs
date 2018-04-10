using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class LinhaNegocio
    {
        public int? IDLinhaNegocio { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public RelacaoProdutoNivel RelacaoProdutoNivel { get; set; }
        public RelacaoProdutoNivelProduto RelacaoProdutoNivelProduto { get; set; }
        public Produto Produto { get; set; }
        public List<LinhaNegocioClasseVariavel> LinhaNegocioClasseVariavel { get; set; }
        public List<LinhaNegocioProdutoNivel> LinhaNegocioProdutoNivel { get; set; }
        public List<LinhaNegocioUsuario> LinhaNegocioUsuario { get; set; }
    }
}
