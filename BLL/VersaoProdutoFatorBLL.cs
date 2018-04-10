using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class VersaoProdutoFatorBLL
    {
        private VersaoProdutoFatorDAO _versaoProdutoFator;

        public VersaoProdutoFatorBLL()
        {
            if (_versaoProdutoFator == null)
                _versaoProdutoFator = new VersaoProdutoFatorDAO();
        }

        public void Novo(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.Novo(entidade);
        }

        public void Remover(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.Remover(entidade);
        }

        public void Editar(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.Editar(entidade);
        }

        public VersaoProdutoFator Listar(VersaoProdutoFator entidade)
        {
            return _versaoProdutoFator.Listar(entidade);
        }

        public VersaoProdutoFator ListarSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            return _versaoProdutoFator.ListarSegmentoProdutoFatorProduto(entidade);
        }

        public VersaoProdutoFator ListarSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            return _versaoProdutoFator.ListarSegmentoProdutoFatorProdutoNivel(entidade);
        }

        public void NovoSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.NovoSegmentoProdutoFatorProdutoNivel(entidade);
        }

        public void EditarSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.EditarSegmentoProdutoFatorProdutoNivel(entidade);
        }

        public void RemoverSegmentoProdutoFatorProdutoNivel(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.RemoverSegmentoProdutoFatorProdutoNivel(entidade);
        }

        public void NovoSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.NovoSegmentoProdutoFatorProduto(entidade);
        }

        public void EditarSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.EditarSegmentoProdutoFatorProduto(entidade);
        }

        public void RemoverSegmentoProdutoFatorProduto(VersaoProdutoFator entidade)
        {
            _versaoProdutoFator.RemoverSegmentoProdutoFatorProduto(entidade);
        }

        public List<VersaoProdutoFator> ListarRelacaoModelo(VersaoProdutoFator entidade)
        {
            return _versaoProdutoFator.ListarRelacaoModelo(entidade);
        }
    }
}
