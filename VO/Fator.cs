using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Fator
    {
        public int? IDFator { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public int Peso { get; set; }
        public string Comentario { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public int IDFatorNivelSuperior { get; set; }
        public int IDFilho { get; set; }

        //atributos externos usados somente para regra de negocio
        //**********************
        public int IdPai { get; set; }
        public int? Status { get; set; }
        //**********************

        public Modelo Modelo { get; set; }
        public TipoFator TipoFator { get; set; }      
        public Usuario Usuario { get; set; }
        public ProdutoNivel ProdutoNivel { get; set; }
        public Produto Produto { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }
        public List<CriterioFator> CriterioFator { get; set; }
        public List<FatorProdutoNivel> FatorProdutoNivel { get; set; }
        public List<FatorProduto> FatorProduto { get; set; }
        public List<Fator> FatorFilho { get; set; }    
        public Criterio Criterio { get; set; }
        public Segmento Segmento { get; set; }
        public VersaoProdutoFator VersaoProdutoFator { get; set; }

        public Fator()
        {
            this.FatorFilho = new List<Fator>();
        }

    }
}
