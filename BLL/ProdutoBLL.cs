using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class ProdutoBLL
    {
        private ProdutoDAO _produto;

        public ProdutoBLL()
        {
            if(_produto == null)
                _produto = new ProdutoDAO();
        }

        public void Novo(Produto entidade)
        {
            _produto.Novo(entidade);
        }

        public void Remover(Produto entidade)
        {
            _produto.Remover(entidade);
        }

        public void Editar(Produto entidade)
        {
            _produto.Editar(entidade);
        }

        public List<Produto> Listar()
        {
            return _produto.Listar();
        }

        public Produto Listar(Produto entidade)
        {
            return _produto.Listar(entidade);
        }

        public void NovoCriterioAderenciaSegmento(Produto entidade)
        {
            _produto.NovoCriterioAderenciaSegmento(entidade);
        }

        public void RemoverCriterioAderenciaSegmento(Produto entidade)
        {
            _produto.RemoverCriterioAderenciaSegmento(entidade);
        }

        public Produto ListarCriterioAderenciaSegmento(Produto entidade)
        {
            return _produto.ListarCriterioAderenciaSegmento(entidade);
        }

        public Produto ListarCriterioAderencia(Produto entidade)
        {
            return _produto.ListarCriterioAderencia(entidade);
        }
    }
}
