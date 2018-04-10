using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class QuadranteBLL
    {
        private QuadranteDAO _quadrante;

        public QuadranteBLL()
        {
            if (_quadrante == null)
                _quadrante = new QuadranteDAO();
        }

        public void Novo(Quadrante entidade)
        {
            _quadrante.Novo(entidade);
        }

        public void Remover(Quadrante entidade)
        {
            _quadrante.Remover(entidade);
        }

        public void Editar(Quadrante entidade)
        {
            _quadrante.Editar(entidade);
        }
    }
}
