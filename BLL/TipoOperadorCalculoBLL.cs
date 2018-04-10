using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoOperadorCalculoBLL
    {
        private TipoOperadorCalculoDAO _tipoOperadorcalculo;
        public TipoOperadorCalculoBLL()
        {
            if (_tipoOperadorcalculo == null)
                _tipoOperadorcalculo = new TipoOperadorCalculoDAO();
        }

        public TipoOperadorCalculo Listar(TipoOperadorCalculo entidade)
        {
            return _tipoOperadorcalculo.Listar(entidade);
        }

        public List<TipoOperadorCalculo> Listar()
        {
            return _tipoOperadorcalculo.Listar();
        }
    }
}
