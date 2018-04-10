using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class VariavelCalculoVariavelBLL
    {
        private VariavelCalculoVariavelDAO _variavelCalculoVariavel;

        public VariavelCalculoVariavelBLL()
        {
            if (_variavelCalculoVariavel == null)
                _variavelCalculoVariavel = new VariavelCalculoVariavelDAO();
        }

        public void Novo(VariavelCalculoVariavel entidade)
        {
            _variavelCalculoVariavel.Novo(entidade);
        }

        public void Remover(VariavelCalculoVariavel entidade)
        {
            _variavelCalculoVariavel.Remover(entidade);
        }

        public VariavelCalculoVariavel Listar(VariavelCalculoVariavel entidade)
        {
            return _variavelCalculoVariavel.Listar(entidade);
        }

        public List<VariavelCalculoVariavel> ListarCalculo(VariavelCalculoVariavel entidade)
        {
            return _variavelCalculoVariavel.ListarCalculo(entidade);
        }
    }
}
