using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoFatorBLL
    {
        private TipoFatorDAO _tipoFator;

        public TipoFatorBLL()
        {
            if (_tipoFator == null)
                _tipoFator = new TipoFatorDAO();
        }

        public TipoFator Listar(TipoFator entidade)
        {
            return _tipoFator.Listar(entidade);
        }

        public List<TipoFator> Listar()
        {
            return _tipoFator.Listar();
        }


    }
}
