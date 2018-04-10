using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class CalculoVariavelBLL
    {
        private CalculoVariavelDAO _calculoVariavel;


        public CalculoVariavelBLL()
        {
            if (_calculoVariavel == null)
                _calculoVariavel = new CalculoVariavelDAO();
        }

        public void Novo(CalculoVariavel entidade) 
        {
            _calculoVariavel.Novo(entidade); 
        } 

        public void Remover(CalculoVariavel entidade)
        {
            _calculoVariavel.Remover(entidade);
        }

        public void Editar(CalculoVariavel entidade)
        {
            _calculoVariavel.Editar(entidade);
        }

        public List<CalculoVariavel> Listar()
        {
            return _calculoVariavel.Listar();
        }

        public CalculoVariavel Listar(CalculoVariavel entidade)
        {
            return _calculoVariavel.Listar(entidade);
        }
    }
}
