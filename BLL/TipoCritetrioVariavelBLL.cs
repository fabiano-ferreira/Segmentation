using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoCritetrioVariavelBLL
    {
        private TipoCriterioVariavelDAO _tipoCriterioVariavel;

        public TipoCritetrioVariavelBLL()
        {
            if (_tipoCriterioVariavel == null)
                _tipoCriterioVariavel = new TipoCriterioVariavelDAO();
        }

        public TipoCriterioVariavel Listar(TipoCriterioVariavel entidade)
        {
            return _tipoCriterioVariavel.Listar(entidade);
        }

        public List<TipoCriterioVariavel> Listar()
        {
            return _tipoCriterioVariavel.Listar();
        }
    }
}
